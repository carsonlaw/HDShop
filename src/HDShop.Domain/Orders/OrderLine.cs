using HDShop.Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
namespace HDShop.Orders
{
    public class OrderLine : Entity
    {
        protected OrderLine()
        {
        }

        internal OrderLine(Guid orderId, Guid goodSkuId, int quantity,decimal price)
        {
            OrderId = orderId;
            GoodSkuId = goodSkuId;
            Price = price;
            Quantity = quantity;
        }

        #region
        [Required]
        public virtual int Quantity { get; set; }
        [Required]
        public virtual decimal Price { get; set; }
        #endregion

        #region 导航
        public virtual GoodSku GoodSku { get; set; }
        public virtual Guid GoodSkuId { get; set; }
        public virtual Guid OrderId { get; set; }

        public override object[] GetKeys()
        {
            return new Object[] { OrderId, GoodSkuId };
        }
        #endregion
    }
}