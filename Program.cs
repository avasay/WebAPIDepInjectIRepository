using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPIInMemoryDBSeededIRepository.Models;

namespace WebAPIInMemoryDBSeededIRepository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

            // Get the service layer
            using (var scope = host.Services.CreateScope())
            {
                // Get our service layer, EmployeeRepository (see Startup)
                var services = scope.ServiceProvider;

                // Inject EmployeeContext into our service 
                var context = services.GetRequiredService<EmployeeDBContext>();

                // Seed the database
                //EmployeeDBInitializer.Seed(services);
                EmployeeDBInitializer.Seed(context);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
