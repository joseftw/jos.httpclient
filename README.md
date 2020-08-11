# jos.httpclient

https://josefottosson.se/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/

## Benchmark instructions

1. Clone the repository
2. ```cd jos.httpclient```
3. ```dotnet build -c Release```
4. ```dotnet run src/JOS.HttpClient.GitHubDummyApi -c Release```
5. ```cd /src/JOS.HttpClient.Benchmark/bin/Release/netcore```
6. ```dotnet JOS.HttpClient.Benchmark.dll```

You can control how many items the Dummy API should return by changing this parameter:
https://github.com/joseftw/jos.httpclient/blob/develop/src/JOS.HttpClient.GitHubDummyApi/GitHubRepositoriesProvider.cs#L29
