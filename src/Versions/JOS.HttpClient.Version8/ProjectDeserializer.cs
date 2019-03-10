using System.Collections.Generic;
using JOSHttpClient.Common;
using Newtonsoft.Json;

namespace JOSHttpClient.Version8
{
    public class ProjectDeserializer
    {
        public IReadOnlyCollection<GitHubRepositoryDto> Deserialize(JsonTextReader jsonTextReader)
        {
            var repositories = new List<GitHubRepositoryDto>();
            var currentPropertyName = string.Empty;
            GitHubRepositoryDto repository = null;
            while (jsonTextReader.Read())
            {
                switch (jsonTextReader.TokenType)
                {
                    case JsonToken.StartObject:
                        repository = new GitHubRepositoryDto();
                        continue;
                    case JsonToken.EndObject:
                        repositories.Add(repository);
                        continue;
                    case JsonToken.PropertyName:
                        currentPropertyName = jsonTextReader.Value.ToString();
                        continue;
                    case JsonToken.String:
                        switch (currentPropertyName)
                        {
                            case "name":
                                repository.Name = jsonTextReader.Value.ToString();
                                continue;
                            case "url":
                                repository.Url = jsonTextReader.Value.ToString();
                                continue;
                        }
                        continue;
                    case JsonToken.Integer:
                        switch (currentPropertyName)
                        {
                            case "stars":
                                repository.Stars = int.Parse(jsonTextReader.Value.ToString());
                                continue;
                        }
                        continue;
                }
            }
            return repositories;
        }
    }
}
