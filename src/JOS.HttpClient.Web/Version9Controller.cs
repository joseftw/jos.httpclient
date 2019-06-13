using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JOSHttpClient.Version9;
using Microsoft.AspNetCore.Mvc;

namespace JOS.HttpClient.Web
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class Version9Controller : Controller
    {
        private readonly GetAllProjectsQuery _getAllProjectsQuery;

        public Version9Controller(GetAllProjectsQuery getAllProjectsQuery)
        {
            _getAllProjectsQuery = getAllProjectsQuery ?? throw new ArgumentNullException(nameof(getAllProjectsQuery));
        }   

        [HttpGet("")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _getAllProjectsQuery.Execute().ConfigureAwait(false);
            var response = new ApiResponse<ProjectResponseDto>(
                (int)HttpStatusCode.OK,
                new ProjectResponseDto(result.Select(x => new ProjectDto(x.Name, x.Url, x.Stars)).OrderByDescending(x => x.Stars).ToArray()));

            return new OkObjectResult(response);
        }
    }
}
