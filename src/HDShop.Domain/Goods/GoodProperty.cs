using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Goods
{
    public class GoodProperty : FullAuditedAggregateRoot<Guid>
    {
        protected GoodProperty() { 
        }
        public GoodProperty(Guid id,string name,string code,GoodProperty? parentGoodProperty,int sort,IEnumerable<GoodProperty> childGoodProperty)
            :base(id)
        {
            Name = name;
            Code = code;
            Sort = sort;
            ParentGoodProperty = parentGoodProperty;
            ChildGoodProperties = childGoodProperty;
        }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public int Sort { get; set; }

        public virtual GoodProperty? ParentGoodProperty { get; set; }
        public virtual IEnumerable<GoodProperty> ChildGoodProperties { get; set; }
        public virtual IQueryable<Good> Goods { get; set; }
    }
}