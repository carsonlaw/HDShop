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
        protected Good() { }
        public Good(Guid id, string name, string subName, string code, string description, string imageBaseUrl, string[] imageUrls, 
            SaleStates saleStates, IEnumerable<GoodSku> goodSkus, IEnumerable<GoodPropertyMap> goodPropertieMaps, IEnumerable<GoodCategoryMap> goodCategoryMaps)
            : base(id)
        {
            Name = name;
            SubName = subName;
            Code = code;
            Description = description;
            ImageBaseUrl = imageBaseUrl;
            ImageUrls = imageUrls;
            SaleStates = saleStates;
            GoodSkus = goodSkus;
            GoodPropertieMaps = goodPropertieMaps;
            GoodCategoryMaps = goodCategoryMaps;
        }

        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(GoodConsts.NameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(GoodConsts.SubNameLength)]
        public virtual string SubName { get; set; }

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

        public virtual SaleStates SaleStates { get; set; }

        [NotMapped]
        public virtual int Stock
        {
            get
            {
                return GoodSkus.Where(f=>f.OnSale).Sum(f => f.Stock);
            }
        }
        [NotMapped]
        public virtual decimal MinPrice
        {
            get
            {
                return GoodSkus.Where(f => f.OnSale).Min(f => f.PriceSale);
            }
        }
        [NotMapped]
        public virtual decimal MinPriceProduct
        {
            get
            {
                return GoodSkus.Where(f => f.OnSale).OrderByDescending(f => f.PriceSale).FirstOrDefault().PriceProduct;
            }
        }
        [NotMapped]
        public virtual int NumSales
        {
            get
            {
                return GoodSkus.Sum(f => f.NumSales);
            }
        }
        [NotMapped]
        public virtual bool OnSale
        {
            get
            {
                return GoodSkus.Any(f => f.OnSale);
            }
        }

        #endregion

        #region 方法

        #endregion

        #region 导航属性

        public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }

        public virtual IEnumerable<GoodSku> GoodSkus { get; set; }

        public virtual IEnumerable<GoodPropertyMap> GoodPropertieMaps { get; set; }

        #endregion
    }
}
