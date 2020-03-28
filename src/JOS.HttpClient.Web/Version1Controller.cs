using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using JOSHttpClient.Version1;
using Microsoft.AspNetCore.Mvc;

namespace JOS.HttpClient.Web
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class Version1Controller : Controller
    {
        private readonly GetAllProjectsQuery _getAllProjectsQuery;

        public Version1Controller(GetAllProjectsQuery getAllProjectsQuery)
        {
            _getAllProjectsQuery = getAllProjectsQuery ?? throw new ArgumentNullException(nameof(getAllProjectsQuery));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProjects(CancellationToken cancellationToken)
        {
            var result = await _getAllProjectsQuery.Execute(cancellationToken).ConfigureAwait(false);
            var response = new ApiResponse<ProjectResponseDto>(
                (int)HttpStatusCode.OK,
                new ProjectResponseDto(result.Select(x => new ProjectDto(x.Name, x.Url, x.Stars)).OrderByDescending(x => x.Stars).ToArray()));

            return new OkObjectResult(response);
        }
    }
}
