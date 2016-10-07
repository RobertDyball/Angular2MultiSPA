using Angular2MultiSPA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace Angular2MultiSPA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseUrls("http://*:7010/")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            ProcessDbCommands(args, host);

            host.Run();
        }

        /// <summary>
        /// Process Database commands
        /// </summary>
        /// <remarks>
        /// from K. Scott Allen's blog: http://odetocode.com/blogs/scott/archive/2016/09/20/database-migrations-and-seeding-in-asp-net-core.aspx
        /// </remarks>
        /// <param name="args">dotnet run arguments</param>
        /// <param name="host"></param>
        private static void ProcessDbCommands(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                if (args.Contains("dropdb"))
                {
                    Console.WriteLine("Dropping database");
                    var db = ApplicationDb(scope);
                    db.Database.EnsureDeleted();
                }
                if (args.Contains("migratedb"))
                {
                    Console.WriteLine("Migrating database");
                    var db = ApplicationDb(scope);
                    db.Database.Migrate();
                }
                if (args.Contains("seeddb"))
                {
                    Console.WriteLine("Seeding database");
                    var db = ApplicationDb(scope);
                    db.Seed();
                }
            }
        }

        private static ApplicationDbContext ApplicationDb(IServiceScope services)
        {
            var db = services.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db;
        }
    }
}
