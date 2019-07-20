using System;
using System.IO;
using System.Linq;

using AngleSharp;
using CommandLine;

using GalleryApplication.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GalleryApplication.Data.Common;

namespace ConsoleTester
{
    public static class Tester
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Tester).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            //var dbContext = serviceProvider.GetService<TestMvcDbContext>();
            // TODO : Writing tests here
            var a = Environment.GetEnvironmentVariable("testKey2",EnvironmentVariableTarget.Process);
            Console.WriteLine(a);

        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<GalleryAppContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}