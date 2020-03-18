using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDShop.Goods
{
    public class GoodSku : FullAuditedEntity<Guid>
    {
        protected GoodSku() { }
        public GoodSku(Guid id,string code,int sort, bool onSale, decimal priceCost, decimal priceProduct, decimal priceSale, int weight, int stock)
            :base(id)
        {
            Code = code;
            Sort = sort;
            OnSale = onSale;
            PriceCost = priceCost;
            PriceProduct = priceProduct;
            PriceSale = priceSale;
            Weight = weight;
            Stock = stock;
        }
        #region 属性
        [Required]
        [StringLength(GoodSkuConsts.CodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public virtual int Sort { get; set; }

        /// <summary>
        /// 上架
        /// </summary>
        [Required]
        public virtual bool OnSale { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal PriceCost { get; set; }

        /// <summary>
        /// 产品原价
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal PriceProduct { get; set; }

        /// <summary>
        /// 现价
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal PriceSale { get; set; }

        /// <summary>
        /// 售出数量
        /// </summary>
        [Required]
        public virtual int NumSales { get; set; }

        /// <summary>
        /// 真实销售数量
        /// </summary>
        [Required]
        public virtual int NumSalesReal { get; set; }

        /// <summary>
        /// 单个重量
        /// </summary>
        [Required]
        public virtual int Weight { get; set; }

        /// <summary>
        /// 可用库存
        /// </summary>
        [Required]
        public virtual int Stock { get; set; }

        #endregion

        #region 方法
        public void SetStockAdd(int num)
        {
            if (Stock + num < 0)
            {
                throw new Exception("no stock");
            }
            Stock += num;
        }
        #endregion

    }
}
