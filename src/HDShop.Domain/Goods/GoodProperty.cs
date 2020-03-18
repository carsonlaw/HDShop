using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace HDShop.Goods
{
    public class GoodProperty : Entity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }

        public virtual GoodProperty? ParentGoodProperty { get; set; }
        public virtual IEnumerable<GoodProperty> ChildGoodProperties { get; set; }
    }
}