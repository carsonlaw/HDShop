using HDShop.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HDShop.Orders
{
    public class OrderDto : FullAuditedEntityWithUserDto<Guid,AppUserDto>
    {
        #region 属性

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(OrderConsts.CodeLength)]
        public virtual string Code { get; set; }

        public virtual decimal OrderPrice
        {
            get;set;
        }


        [Required]
        public virtual OrderStatus OrderStatus { get; set; }

        #endregion
        #region 导航属性

        public virtual IEnumerable<OrderLineDto> OrderLines { get; set; }

        public virtual DeliverAddressDto DeliverAddress { get; set; }

        public virtual PayOrderDto? PayOrder { get; set; }
        public virtual DeliverOrderDto? DeliverOrder { get; set; }

        #endregion
    }
}
