using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetalSaleSystem.Entity
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public class Member
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string id;
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string name;
        /// <summary>
        /// 会员等级
        /// </summary>
        public string grade;
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string cardNo;
        /// <summary>
        ///会员积分
        /// </summary>
        public string jiFen;
        /// <summary>
        /// 会员优惠券
        /// </summary>
        public string discountCard;
    }
    
}
