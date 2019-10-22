namespace Correlation.Contexts
{
    /// <summary>
    /// Class that contains information about correlation context.
    /// </summary>
    public sealed class CorrelationContext
    {
        /// <summary>
        /// Create instance of <see cref="CorrelationContext" />.
        /// </summary>
        internal CorrelationContext() { }

        /// <summary>
        /// Unique identifier of current correlation context.
        /// </summary>
        public string Id { get; set; }
    }
}
