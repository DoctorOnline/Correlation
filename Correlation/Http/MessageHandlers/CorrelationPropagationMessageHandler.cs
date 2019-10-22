using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Correlation.Abstractions;
using Correlation.Constants;

namespace Correlation.Http.MessageHandlers
{
    internal class CorrelationPropagationMessageHandler : DelegatingHandler
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;

        /// <summary>
        /// Create instance of <see cref="CorrelationPropagationMessageHandler" />.
        /// </summary>
        public CorrelationPropagationMessageHandler(ICorrelationContextAccessor correlationContextAccessor)
        {
            _correlationContextAccessor = correlationContextAccessor;
        }

        /// <inheritdoc cref="DelegatingHandler.SendAsync(HttpRequestMessage, CancellationToken)" />
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryAddWithoutValidation(HeaderNames.CorrelationId, _correlationContextAccessor.CorrelationContext.Id);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
