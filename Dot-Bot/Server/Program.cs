using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotBot.Server.Bot;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotBot.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await BotManager.SetUp();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
