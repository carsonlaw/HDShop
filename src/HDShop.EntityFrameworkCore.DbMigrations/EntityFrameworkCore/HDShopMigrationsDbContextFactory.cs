﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HDShop.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class HDShopMigrationsDbContextFactory : IDesignTimeDbContextFactory<HDShopMigrationsDbContext>
    {
        public HDShopMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HDShopMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));

            return new HDShopMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
