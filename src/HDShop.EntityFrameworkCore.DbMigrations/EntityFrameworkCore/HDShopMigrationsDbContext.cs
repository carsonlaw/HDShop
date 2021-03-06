﻿using HDShop.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace HDShop.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See HDShopDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class HDShopMigrationsDbContext : AbpDbContext<HDShopMigrationsDbContext>
    {
        public HDShopMigrationsDbContext(DbContextOptions<HDShopMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureHDShop();
            base.OnModelCreating(builder);
            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure customizations for entities from the modules included  */

            //builder.Entity<IdentityUser>(b =>
            //{
            //    b.ConfigureCustomUserProperties();
            //});
            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers");
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                b.HasOne<IdentityUser>().WithOne().HasForeignKey<AppUser>(e => e.Id);

                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureHDShop method */
            //builder.ConfigureHDShop();
        }
    }
}