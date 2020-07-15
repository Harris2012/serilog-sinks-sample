using System;
using Serilog;

namespace UseSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Sample()
                .CreateLogger();

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;

            log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

            Console.WriteLine("Hello World!");
        }
    }
}
