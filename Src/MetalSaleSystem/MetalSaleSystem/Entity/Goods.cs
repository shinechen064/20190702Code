using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem.Entity
{
    public class Goods
    {
        public Goods(int argGoodsId, string argGoodsName, string argUnit, double argPrice, string argGoodsNo, Discount argDiscount, OpenDoorRed argOpenDoorRed)
        {
            goodsId = argGoodsId;
            goodsName = argGoodsName;
            unit = argUnit;
            price = argPrice;
            goodsNo = argGoodsNo;
            discount = argDiscount;
            openDoorRed = argOpenDoorRed;
        }
        private int goodsId;

        /// <summary>
        /// ID
        /// </summary>
        public int GoodsId
        {
            get { return goodsId; }
            set { goodsId = value; }
        }
        private int number;

        /// <summary>
        /// ID
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private string goodsName;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        private string unit;

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private double price;

        /// <summary>
        /// 价格
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string goodsNo;

        /// <summary>
        /// 编号
        /// </summary>
        public string GoodsNo
        {
            get { return goodsNo; }
            set { goodsNo = value; }
        }

        private Discount discount;

        public Discount Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private OpenDoorRed openDoorRed;

        public OpenDoorRed OpenDoorRed
        {
            get { return openDoorRed; }
            set { openDoorRed = value; }
        }

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        private double discountPrice;

        public double DiscountPrice
        {
            get { return discountPrice; }
            set { discountPrice = value; }
        }
    }

    /// <summary>
    /// 打折卷
    /// </summary>
    public enum Discount
    {
        Discount95 = 95,
        Discount90 = 90,
        Discount100 = 100
    }

    public enum OpenDoorRed
    {
        Full,
        Full3000,
        Full2000,
        Full1000,
        Full3Half,
        Full3Give1
    }
}
