using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HDShop.Dtos.Users
{
    public class AppUserDto : FullAuditedAggregateRoot<Guid>
    {
    }
}
