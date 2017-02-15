using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace Dorner.Net.Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            
            var host = new WebHostBuilder()
                
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(options => {
                    //options.NoDelay = false;
                    //options.ThreadCount = 25;
                    //options.UseHttps("testCert.pfx", "testPassword");
                })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
