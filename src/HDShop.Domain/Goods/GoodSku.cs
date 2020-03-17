using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDShop.Goods
{
    public class GoodSku : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(GoodSkuConsts.CodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 可用库存
        /// </summary>
        [Required]
        public virtual int Stock { get; set; }

        [NotMapped]
        public virtual IEnumerable<GoodProperty> GoodProperties { get; set; }
    }
}
