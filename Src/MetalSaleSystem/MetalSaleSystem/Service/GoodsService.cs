using MetalSaleSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem.Service
{
    public class GoodsService
    {
        public List<Goods> listGoods;
        public GoodsService()
        {
            listGoods = new List<Goods>();
            Goods goods001001 = new Goods(1, "世园会五十国钱币册", "册", 998.00, "001001", Discount.Discount1, OpenDoorRed.Full);
            Goods goods001002 = new Goods(2, "2019北京世园会纪念银章大全40g", "盒", 1380.00, "001002", Discount.Discount9, OpenDoorRed.Full);
            Goods goods003001 = new Goods(3, " 招财进宝", "条", 1580.00, "003001", Discount.Discount1, OpenDoorRed.Full);
            Goods goods003002 = new Goods(4, "水晶之恋", "册", 980.00, "003002", Discount.Discount1, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            Goods goods002002 = new Goods(5, "中国经典钱币套装", "套", 998.00, "002002", Discount.Discount9 | Discount.Discount95, OpenDoorRed.Full);
            Goods goods002001 = new Goods(6, "守扩之羽比翼双飞4.8g", "条", 1080.00, "002001", Discount.Discount95, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            Goods goods002003 = new Goods(7, "中国银象棋12g", "套", 698.00, "002003", Discount.Discount9, OpenDoorRed.Full3000 | OpenDoorRed.Full2000 | OpenDoorRed.Full1000);
            listGoods.Add(goods001001);
            listGoods.Add(goods001002);
            listGoods.Add(goods003001);
            listGoods.Add(goods003002);
            listGoods.Add(goods002002);
            listGoods.Add(goods002001);
            listGoods.Add(goods002003);
        }

        /// <summary>
        /// 获取单个产品价格
        /// </summary>
        /// <param name="goodNo"></param>
        /// <returns></returns>
        public double GetGoodsPrice(string goodNo)
        {
            double pirce = 0;
            foreach (Goods goods in listGoods)
            {
                if (goods.GoodsNo == goodNo)
                {
                    pirce = goods.Price;
                }
            }
            return pirce;
        }


        /// <summary>
        /// 获取订单金额
        /// </summary>
        /// <param name="orderInfo"></param>
        public void GetAllPrice(OrderInformation orderInfo)
        {
            double allPrice = 0;
            List<Item> listItem = orderInfo.items;
            foreach (Item item in listItem)
            {
                allPrice += GetGoodsPrice(item.product) * double.Parse(item.amount);
            }
        }
    }
}
