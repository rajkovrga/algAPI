﻿using Alg.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Alg.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            string driver,
            string connectionString
        )
        {
            return services.AddDbContext<DataContext>(options =>
            {
                ConfigureDbContext(options, driver, connectionString);
            })
                .AddTransient<IDataContext, DataContext>();

        }

        public static void ConfigureDbContext(DbContextOptionsBuilder options, string driver,
            string connectionString)
        {
            switch (driver.ToLower())
            {
                case "sqlserver":
                    options.UseSqlServer(connectionString);
                    break;
            }
        }
    }
}
