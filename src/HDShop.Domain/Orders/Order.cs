using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDShop.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        #region 属性
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(OrderConsts.CodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(OrderConsts.UserIdLength)]
        public virtual string UserId { get; set; }
        [Required]
        [StringLength(OrderConsts.UserNameLength)]
        public virtual string UserName { get; set; }

        [NotMapped]
        public virtual decimal OrderPrice
        {
            get
            {
                return OrderLines.Sum(f => f.PriceTotal);
            }
        }

        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal PayPrice { get; set; }

        public virtual DateTime PayTime { get; set; }

        [Required]
        public virtual OrderStatus OrderStatus { get; set; }

        #endregion

        #region 方法
        public void SetConfirmed()
        {
            OrderStatus = OrderStatus.Confirmed;
            foreach (var orderline in OrderLines)
            {
                orderline.GoodSku.SetStockAdd(-orderline.Quantity);
            }
        }

        public void SetCanceled()
        {
            OrderStatus = OrderStatus.Canceled;
            foreach (var orderline in OrderLines)
            {
                orderline.GoodSku.SetStockAdd(orderline.Quantity);
            }
        }
        #endregion

        #region 导航属性

        public virtual IEnumerable<OrderLine> OrderLines { get; set; }

        #endregion
    }
}
