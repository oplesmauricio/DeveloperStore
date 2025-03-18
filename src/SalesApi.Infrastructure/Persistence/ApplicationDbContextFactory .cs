using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SalesApi.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=SalesApiDb;Username=postgres;Password=admin"); //este host nao eh conhecido ao executar dotnet ef database update

            //ip do db no docker
            optionsBuilder.UseNpgsql("Host=172.18.0.2;Port=5432;Database=SalesApiDb;Username=postgres;Password=admin;Timeout=60"); //Timeout during connection attempt ao executar dotnet ef database update mesmo aumentando para 60

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
