using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetalSaleSystem.Entity
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public class OrderInformation
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string orderId;
        /// <summary>
        /// 会员ID
        /// </summary>
        public string memberId;
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public string createTime;
        /// <summary>
        /// 商品条数
        /// </summary>
        public List<Item> items;
        /// <summary>
        ///支付信息
        /// </summary>
        public List<Payment> payments;
        /// <summary>
        /// 优惠券信息
        /// </summary>
        public string discountCards;
    }

    /// <summary>
    /// 商品条数
    /// </summary>
    public class Item
    {
        public string product;
        public string amount;
    }
    /// <summary>
    /// 支付信息
    /// </summary>
    public class Payment
    {
        public string type;
        public string amount;
    }
    /// <summary>
    /// 付款方式
    /// </summary>
    public class DiscountCard
    {

    }
}
