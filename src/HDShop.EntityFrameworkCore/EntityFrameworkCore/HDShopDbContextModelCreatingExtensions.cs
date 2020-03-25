using HDShop.Goods;
using HDShop.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var stringArrayComparer = new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToHashSet().ToArray());

            #region Good
            builder.Entity<GoodCategory>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "GoodCategory", HDShopConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

            });
            builder.Entity<Good>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "Good", HDShopConsts.DbSchema);
                b.ConfigureByConvention();
                b.OwnsOne(f => f.SaleStates);
                b.Property(f => f.ImageUrls).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Metadata.SetValueComparer(stringArrayComparer);
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
                    b.ConfigureByConvention();
                });
            #endregion

            #region Order
            builder.Entity<Order>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "Order", HDShopConsts.DbSchema);
                b.ConfigureByConvention();
                b.OwnsOne(f => f.PayOrder);
                b.OwnsOne(f => f.DeliverOrder);
            });
            builder.Entity<OrderLine>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "OrderLine", HDShopConsts.DbSchema);

            });
            builder.Entity<OrderDeliverAddressMap>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "OrderDeliverAddressMap", HDShopConsts.DbSchema);
                b.HasKey(f => new { f.DeliverAddressId, f.OrderId });

            });
            builder.Entity<DeliverCompany>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "DeliverCompany", HDShopConsts.DbSchema);
                b.ConfigureByConvention();

            });
            builder.Entity<DeliverAddress>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "DeliverAddress", HDShopConsts.DbSchema);
                b.ConfigureByConvention();

            });
            builder.Entity<PayCompany>(b =>
            {
                b.ToTable(HDShopConsts.DbTablePrefix + "PayCompany", HDShopConsts.DbSchema);
                b.ConfigureByConvention();

            });
            #endregion
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}