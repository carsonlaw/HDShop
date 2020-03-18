using System;
using System.Collections.Generic;
using System.Text;

namespace HDShop.Orders
{
    public enum OrderStatus
    {
        /// <summary>
        /// 已提交等待库存确认
        /// </summary>
        Init,
        /// <summary>
        /// 库存确认等待付款
        /// </summary>
        Confirmed,
        /// <summary>
        /// 已经付款等待发货
        /// </summary>
        Payed,
        /// <summary>
        /// 已经发货等待收货
        /// </summary>
        Delivered,
        /// <summary>
        /// 已经收货
        /// </summary>
        Recived,
        /// <summary>
        /// 已申请取消等待确认
        /// </summary>
        Canceling,
        /// <summary>
        /// 取消已确认
        /// </summary>
        Canceled,
        /// <summary>
        /// 已申请退款等待确认
        /// </summary>
        Refunding,
        /// <summary>
        /// 退款已确认
        /// </summary>
        Refunded
    }
}
