using System;
using System.Collections.Generic;
using System.Text;

namespace HDShop.Goods
{
    public class GoodPropertyDto
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public int Sort { get; set; }

        public virtual GoodPropertyDto? ParentGoodProperty { get; set; }
        public virtual IEnumerable<GoodPropertyDto> ChildGoodProperties { get; set; }
    }
}
