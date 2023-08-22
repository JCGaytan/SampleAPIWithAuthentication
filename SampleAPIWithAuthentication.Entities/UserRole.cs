namespace SampleAPIWithAuthentication.Entities
{
    /// <summary>
    /// Represents a role that can be assigned to users.
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the user role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the user role was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user role is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the collection of users associated with this user role.
        /// </summary>
        public ICollection<User>? Users { get; set; }
    }
}