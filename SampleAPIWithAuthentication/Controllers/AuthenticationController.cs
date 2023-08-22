using EncryptionLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SampleAPIWithAuthentication.DataAccess;
using SampleAPIWithAuthentication.Entities;
using SampleAPIWithAuthentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleAPIWithAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;
        private readonly AesEncryptor _encryptor; // Add an instance of AesEncryptor

        public AuthenticationController(IConfiguration configuration, AppDbContext dbContext, AesEncryptor encryptor)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _encryptor = encryptor; // Initialize the AesEncryptor instance
        }

        /// <summary>
        /// Authenticates a user and generates a JWT token.
        /// </summary>
        /// <param name="userLoginModel">User's login information.</param>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
        {
            // Find the user based on the provided username
            var user = await _dbContext.Users.Include(i => i.UserRole)
                .FirstOrDefaultAsync(f => f.UserName == userLoginModel.UserName);

            if (user == null || !ValidatePassword(userLoginModel.Password, user.Password))
            {
                return Unauthorized(); // Invalid credentials
            }

            // Generate and return a JWT token
            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        /// <summary>
        /// Validates the provided password against the stored encrypted password.
        /// </summary>
        /// <param name="inputPassword">Password entered by the user.</param>
        /// <param name="storedEncryptedPassword">Encrypted password stored in the database.</param>
        /// <returns>True if the passwords match; otherwise, false.</returns>
        private bool ValidatePassword(string inputPassword, string storedEncryptedPassword)
        {
            // Decrypt the stored encrypted password and compare
            var decryptedPassword = _encryptor.DecryptAES(Convert.FromBase64String(storedEncryptedPassword), _configuration["AppSettings:EncryptionKey"]);
            return inputPassword == decryptedPassword;
        }

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="user">Authenticated user.</param>
        /// <returns>Generated JWT token.</returns>
        private string GenerateJwtToken(User user)
        {
            // Create claims for the user
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.UserRole.Name)
            };

            // Create key and signing credentials for the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generate and return the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
