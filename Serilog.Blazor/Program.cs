using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Serilog.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Creamos configuración del logger
            string pathFile = @"C:\Users\ext.david.dzul\source\repos\SerilogTest\Serilog.Blazor\Log\log.text";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(pathFile,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message:lj} {NewLine} {Exception}")
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Se pone aqui para que el serilog este en toda la aplicacion Blazor
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
