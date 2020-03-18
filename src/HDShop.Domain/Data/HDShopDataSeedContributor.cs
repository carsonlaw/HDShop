using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using HDShop.Goods;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using System.Linq;

namespace HDShop.Data
{
    public class HDShopDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<GoodCategory,Guid> _repoGoodCategory;
        private readonly IRepository<GoodProperty, Guid> _repoGoodProperty;
        private readonly IRepository<Good, Guid> _repoGood;
        private Guid goodCategoryId;
        private Guid goodPropertyId;

        public HDShopDataSeedContributor(
            IGuidGenerator GuidGenerator,
            IRepository<GoodCategory, Guid> RepGoodCategory,
            IRepository<GoodProperty, Guid> RepGoodProperty,
            IRepository<Good, Guid> RepGood
            ) 
        {
            _guidGenerator = GuidGenerator;
            _repoGoodCategory = RepGoodCategory;
            _repoGoodProperty = RepGoodProperty;
            _repoGood = RepGood;
        }


        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await GoodCategroySeedAsync();
            await GoodPropertySeedAsync();
            await GoodSeedAsync();
        }

        private async Task GoodPropertySeedAsync()
        {
            var num = await _repoGoodProperty.GetCountAsync();

            throw new NotImplementedException();
        }

        private async Task GoodCategroySeedAsync()
        {
            var num = await _repoGoodCategory.GetCountAsync();
            if (num == 0)
            {
                goodCategoryId = _guidGenerator.Create();
                var entity = new GoodCategory(
                    goodCategoryId,
                    "休闲零食",
                    "ls",
                    "",
                    "",
                    null,
                    null
                    );
                entity = await _repoGoodCategory.InsertAsync(entity);
            }
        }
        private async Task GoodSeedAsync()
        {
            var num = await _repoGood.GetCountAsync();
            if (num == 0)
            {
                var entity = new Good(
                    _guidGenerator.Create(),
                    "风干牛肉",
                    "ls001",
                    "风干牛肉",
                    "",
                    new string[] { "1.png","2.png"},
                    new SaleState(),
                    new List<GoodSku>() { new GoodSku(
                        _guidGenerator.Create(),
                        "h",
                        1,
                        true,
                        21,
                        30,
                        25,
                        200,
                        1000                        
                        ) },
                    new List<GoodPropertyMap>() { new GoodPropertyMap() { Sort = 1, GoodPropertyId = goodPropertyId } },
                    new List<GoodCategoryMap>() { new GoodCategoryMap() { GoodCategoryId = goodCategoryId } }
                    );
                entity = await _repoGood.InsertAsync(entity);

            }
    }
}
