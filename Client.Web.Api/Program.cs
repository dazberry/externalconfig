using System;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.External;

namespace Client.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var configurationKey = config["key"];

            return WebHost.CreateDefaultBuilder(args)
                .UseExternalConfiguration(
                    HttpMethod.Post,
                    new Uri("https://localhost:44308/api/configuration"),
                    new { key = configurationKey },
                    "application/json")
                .UseStartup<Startup>();
        }
    }
}
