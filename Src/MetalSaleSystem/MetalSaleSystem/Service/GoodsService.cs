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
        private List<Goods> m_objListGoods;
        private Goods m_objGoods;
        int m_goodsNumber = 0;
        public GoodsService(List<Goods> listGoods, string goodsNo, int goodsNum)
        {
            m_objListGoods = listGoods;
            m_objGoods = listGoods.Find(c => c.GoodsNo.Equals(goodsNo));
            m_goodsNumber = goodsNum;
        }
        public Goods GetCurrentGoods()
        {
            m_objGoods.Number = m_goodsNumber;
            m_objGoods.TotalPrice = GetTotalPrice();
            m_objGoods.DiscountPrice = (m_goodsNumber * m_objGoods.Price) - m_objGoods.TotalPrice;
            return m_objGoods;

        }
        // 获取当前商品的折扣
        private double GetCurrentDiscountTotalPrice()
        {
            double DiscountPrice = 0;
            if (m_objGoods.Discount == Discount.Discount90)
            {
                DiscountPrice = m_objGoods.Price * m_goodsNumber * 0.9;
            }
            else if (m_objGoods.Discount == (Discount.Discount95))
            {
                DiscountPrice = m_objGoods.Price * m_goodsNumber * 0.95;
            }
            else
            {
                DiscountPrice = m_objGoods.Price * m_goodsNumber;
            }
            return DiscountPrice;
        }
        // 获取当前商品的满减
        private double GetCurrentOpenDoorRedTotalPrice()
        {
            double totalPrice = 0.0f;
            // 不满减
            double fullPrice = 0.0f;
            double full1000Price = 0.0f;
            double full2000Price = 0.0f;
            double full3000Price = 0.0f;
            double full3HalfPrice = 0.0f;
            double full3Give1Price = 0.0f;

            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full) == OpenDoorRed.Full)
            {
                fullPrice = m_objGoods.Price * m_goodsNumber;
            }
            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full1000) == OpenDoorRed.Full1000)
            {
                double temp = m_objGoods.Price * m_goodsNumber;
                full1000Price = temp - ((temp) / 1000) * 10;
            }
            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full2000) == OpenDoorRed.Full2000)
            {
                double temp = m_objGoods.Price * m_goodsNumber;
                full2000Price = temp - ((temp) / 2000) * 30;
            }
            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full3000) == OpenDoorRed.Full3000)
            {
                double temp = m_objGoods.Price * m_goodsNumber;
                full3000Price = temp - ((temp) / 3000) * 350;
            }
            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full3Half) == OpenDoorRed.Full3Half)
            {
                double temp = m_objGoods.Price * m_goodsNumber;
                if (m_goodsNumber >= 3)
                {
                    full3HalfPrice = temp - m_objGoods.Price / 2;
                }
                else
                {
                    full3HalfPrice = temp;
                }
            }
            if ((m_objGoods.OpenDoorRed & OpenDoorRed.Full3Give1) == OpenDoorRed.Full3Give1)
            {
                double temp = m_objGoods.Price * m_goodsNumber;
                if (m_goodsNumber > 3)
                {
                    full3Give1Price = temp - m_objGoods.Price;
                }
                else
                {
                    full3Give1Price = temp;
                }
            }
            totalPrice = fullPrice;
            if (full1000Price > 0.0f)
            {
                totalPrice = fullPrice > full1000Price ? full1000Price : fullPrice;
            }
            if (full2000Price > 0.0f)
            {
                totalPrice = totalPrice > full2000Price ? full2000Price : totalPrice;
            }
            if (full3000Price > 0.0f)
            {
                totalPrice = totalPrice > full3000Price ? full3000Price : totalPrice;
            }
            if (full3HalfPrice > 0.0f)
            {
                totalPrice = totalPrice > full3HalfPrice ? full3HalfPrice : totalPrice;
            }
            if (full3Give1Price > 0.0f)
            {
                totalPrice = totalPrice > full3Give1Price ? full3Give1Price : totalPrice;
            }
            return totalPrice;
        }

        /// <summary>
        /// 获取订单金额
        /// </summary>
        /// <param name="orderInfo"></param>
        private double GetTotalPrice()
        {
            double DiscountPrice = GetCurrentDiscountTotalPrice();
            double OpenDoorRedPrice = GetCurrentOpenDoorRedTotalPrice();

            return DiscountPrice > OpenDoorRedPrice ? OpenDoorRedPrice : DiscountPrice;
        }
    }
}
