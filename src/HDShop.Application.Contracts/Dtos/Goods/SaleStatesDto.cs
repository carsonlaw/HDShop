using System;
using System.Collections.Generic;
using System.Text;

namespace HDShop.Goods
{
    public class SaleStatesDto
    {
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool IsDiscount { get; set; }
        public bool IsRecommand { get; set; }
    }
}
