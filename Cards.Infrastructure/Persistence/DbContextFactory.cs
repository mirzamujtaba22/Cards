using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure.Persistence
{
    public class CardsContextFactory : IDesignTimeDbContextFactory<CardsDbContext>
    {
        public CardsDbContext CreateDbContext(string[] args)
        {
            var path = args.SingleOrDefault();
            if (path == null)
            {
                throw new ArgumentNullException(nameof(args), "Please specify the path to appsettings*.json files");
            }

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("CardsDbConnectionString");

            var dbContextBuilder = new DbContextOptionsBuilder<CardsDbContext>();
            dbContextBuilder.UseSqlServer(connectionString);

            return new CardsDbContext(dbContextBuilder.Options);
        }
    }
}
