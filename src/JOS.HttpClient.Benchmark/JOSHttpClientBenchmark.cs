using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using JOSHttpClient.Common;
using JOSHttpClient.Version0;
using JOSHttpClient.Version1;
using JOSHttpClient.Version2;
using JOSHttpClient.Version3;
using JOSHttpClient.Version4;
using JOSHttpClient.Version5;
using JOSHttpClient.Version6;
using JOSHttpClient.Version7;
using JOSHttpClient.Version8;
using JOSHttpClient.Version9;
using JOSHttpClient.Version10;
using Microsoft.Extensions.DependencyInjection;
using GitHubClient = JOSHttpClient.Version0.GitHubClient;

namespace JOS.HttpClient.Benchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, invocationCount: 50)]
    [HtmlExporter]
    public class JOSHttpClientBenchmark
    {
        private IServiceProvider _serviceProvider;
        [GlobalSetup]
        public void GlobalSetup()
        {
            var servicesCollection = new ServiceCollection();
            var services = new DefaultServiceProviderFactory().CreateBuilder(servicesCollection);
            services.AddVersion0();
            services.AddVersion1();
            services.AddVersion2();
            services.AddVersion3();
            services.AddVersion4();
            services.AddVersion5();
            services.AddVersion6();
            services.AddVersion7();
            services.AddVersion8();
            services.AddVersion9();
            services.AddVersion10();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Benchmark(Baseline = true)]
        public IReadOnlyCollection<GitHubRepositoryDto> Version0()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<GitHubClient>();
            return gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version1()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version1.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version2()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version2.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version3()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version3.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version4()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version4.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version5()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version5.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version6()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version6.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version7()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version7.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version8()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version8.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version9()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version9.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<GitHubRepositoryDto>> Version10()
        {
            var gitHubClient = _serviceProvider.GetRequiredService<JOSHttpClient.Version10.GitHubClient>();
            return await gitHubClient.GetRepositories(CancellationToken.None);
        }
    }
}
