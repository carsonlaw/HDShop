using System;
using System.Collections.Generic;
using System.Text;

namespace HDShop.Goods
{
    public class GoodSkuDto
    {
        public virtual string Code { get; set; }
        public virtual int Sort { get; set; }
        public virtual bool OnSale { get; set; }
        public virtual decimal PriceProduct { get; set; }
        public virtual decimal PriceSale { get; set; }
        public virtual int NumSales { get; set; }
        public virtual int Weight { get; set; }
        public virtual int Stock { get; set; }
    }
}
