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

        private string batchNo;

        /// <summary>
        /// 编号
        /// </summary>
        public string BatchNo
        {
            get { return batchNo; }
            set { batchNo = value; }
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
        Full3000 = "每满3000元减350",
        Full2000 = "每满2000元减30",
        Full1000 = "每满1000元减10",
        Full3Half = "第3件半价",
        Full3Give1 = "满3送1"
    }
}
