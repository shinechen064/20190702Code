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
        private List<Goods> listGoods;
        public GoodsService(List<Goods> listGoods)
        {

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
