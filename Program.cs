using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace nettest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .ConfigureAppConfiguration((cntxt, configBuilder) =>
                {
                    configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile(path: $"appsettings.{cntxt.HostingEnvironment.EnvironmentName}.json",
                            optional: true, reloadOnChange: true)
                        .AddCommandLine(args);
                })
                .UseStartup<Startup>()
                .UseKestrel()
                .Build()
                .Run();
        }
    }
}
