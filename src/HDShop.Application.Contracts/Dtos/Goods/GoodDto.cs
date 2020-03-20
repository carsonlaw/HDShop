using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HDShop.Goods
{
    public class GoodDto : FullAuditedEntityDto<Guid>
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

        //[NotMapped]
        //[Required]
        //public virtual string[] ImageUrls
        //{
        //    get { return ImageUrlsValue.Split(','); }
        //    set { ImageUrlsValue = string.Join(',', value); }
        //}
        public virtual SaleStatesDto SaleStates { get; set; }


        #endregion

        #region 导航属性

        //public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }

        public virtual IEnumerable<GoodSkuDto> GoodSkus { get; set; }

        public virtual IEnumerable<GoodPropertyDto> GoodPropertieMaps { get; set; }

        #endregion
    }
}
