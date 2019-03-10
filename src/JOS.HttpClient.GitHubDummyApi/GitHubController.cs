using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JOS.HttpClient.GitHubDummyApi
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        [HttpGet("repositories")]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(20);
            return new OkObjectResult(GitHubRepositoriesProvider.JsonItems);
        }
    }
}
