using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Values;
namespace HDShop.Goods
{
    public class SaleStates : ValueObject
    {
        public SaleStates() { }
        public SaleStates(bool isHot = false, bool isNew = false, bool isDisscount = false, bool isRecommand = false)
        {
            IsHot = isHot;
            IsNew = isNew;
            IsDiscount = isDisscount;
            IsRecommand = isRecommand;
        }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool IsDiscount { get; set; }
        public bool IsRecommand { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return IsHot;
            yield return IsNew;
            yield return IsDiscount;
            yield return IsRecommand;
        }
    }
}