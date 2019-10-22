using Correlation.Abstractions;
using Correlation.Contexts;
using Correlation.Http.MessageHandlers;
using Correlation.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace Correlation
{
    /// <summary>
    /// Extensions for work with correlation context.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Add correlation.
        /// </summary>
        public static IServiceCollection AddCorrelation(this IServiceCollection services)
        {
            return services
                .AddHttpClient()
                .AddHttpContextAccessor()
                .AddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>()
                .AddSingleton<ICorrelationContextFactory, CorrelationContextFactory>()
                .AddSingleton<IHttpMessageHandlerBuilderFilter, CorrelationPropagationMessageHandlerBuilderFilter>();
        }

        /// <summary>
        /// Use correlation.
        /// </summary>
        public static IApplicationBuilder UseCorrelation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
