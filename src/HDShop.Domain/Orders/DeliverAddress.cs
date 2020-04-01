using HDShop.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Orders
{
    public class DeliverAddress : FullAuditedEntityWithUser<Guid, AppUser>
    {
        [Required]
        [StringLength(AddressConsts.NameLength)]
        public virtual string Name { get; set; }
        [Required]
        [RegularExpression(AddressConsts.PhoneReg)]
        public virtual string Phone { get; set; }
        [Required]
        [StringLength(AddressConsts.AddressLength)]
        public virtual string Address { get; set; }
    }
}
