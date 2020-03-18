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
        public Good(Guid id, string name, string code, string description, string imageBaseUrl, string[] imageUrls, 
            SaleState saleState, IEnumerable<GoodSku> goodSkus, IEnumerable<GoodPropertyMap> goodPropertieMaps, IEnumerable<GoodCategoryMap> goodCategoryMaps)
            : base(id)
        {
            Name = name;
            Code = code;
            Description = description;
            ImageBaseUrl = imageBaseUrl;
            ImageUrls = imageUrls;
            SaleState = saleState;
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

        //[NotMapped]
        //[Required]
        //public virtual string[] ImageUrls
        //{
        //    get { return ImageUrlsValue.Split(','); }
        //    set { ImageUrlsValue = string.Join(',', value); }
        //}

        public virtual SaleState SaleState { get; set; }


        #endregion

        #region 方法
        public int GetStocks()
        {
            return GoodSkus.Sum(f => f.Stock);
        }
        #endregion

        #region 导航属性

        public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }

        public virtual IEnumerable<GoodSku> GoodSkus { get; set; }

        public virtual IEnumerable<GoodPropertyMap> GoodPropertieMaps { get; set; }

        #endregion
    }
}
