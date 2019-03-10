using BenchmarkDotNet.Running;

namespace JOS.HttpClient.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<JOSGetAllProjectsQueryBenchmark>();
        }
    }
}
