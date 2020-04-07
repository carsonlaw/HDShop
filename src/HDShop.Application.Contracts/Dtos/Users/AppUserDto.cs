using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Users
{
    public class AppUserDto : FullAuditedAggregateRoot<Guid>
    {
    }
}
