using System;
using System.Net.Http;
using System.Threading.Tasks;
using JOSHttpClient.Version8;
using Shouldly;
using Xunit;

namespace JOSHttpClient.Tests.Version8
{
    public class GitHubClientTests
    {
        private readonly HttpMessageHandler _httpMessageHandler;
        private readonly GitHubClient _sut;

        public GitHubClientTests()
        {
            _httpMessageHandler = new FakeHttpMessageHandler();
            _sut = new GitHubClient(new HttpClient(_httpMessageHandler){BaseAddress = new Uri("http://localhost")}, new ProjectDeserializer());
        }

        [Fact]
        public async Task Hej()
        {
            var result = await _sut.GetRepositories();

            result.Count.ShouldBe(0);
        }
    }
}
