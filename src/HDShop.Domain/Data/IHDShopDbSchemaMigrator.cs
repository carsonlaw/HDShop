using System.Threading.Tasks;

namespace HDShop.Data
{
    public interface IHDShopDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
