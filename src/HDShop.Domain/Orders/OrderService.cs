using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Domain.Repositories;
using HDShop.Goods;
using Volo.Abp.Linq;
using Volo.Abp;

namespace HDShop.Orders
{
    public class OrderService : DomainService , ITransientDependency
    {
        private ICodeGenerator _codeGenerator;
        private IRepository<Good, Guid> _repGood;
        public IAsyncQueryableExecuter AsyncQueryableExecuter
        {
            get;
            set;
        }
        public ICodeGenerator CodeGenerator => LazyGetRequiredService(ref _codeGenerator);
        public IRepository<Good, Guid> RepoGood => LazyGetRequiredService(ref _repGood);

        /// <summary>
        /// 如果订单号为空，则生成订单号
        /// </summary>
        /// <param name="entitiy"></param>
        public async Task SetCodeIfNull(Order entitiy)
        {
            if (string.IsNullOrWhiteSpace(entitiy.Code))
                entitiy.Code = await CodeGenerator.Next();
        }

        /// <summary>
        /// 重新计算订单的价格
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CalcOrderPrice(Order entity)
        {
            var ids = entity.OrderLines.Select(f => f.GoodSkuId);
            var goodSkus = await AsyncQueryableExecuter.ToListAsync(RepoGood.SelectMany(f => f.GoodSkus).Where(f => ids.Contains(f.Id))).ConfigureAwait(continueOnCapturedContext: false);
            foreach (var line in entity.OrderLines)
            {
                var goodSku = goodSkus.FirstOrDefault(f => f.Id == line.GoodSkuId);
                if (goodSku == null) 
                    throw new BusinessException(HDShopDomainErrorCodes.NoGoodSku).WithData("SkuId",line.GoodSkuId);
                line.Price = goodSku.PriceSale;
            }
        }

        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task SetOrderConfirmed(Order entity)
        {
            if(entity.OrderStatus != OrderStatus.Init)
                throw new BusinessException(HDShopDomainErrorCodes.OrderCantConfirm).WithData("OrderCode", entity.Code);
            entity.OrderStatus = OrderStatus.Confirmed;

            var ids = entity.OrderLines.Select(f => f.GoodSkuId);
            var goodSkus = await AsyncQueryableExecuter.ToListAsync(RepoGood.SelectMany(f => f.GoodSkus).Where(f => ids.Contains(f.Id))).ConfigureAwait(continueOnCapturedContext: false);
            foreach (var line in entity.OrderLines)
            {
                var goodSku = goodSkus.FirstOrDefault(f => f.Id == line.GoodSkuId);
                if (goodSku == null)
                    throw new BusinessException(HDShopDomainErrorCodes.NoGoodSku).WithData("SkuId", line.GoodSkuId);
                goodSku.SetStockAdd(-line.Quantity);
            }

        }

        /// <summary>
        /// 订单取消确认
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task SetOrderCanceled(Order entity)
        {
            var needStock = false;
            if (entity.OrderStatus != OrderStatus.Init)
                needStock = true;
            entity.OrderStatus = OrderStatus.Canceled;
            if (!needStock) return;
            
            var ids = entity.OrderLines.Select(f => f.GoodSkuId);
            var goodSkus = await AsyncQueryableExecuter.ToListAsync(RepoGood.SelectMany(f => f.GoodSkus).Where(f => ids.Contains(f.Id))).ConfigureAwait(continueOnCapturedContext: false);
            foreach (var line in entity.OrderLines)
            {
                var goodSku = goodSkus.FirstOrDefault(f => f.Id == line.GoodSkuId);
                if (goodSku == null)
                    throw new BusinessException(HDShopDomainErrorCodes.NoGoodSku).WithData("SkuId", line.GoodSkuId);
                goodSku.SetStockAdd(line.Quantity);
            }
        }

    }
}
