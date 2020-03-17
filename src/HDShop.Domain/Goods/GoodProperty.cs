using System;

namespace HDShop.Goods
{
    public class GoodProperty
    {
        public virtual Guid Id { get; set; }
        public virtual string TypeName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
    }
}