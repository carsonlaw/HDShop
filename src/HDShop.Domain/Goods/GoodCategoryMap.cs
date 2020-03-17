using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Goods
{
    public class GoodCategoryMap
    {
        public GoodCategory Category { get; set; }

        public Good Good { get; set; }
        public Guid CategoryId { get; set; }
        public Guid GoodId { get; set; }
    }
}
