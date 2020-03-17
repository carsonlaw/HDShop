using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [Obsolete]
        public string ImageUrlsValue { get; set; }

        [NotMapped]
        [Required]
        public virtual string[] ImageUrls
        {
            get { return ImageUrlsValue.Split(','); }
            set { ImageUrlsValue = string.Join(',', value); }
        }


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

        [Obsolete]
        public virtual int SaleStateValue { get; set; }

        public virtual IEnumerable<GoodSku> GoodSkus { get; set; }

        [NotMapped]
        public virtual IEnumerable<GoodProperty> GoodProperties { get; set; }

        #endregion

        #region 方法
        public int GetStocks()
        {
            return GoodSkus.Sum(f => f.Stock);
        }
        #endregion

        #region 导航属性

        public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }
        #endregion
    }
}
