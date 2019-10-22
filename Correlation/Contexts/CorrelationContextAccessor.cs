using System.Threading;
using Correlation.Abstractions;

namespace Correlation.Contexts
{
    /// <inheritdoc cref="ICorrelationContextAccessor" />
    internal sealed class CorrelationContextAccessor : ICorrelationContextAccessor
    {
        private readonly static AsyncLocal<CorrelationContext> _correlationContext = new AsyncLocal<CorrelationContext>();

        /// <inheritdoc cref="ICorrelationContextAccessor.CorrelationContext" />
        public CorrelationContext CorrelationContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}
