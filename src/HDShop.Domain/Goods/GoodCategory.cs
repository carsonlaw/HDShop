﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Goods
{
    public class GoodCategory : FullAuditedAggregateRoot<Guid>
    {
        protected GoodCategory()
        { }
        public GoodCategory(Guid id,string name,string code,string description,string goodDescription, GoodCategory? parentCategory, IEnumerable<GoodCategory> childCategorys)
            :base(id)
        {
            Name = name;
            Code = code;
            Description = description;
            GoodDescription = goodDescription;
            ParentCategory = parentCategory;
            ChildCategorys = childCategorys;
        }
        
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
        public virtual GoodCategory? ParentCategory { get; set; }
#pragma warning restore CS8632 // 只能在 "#nullable" 注释上下文内的代码中使用可为 null 的引用类型的注释。
        public virtual IEnumerable<GoodCategory> ChildCategorys { get; set; }
        //public virtual IEnumerable<GoodCategoryMap> GoodCategoryMaps { get; set; }
        public virtual IEnumerable<Good> Goods { get; set; }
        #endregion
    }
}
