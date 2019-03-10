using System.Collections.Generic;
using System.Threading.Tasks;
using JOSHttpClient.Common.Domain;

namespace JOSHttpClient.Common
{
    public interface IGetAllProjectsQuery
    {
        Task<IReadOnlyCollection<Project>> Execute();
    }
}
