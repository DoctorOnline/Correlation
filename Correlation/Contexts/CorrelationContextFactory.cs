using System;
using Correlation.Abstractions;
using Correlation.Constants;
using Microsoft.AspNetCore.Http;

namespace Correlation.Contexts
{
    /// <inheritdoc cref="ICorrelationContextFactory" />
    public sealed class CorrelationContextFactory : ICorrelationContextFactory
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;

        /// <summary>
        /// Create instance of <see cref="CorrelationContextFactory" />.
        /// </summary>
        public CorrelationContextFactory(ICorrelationContextAccessor correlationContextAccessor)
        {
            _correlationContextAccessor = correlationContextAccessor;
        }

        /// <inheritdoc cref="ICorrelationContextFactory.Create()" />
        public CorrelationContext Create()
        {
            _correlationContextAccessor.CorrelationContext = new CorrelationContext()
            {
                Id = Guid.NewGuid().ToString()
            };

            return _correlationContextAccessor.CorrelationContext;
        }

        /// <inheritdoc cref="ICorrelationContextFactory.Create(string)" />
        public CorrelationContext Create(string correlationId)
        {
            if (string.IsNullOrEmpty(correlationId))
            {
                throw new ArgumentException($"{nameof(correlationId)} cannot be null or empty.");
            }

            _correlationContextAccessor.CorrelationContext = new CorrelationContext()
            {
                Id = correlationId
            };

            return _correlationContextAccessor.CorrelationContext;
        }

        /// <inheritdoc cref="ICorrelationContextFactory.Create(HttpContext)" />
        public CorrelationContext Create(HttpContext httpContext)
        {
            var header = httpContext.Request.Headers[HeaderNames.CorrelationId];

            _correlationContextAccessor.CorrelationContext = new CorrelationContext()
            {
                Id = header.Count > 0 ? header[0] : Guid.NewGuid().ToString()
            };

            return _correlationContextAccessor.CorrelationContext;
        }
    }
}