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
        private  Goods goods;
        int goodsNumber = 0;
        public GoodsService(List<Goods> listGoods, string goodsNo, int goodsNum)
        {
            goods = listGoods.Find(c => c.GoodsNo.Equals(goodsNo));
            goodsNumber = goodsNum;
        }

        /// <summary>
        /// 获取单个产品价格
        /// </summary>
        /// <param name="goodNo"></param>
        /// <returns></returns>
        public double GetGoodsPrice(string goodNo)
        {
            double pirce = 0;
            Goods goods = listGoods.Find(c => c.GoodsNo.Equals(goodNo));
            pirce = goods.Price;
            return pirce;
        }


        /// <summary>
        /// 获取订单金额
        /// </summary>
        /// <param name="orderInfo"></param>
        public void GetTotalPrice()
        {
            double DiscountPrice = 0;
            if (goods.Discount == Discount.Discount9)
            {
                DiscountPrice = goods.Price * goodsNumber * 0.9;
            }
            else if (goods.Discount == (Discount.Discount95))
            {
                DiscountPrice = goods.Price * goodsNumber * 0.95;
            }
            else
            {
                DiscountPrice = goods.Price * goodsNumber;
            }

            
        }
    }
}
