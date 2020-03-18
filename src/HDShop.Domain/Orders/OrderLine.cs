using HDShop.Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
namespace HDShop.Orders
{
    public class OrderLine : Entity<Guid>
    {
        #region
        [Required]
        public virtual int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal Price { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal PriceTotal { get; set; }
        #endregion

        #region 导航
        public virtual GoodSku GoodSku { get; set; }
        public virtual Order Order { get; set; }
        #endregion
    }
}