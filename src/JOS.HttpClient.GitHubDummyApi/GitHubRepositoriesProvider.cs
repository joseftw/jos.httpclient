using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JOS.HttpClient.GitHubDummyApi
{
    public static class GitHubRepositoriesProvider
    {
        private static readonly IList<object> Items = new List<object>();
        private static readonly IReadOnlyList<string> FileNames = new List<string>
        {
            "repositories.10.json",
            "repositories.100.json",
            "repositories.1000.json",
            "repositories.10000.json",
        };

        public static async Task Initialize()
        {
            foreach (var fileName in FileNames)
            {
                var json = await File.ReadAllTextAsync(fileName, Encoding.UTF8);
                var parsed = JsonConvert.DeserializeObject(json);
                Items.Add(parsed);
            }

            JsonItems = Items[3];
        }

        public static object JsonItems { get; private set; }
    }
}
