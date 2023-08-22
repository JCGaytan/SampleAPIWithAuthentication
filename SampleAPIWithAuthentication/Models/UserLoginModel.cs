namespace SampleAPIWithAuthentication.Models
{
    /// <summary>
    /// Represents the model for user login information.
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// Gets or sets the username for user login.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for user login.
        /// </summary>
        public string Password { get; set; }
    }
}