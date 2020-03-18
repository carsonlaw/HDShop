using System;

namespace HDShop.Goods
{
    public class GoodPropertyMap
    {
        public GoodProperty GoodProperty { get; set; }
        public Good Good { get; set; }
        public Guid GoodPropertyId { get; set; }
        public Guid GoodId { get; set; }
        public int Sort { get; set; }
    }
}