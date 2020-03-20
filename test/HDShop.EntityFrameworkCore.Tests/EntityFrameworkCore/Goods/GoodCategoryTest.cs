using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Xunit;
using HDShop.EntityFrameworkCore;

namespace HDShop.Goods
{
    public class GoodCategoryTest : HDShopEntityFrameworkCoreTestBase
    {
        private readonly IRepository<GoodCategory, Guid> _Repository;

        public GoodCategoryTest()
        {
            _Repository = GetRequiredService<IRepository<GoodCategory, Guid>>();
            //_identityUserManager = GetRequiredService<IdentityUserManager>();
        }

        [Fact]
        public async Task Should_Query_GoodCategory()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                //Act
                var adminUser = await _Repository
                    .Where(f => f.Name == "休闲零食")
                    .FirstOrDefaultAsync();

                //Assert
                adminUser.ShouldNotBeNull();
            });
        }
    }
}
