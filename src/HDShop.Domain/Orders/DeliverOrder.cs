using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Values;

namespace HDShop.Orders
{
    public class DeliverOrder : ValueObject,IHasCreationTime
    {
        protected DeliverOrder() { }
        public DeliverOrder(string code, DeliverCompany deliverCompany)
        {
            Code = code;
            DeliverCompany = deliverCompany;
        }

        [Required]
        [StringLength(DeliverOrderConsts.CodeLength)]
        public virtual string Code { get; set; }

        public virtual DeliverCompany DeliverCompany { get; set; }
        public DateTime CreationTime { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return CreationTime;
            yield return DeliverCompany;
        }
    }
}
