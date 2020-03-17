using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Xunit;

namespace HDShop.Goods
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IdentityUserManager here).
     * Only test your own domain services.
     */
    public class GoodCategoryTest : HDShopDomainTestBase
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
                    .Where(f => f.Name == "测试分类")
                    .FirstOrDefaultAsync();

                //Assert
                adminUser.ShouldNotBeNull();
            });
        }
    }
}
