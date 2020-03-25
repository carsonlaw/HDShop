using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Values;
using Volo.Abp.Timing;

namespace HDShop.Orders
{
    public class PayOrder : ValueObject,IHasCreationTime
    {
        protected PayOrder() { }
        public PayOrder(string code, decimal payPrice)
        {
            Code = code;
            PayPrice = payPrice;
        }

        [Required]
        [StringLength(PayOrderConsts.CodeLength)]
        public virtual string Code { get; set; }
        [Required]
        public virtual decimal PayPrice { get; set; }
        public virtual DateTime CreationTime { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return PayPrice;
            yield return CreationTime;
        }
    }
}
