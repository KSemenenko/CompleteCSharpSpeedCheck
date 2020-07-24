using BenchmarkDotNet.Running;

namespace CompleteCSharpSpeedCheck
{
    public class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}