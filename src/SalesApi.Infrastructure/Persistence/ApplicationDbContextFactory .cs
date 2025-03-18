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
        //private readonly IConfiguration _configuration;

        //public ApplicationDbContextFactory(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=172.18.0.2;Port=8001;Database=SalesApiDb;Username=postgres;Password=admin;Timeout=60");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");
    //        optionsBuilder.UseNpgsql(connectionString);

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }
    //}
}
