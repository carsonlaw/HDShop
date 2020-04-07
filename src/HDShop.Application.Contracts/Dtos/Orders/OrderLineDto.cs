using HDShop.Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HDShop.Orders
{
    public class OrderLineDto
    {
        [Required]
        public virtual int Quantity { get; set; }
        [Required]
        public virtual decimal Price { get; set; }


        #region 导航
        public virtual Guid GoodSkuId { get; set; }
        #endregion
    }
}
