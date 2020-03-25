using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Orders
{
    public class DeliverCompany : FullAuditedAggregateRoot<Guid>
    {
        protected DeliverCompany() { }
        public DeliverCompany(string code, string name)
        {
            Code = code;
            Name = name;
        }
        [Required]
        [StringLength(DeliverCompanyConsts.CodeLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(DeliverCompanyConsts.NameLength)]
        public string Name { get; set; }
    }
}
