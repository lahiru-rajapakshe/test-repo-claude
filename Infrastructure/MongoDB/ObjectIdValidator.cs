using MongoDB.Bson;

namespace Common.Infrastructure.MongoDB
{
    /// <summary>
    /// Provides validation for MongoDB ObjectId.
    /// </summary>
    public class ObjectIdValidator
    {
        /// <summary>
        /// Validates if the provided string is a valid MongoDB ObjectId.
        /// </summary>
        /// <param name="id">The string representation of the ObjectId to be validated.</param>
        /// <returns>True if the string is a valid ObjectId; otherwise, false.</returns>
        public static bool IsValidObjectId(string id)
        {
            return ObjectId.TryParse(id, out _);
        }
    }
}