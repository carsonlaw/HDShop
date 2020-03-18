using HDShop.Goods;
using HDShop.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
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
                b.ConfigureFullAuditedAggregateRoot();

            });
            builder.Entity<Good>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "Good", HDShopConsts.DbSchema);
                b.Property(f => f.SaleState.IsHot).HasColumnName("IsHot").HasColumnType("bit").IsRequired();
                b.Property(f => f.SaleState.IsNew).HasColumnName("IsNew").HasColumnType("bit").IsRequired();
                b.Property(f => f.SaleState.IsHot).HasColumnName("IsDiscount").HasColumnType("IsDiscount").IsRequired();
                b.Property(f => f.SaleState.IsHot).HasColumnName("IsRecommand").HasColumnType("IsRecommand").IsRequired();
                b.Property(f=>f.ImageUrls).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<GoodSku>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodSku", HDShopConsts.DbSchema);
                b.ConfigureFullAudited();
            });
            builder.Entity<GoodCategoryMap>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodCategoryMap", HDShopConsts.DbSchema);
                b.HasKey(f => new { f.GoodCategoryId, f.GoodId });

            });
            builder.Entity<GoodPropertyMap>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodPropertyMap", HDShopConsts.DbSchema);
                b.HasKey(f => new { f.GoodPropertyId, f.GoodId });

            });
            builder.Entity<GoodProperty>(b =>
                {
                    b.ToTable(HDShopConsts.DbTablePrefix + "GoodProperty", HDShopConsts.DbSchema);

                });
            builder.Entity<Order>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "Order", HDShopConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<OrderLine>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "OrderLine", HDShopConsts.DbSchema);
                
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}