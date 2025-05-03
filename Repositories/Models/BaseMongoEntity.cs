namespace Common.Models
{
    /// <summary>
    /// Represents the base entity for MongoDB with string as the identifier.
    /// </summary>
    public class BaseMongoEntity : IBaseEntity<string>
    {
        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user who created the entity.
        /// </summary>
        public string CreatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the user who last modified the entity.
        /// </summary>
        public string ModifiedBy { get; set; } = null!;

    }
}