using BenchmarkDotNet.Running;

namespace JOS.HttpClient.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary1 = BenchmarkRunner.Run<JOSHttpClientBenchmark>();
            var summary2 = BenchmarkRunner.Run<JOSGetAllProjectsQueryBenchmark>();
        }
    }
}
