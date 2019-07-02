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
        /// <summary>
        /// 商品价格
        /// </summary>
        private static readonly Dictionary<string, double> goodsInfo = new Dictionary<string, double>
        {
                      { "001001",998.00 },
                      { "001002", 1380.00 },
                      { "003001", 1580.00 },
                      { "003002", 980.00 },
                      { "002002", 998.00 },
                      { "002001", 1080.00 },
                      { "002003", 698.00 }
        };

        private static readonly List<Goods> listGoods = new List<Goods>()
        {
             
        };

        /// <summary>
        /// 获取单个产品价格
        /// </summary>
        /// <param name="goodNo"></param>
        /// <returns></returns>
        public double GetGoodsPrice(string goodNo)
        {
            double pirce = 0;
            foreach (KeyValuePair<string, double> kvp in goodsInfo)
            {
                if (kvp.Key == goodNo)
                {
                    pirce = kvp.Value;
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
