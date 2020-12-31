using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace ProductInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureKestrel(options =>
                        {
                            // only needed on Mac due to a bug, visit visit https://go.microsoft.com/fwlink/?linkid=2099682
                            options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2);
                            
                            // for /proto Rest endpoint
                            options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http1);
                        })
                        .UseStartup<Startup>();
                });
    }
}