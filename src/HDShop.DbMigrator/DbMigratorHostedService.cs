using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HDShop.Data;
using Serilog;
using Volo.Abp;

namespace HDShop.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<HDShopDbMigratorModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                application.Initialize();

                await application
                    .ServiceProvider
                    .GetRequiredService<HDShopDbMigrationService>()
                    .MigrateAsync();

                application.Shutdown();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
