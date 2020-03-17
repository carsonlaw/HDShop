using HDShop.Goods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace HDShop.EntityFrameworkCore
{
    public static class HDShopDbContextModelCreatingExtensions
    {
        public static void ConfigureHDShop(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<GoodCategory>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodCategory", HDShopConsts.DbSchema);
                b.ConfigureAuditedAggregateRoot();

            });
            builder.Entity<Good>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "Good", HDShopConsts.DbSchema);
                b.ConfigureAuditedAggregateRoot();
            });
            builder.Entity<GoodSku>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodSku", HDShopConsts.DbSchema);
                b.ConfigureFullAudited();
            });
            builder.Entity<GoodCategoryMap>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodCategoryMap", HDShopConsts.DbSchema);
                b.HasKey(f => new { f.CategoryId, f.GoodId });

            });
            builder.Entity<GoodProperty>(b =>
                {
                    b.ToTable(HDShopConsts.DbTablePrefix + "GoodProperty", HDShopConsts.DbSchema);

                });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}