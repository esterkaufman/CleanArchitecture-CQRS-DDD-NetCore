using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Moj.Keshet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder

                    //.UseKestrel(serverOptions =>
                    //{
                    //    serverOptions.AllowSynchronousIO = true;
                    //})

                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                })
                .Build();

            host.Run();
        }
    }
}
