using Serilog;
using System;

namespace SerilogAppFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ext.david.dzul\source\repos\SerilogAppFile\Logs\";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(path + "log")
                .MinimumLevel.Verbose()
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
