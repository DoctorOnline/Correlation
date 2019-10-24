using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Correlation.Tests")]
namespace Correlation.Constants
{
    internal static class HeaderNames
    {
        /// <summary>
        /// Header name for correlation identifier.
        /// </summary>
        public const string CorrelationId = "X-Correlation-ID";
    }
}
