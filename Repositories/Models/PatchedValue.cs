namespace Common.Models
{
    /// <summary>
    /// Represents a value that may be patched, indicating whether it is defined or not.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class PatchedValue<T>
    {
        /// <summary>
        /// Gets a value indicating whether the value is defined.
        /// </summary>
        public bool IsDefined { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchedValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isDefined">A boolean indicating whether the value is defined.</param>
        public PatchedValue(T value, bool isDefined)
        {
            Value = value;
            IsDefined = isDefined;
        }
    }
}