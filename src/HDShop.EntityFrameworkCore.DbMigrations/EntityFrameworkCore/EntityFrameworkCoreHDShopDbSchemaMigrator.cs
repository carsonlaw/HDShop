using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HDShop.Data;
using Volo.Abp.DependencyInjection;

namespace HDShop.EntityFrameworkCore
{
    public class EntityFrameworkCoreHDShopDbSchemaMigrator
        : IHDShopDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHDShopDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HDShopMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HDShopMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}