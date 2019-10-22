using Correlation.Contexts;

namespace Correlation.Abstractions
{
    /// <summary>
    /// Accessor for correlation context.
    /// </summary>
    public interface ICorrelationContextAccessor
    {
        /// <summary>
        /// Correlation context.
        /// </summary>
        CorrelationContext CorrelationContext { get; set; }
    }
}
