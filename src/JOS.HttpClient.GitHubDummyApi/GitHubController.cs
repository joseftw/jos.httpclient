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
        public IActionResult Get()
        {
            return new OkObjectResult(GitHubRepositoriesProvider.JsonItems);
        }
    }
}
