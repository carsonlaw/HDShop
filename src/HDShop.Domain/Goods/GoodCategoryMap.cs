using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Goods
{
    public class GoodCategoryMap
    {
        public GoodCategory GoodCategory { get; set; }
        public Good Good { get; set; }
        public Guid GoodCategoryId { get; set; }
        public Guid GoodId { get; set; }
    }
}
