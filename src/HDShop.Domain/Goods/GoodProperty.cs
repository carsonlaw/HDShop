using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Goods
{
    public class GoodProperty : FullAuditedAggregateRoot<Guid>
    {
        protected GoodProperty() { 
        }
        public GoodProperty(Guid id,string name,string code,GoodProperty? parentGoodProperty,IEnumerable<GoodProperty> childGoodProperty)
            :base(id)
        {
            Name = name;
            Code = code;
            ParentGoodProperty = parentGoodProperty;
            ChildGoodProperties = childGoodProperty;
        }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }

        public virtual GoodProperty? ParentGoodProperty { get; set; }
        public virtual IEnumerable<GoodProperty> ChildGoodProperties { get; set; }
    }
}