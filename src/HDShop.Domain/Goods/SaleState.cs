using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Values;
namespace HDShop.Goods
{
    public class SaleState : ValueObject
    {
        public bool IsHot { get; set; } = false;
        public bool IsNew { get; set; } = false;
        public bool IsDiscount { get; set; } = false;
        public bool IsRecommand { get; set; } = false;
        protected override IEnumerable<object> GetAtomicValues()
        {
            var ret = new bool[] { IsHot, IsNew, IsDiscount, IsRecommand };
            return ret.Select(f=>(object)f).AsEnumerable();
        }
    }
}