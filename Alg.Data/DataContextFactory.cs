
using System;
using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Alg.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            ServiceCollectionExtensions.ConfigureDbContext(optionsBuilder, "sqlserver",
                configuration.GetConnectionString("DefaultConnection"));
            return new DataContext(optionsBuilder.Options);
        }
    
    }
}
