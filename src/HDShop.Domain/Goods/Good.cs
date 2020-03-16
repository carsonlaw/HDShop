using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.Text;

namespace HDShop.Goods
{
    public class Good : FullAuditedAggregateRoot<Guid>
    {
        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(GoodConsts.NameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(GoodConsts.CodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 描述富文本
        /// </summary>
        [Required]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(GoodConsts.ImageBaseUrlLength)]
        public virtual string ImageBaseUrl { get; set; }

        [Required]
        public virtual string[] ImageUrls { get; set; }

        /// <summary>
        /// 可用库存
        /// </summary>
        [Required]
        public virtual int Stock { get; set; }

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
        public virtual decimal PriceCost { get; set; }

        /// <summary>
        /// 产品原价
        /// </summary>
        [Required]
        public virtual decimal PriceProduct { get; set; }

        /// <summary>
        /// 现价
        /// </summary>
        [Required]
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
        /// 销售状态
        /// </summary>
        public virtual IEnumerable<SaleState> SaleState { get; set; }

        #endregion


        #region 导航属性

        public virtual IEnumerable<GoodCategory> Categories { get; set; }
        #endregion
    }
}
