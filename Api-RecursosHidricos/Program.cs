using Api_RecursosHidricos.AppContext;
using Api_RecursosHidricos.Repository;
using Api_RecursosHidricos.Repository.Impl;
using Api_RecursosHidricos.Services;
using Api_RecursosHidricos.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Api_RecursosHidricos
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
                    webBuilder.UseStartup<Startup>();
                });
    }
}


