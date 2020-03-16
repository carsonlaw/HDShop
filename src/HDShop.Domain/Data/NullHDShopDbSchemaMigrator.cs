using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HDShop.Data
{
    /* This is used if database provider does't define
     * IHDShopDbSchemaMigrator implementation.
     */
    public class NullHDShopDbSchemaMigrator : IHDShopDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}