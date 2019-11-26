using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using JOSHttpClient.Common.Domain;
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
using Microsoft.Extensions.DependencyInjection;
using GetAllProjectsQuery = JOSHttpClient.Version0.GetAllProjectsQuery;

namespace JOS.HttpClient.Benchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, invocationCount: 50)]
    public class JOSGetAllProjectsQueryBenchmark
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

            _serviceProvider = services.BuildServiceProvider();
        }

        [Benchmark(Baseline = true)]
        public IReadOnlyCollection<Project> Version0()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<GetAllProjectsQuery>();
            return getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version1()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version1.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version2()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version2.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version3()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version3.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version4()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version4.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version5()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version5.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version6()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version6.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version7()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version7.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version8()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version8.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }

        [Benchmark]
        public async Task<IReadOnlyCollection<Project>> Version9()
        {
            var getAllProjectsQuery = _serviceProvider.GetRequiredService<JOSHttpClient.Version9.GetAllProjectsQuery>();
            return await getAllProjectsQuery.Execute();
        }
    }
}
