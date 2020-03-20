using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HDShop.Goods
{
    public class GoodCategoryDto : FullAuditedEntityDto<Guid>
    {
        #region 属性
        [Required]
        [StringLength(GoodCategoryConsts.NameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(GoodCategoryConsts.CodeLength)]
        public virtual string Code { get; set; }

        [StringLength(GoodCategoryConsts.DescriptionLength)]
        public virtual string Description { get; set; }

        [StringLength(GoodCategoryConsts.GoodDescriptionLength)]
        public virtual string GoodDescription { get; set; }
        #endregion

        #region 导航属性

#pragma warning disable CS8632 // 只能在 "#nullable" 注释上下文内的代码中使用可为 null 的引用类型的注释。
        public virtual GoodCategoryDto? ParentCategory { get; set; }
#pragma warning restore CS8632 // 只能在 "#nullable" 注释上下文内的代码中使用可为 null 的引用类型的注释。
        public virtual IEnumerable<GoodCategoryDto> ChildCategorys { get; set; }
        //public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }
        #endregion
    }
}
