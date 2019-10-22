using System;
using Correlation.Abstractions;
using Microsoft.Extensions.Http;

namespace Correlation.Http.MessageHandlers
{
    internal class CorrelationPropagationMessageHandlerBuilderFilter : IHttpMessageHandlerBuilderFilter
    {
        private readonly ICorrelationContextAccessor _correlationContext;

        /// <summary>
        /// Create instance of <see cref="CorrelationPropagationMessageHandlerBuilderFilter" />.
        /// </summary>
        public CorrelationPropagationMessageHandlerBuilderFilter(ICorrelationContextAccessor correlationContext)
        {
            _correlationContext = correlationContext;
        }

        /// <inheritdoc cref="IHttpMessageHandlerBuilderFilter.Configure(Action{HttpMessageHandlerBuilder})" />
        public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
        {
            return builder =>
            {
                builder.AdditionalHandlers.Add(new CorrelationPropagationMessageHandler(_correlationContext));
                next(builder);
            };
        }
    }
}
