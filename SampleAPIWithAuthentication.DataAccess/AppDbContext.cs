using Microsoft.EntityFrameworkCore;
using SampleAPIWithAuthentication.Entities;

namespace SampleAPIWithAuthentication.DataAccess
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet for User entities.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for UserRole entities.
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Configures the model of the database during the context initialization.
        /// </summary>
        /// <param name="modelBuilder">The builder to define the shape of the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Custom model configuration can be added here.
            // For example, setting up relationships, indexes, etc.
        }
    }
}