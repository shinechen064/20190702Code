using MetalSaleSystem.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetalSaleSystem.Entity
{
    /// <summary>
    /// Member会员类
    /// </summary>
    public class Member
    {
        //public Member()
        //{
        //    id = "";
        //    name = "";
        //    cardNo = "";
        //    JiFen = new MemberGrade();
        //    discountCard = "";
        //}
        public Member(int argID,string argName,string argCardNo,int argJiFen,string argDiscountCard)
        {
            id = argID;
            name = argName;
            cardNo = argCardNo;
            JiFen = new MemberGrade(argJiFen);
            discountCard = argDiscountCard;
        }

        public Member Copy(Member argSource)
        {
            if(null!=this&&null!=argSource)
            {
               this.Id  = argSource.Id;
                this.Name = argSource.Name;
                this.CardNo = argSource.CardNo;
                this.DiscountCard = argSource.DiscountCard;
                this.JiFen.Copy(argSource.JiFen);
            }
            return this;
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        private int id;
        /// <summary>
        /// 会员姓名
        /// </summary>
        private string name;
        /// <summary>
        /// 会员卡号
        /// </summary>
        private string cardNo;
        /// <summary>
        ///会员积分
        /// </summary>
        private MemberGrade jiFen;
        /// <summary>
        /// 会员优惠券
        /// </summary>
        private string discountCard;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        
        public string CardNo
        {
            get
            {
                return cardNo;
            }

            set
            {
                cardNo = value;
            }
        }


        public string DiscountCard
        {
            get
            {
                return discountCard;
            }

            set
            {
                discountCard = value;
            }
        }

        public MemberGrade JiFen
        {
            get
            {
                return jiFen;
            }

            set
            {
                jiFen = value;
            }
        }
    }
    
}
