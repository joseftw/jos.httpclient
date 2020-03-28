using System;
using System.Linq;
using System.Net;
using System.Threading;
using JOSHttpClient.Version0;
using Microsoft.AspNetCore.Mvc;

namespace JOS.HttpClient.Web
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class Version0Controller : Controller
    {
        private readonly GetAllProjectsQuery _getAllProjectsQuery;

        public Version0Controller(GetAllProjectsQuery getAllProjectsQuery)
        {
            _getAllProjectsQuery = getAllProjectsQuery ?? throw new ArgumentNullException(nameof(getAllProjectsQuery));
        }

        [HttpGet("")]
        public IActionResult GetAllProjects()
        {
            var result = _getAllProjectsQuery.Execute(CancellationToken.None);
            var response = new ApiResponse<ProjectResponseDto>(
                (int)HttpStatusCode.OK,
                new ProjectResponseDto(result.Select(x => new ProjectDto(x.Name, x.Url, x.Stars)).OrderByDescending(x => x.Stars).ToArray()));

            return new OkObjectResult(response);
        }
    }
}
