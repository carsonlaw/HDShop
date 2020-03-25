using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Orders
{
    public class PayCompany : FullAuditedAggregateRoot<Guid>
    {
        protected PayCompany() { }
        public PayCompany(string code,string name)
        {
            Code = code;
            Name = name;
        }
        [Required]
        [StringLength(PayCompanyConsts.CodeLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(PayCompanyConsts.CodeLength)]
        public string Name { get; set; }
    }
}
