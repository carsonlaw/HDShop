using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using HDShop.Users;

namespace HDShop.Orders
{
    public class Order : FullAuditedAggregateRootWithUser<Guid, AppUser>
    {
        protected Order() { }
        public Order(Guid id)
            :base(id)
        {
        }

        #region 属性

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(OrderConsts.CodeLength)]
        public virtual string Code { get; set; }

        [NotMapped]
        public virtual decimal OrderPrice
        {
            get
            {
                return OrderLines.Sum(f => f.Price * f.Quantity);
            }
        }


        [Required]
        public virtual OrderStatus OrderStatus { get; set; }

        #endregion

        #region 方法

        

        #endregion

        #region 导航属性

        public virtual IEnumerable<OrderLine> OrderLines { get; set; }

        public virtual OrderDeliverAddressMap DeliverAddressMap { get; set; }

        public virtual PayOrder? PayOrder { get; set; }
        public virtual DeliverOrder? DeliverOrder { get; set; }

        #endregion
    }
}
