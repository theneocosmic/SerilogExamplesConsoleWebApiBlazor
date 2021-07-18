using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace SerilogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();


            try
            {
                Log.Debug("Application is startating...");
                Log.Information("Hello {Name}!", Environment.GetEnvironmentVariable("USERNAME"));
                Log.Warning("Yo should not be allowed here");

                ThrowError();
            }
            catch (Exception e)
            {

                Log.Error(e, "Something went wrong");
            }

            Log.CloseAndFlush();


        }


        static void ThrowError()
        {
            throw new NullReferenceException();
        }

    }
}
