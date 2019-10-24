using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Correlation.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Correlation.Tests
{
    public sealed class CorrelationTests
    {
        [Fact]
        public async Task Response_ShouldBe_WithoutCorrelationId()
        {
            var builder = new WebHostBuilder()
                .ConfigureServices(cs => { })
                .Configure(app => { });

            using var server = new TestServer(builder);
            using var client = server.CreateClient();

            var response = await client.GetAsync("");
            var isContainsHeader = response.Headers.Contains(Constants.HeaderNames.CorrelationId);

            Assert.False(isContainsHeader);
        }

        [Fact]
        public async Task Response_ShouldBe_WithCorrelationId()
        {
            var builder = new WebHostBuilder()
                .ConfigureServices(sc => sc.AddCorrelation())
                .Configure(app => app.UseCorrelation());

            using var server = new TestServer(builder);
            using var client = server.CreateClient();

            var response = await client.GetAsync("");
            var header = response.Headers.GetValues(Constants.HeaderNames.CorrelationId);

            Assert.NotNull(header);
        }
    }
}
