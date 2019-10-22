using Correlation.Contexts;
using Microsoft.AspNetCore.Http;

namespace Correlation.Abstractions
{
    /// <summary>
    /// A factory for creating correlation context.
    /// </summary>
    public interface ICorrelationContextFactory
    {
        /// <summary>
        /// Create new correlation context.
        /// </summary>
        /// <remarks>With automatically generated identifier like Guid.NewGuid().ToString().</remarks>
        /// <returns>Correlation context.</returns>
        CorrelationContext Create();

        /// <summary>
        /// Create new correlation context.
        /// </summary>
        /// <exception>CorrelationId cannot be null or empty.</exception>
        /// <returns>Correlation context.</returns>
        CorrelationContext Create(string correlationId);

        /// <summary>
        /// Create new correlation context.
        /// </summary>
        /// <remarks>
        /// Try to get correlation identifier from requests header (X-Correlation-ID),
        /// if it not exist then automatically generated identifier like Guid.NewGuid().ToString().
        /// </remarks>
        /// <returns>Correlation context.</returns>
        CorrelationContext Create(HttpContext httpContext);
    }
}