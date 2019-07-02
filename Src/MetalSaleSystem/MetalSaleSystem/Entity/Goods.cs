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

        public int GoodsId
        {
            get { return goodsId; }
            set { goodsId = value; }
        }
        private string goodsName;

        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
