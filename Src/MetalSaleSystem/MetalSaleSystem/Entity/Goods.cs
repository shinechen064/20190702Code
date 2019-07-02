using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem.Entity
{
    public class Goods
    {
        private int goodsId;

        /// <summary>
        /// ID
        /// </summary>
        public int GoodsId
        {
            get { return goodsId; }
            set { goodsId = value; }
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
        private string price;

        /// <summary>
        /// 价格
        /// </summary>
        public string Price
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
    }

    /// <summary>
    /// 打折卷
    /// </summary>
    public enum Discount
    {
        Discount95 = 95,
        Discount9 = 9
    }

    public enum OpenDoorRed
    {
        Full3000,
        Full2000,
        Full1000,
        Full3Half,
        Full3Give1
    }
}
