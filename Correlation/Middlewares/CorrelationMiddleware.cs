using System.Threading.Tasks;
using Correlation.Abstractions;
using Correlation.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Correlation.Middlewares
{
    /// <summary>
    /// A middleware for exchanging correlation identifier across different services.
    /// </summary>
    internal sealed class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Create instance of <see cref="CorrelationMiddleware" />.
        /// </summary>
        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary />
        public async Task InvokeAsync(HttpContext httpContext, ICorrelationContextFactory correlationContextFactory, ILogger<CorrelationMiddleware> logger)
        {
            var correlationContext = correlationContextFactory.Create(httpContext);

            // Put correlation identifier into a header.
            httpContext.Items[HeaderNames.CorrelationId] = correlationContext.Id;
            httpContext.Response.Headers.Add(HeaderNames.CorrelationId, correlationContext.Id);

            // Put correlation identifier into a log context.
            using (logger.BeginScope("{CorrelationId}", correlationContext.Id))
            {
                await _next(httpContext);
            }
        }
    }
}
