using MetalSaleSystem.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace MetalSaleSystem.Service
{
    /// <summary>
    /// 信息输出类
    /// </summary>
    public class Result
    {
        private string m_strOutputFile = string.Empty;
        private FileStream m_fsWriter;
        private StreamWriter m_swWriter;
        private OrderInformation m_objOrderInfo;
        private List<Member> m_objListMember;
        private List<Goods> m_objListGoods;
        private List<Goods> m_objSalesGoods;
        private Member m_objCurMember;
        private Goods m_objGoods;
        public Result(OrderInformation objOI, string argOutputFile)
        {
            if (string.IsNullOrWhiteSpace(argOutputFile))
            {
                m_strOutputFile = "Result.txt";
            }
            else
            {
                m_strOutputFile = argOutputFile;
            }
            m_objOrderInfo = objOI;

            InitMembers();

            InitGoods();

            Init();
            GetCurrentMemberAndGoods();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (string.IsNullOrWhiteSpace(m_strOutputFile))
            {
                m_strOutputFile = "Result.txt";
            }
            if (!File.Exists(m_strOutputFile))
            {
                File.Create(m_strOutputFile);
            }



            try
            {
                m_fsWriter = new FileStream(m_strOutputFile, FileMode.Create);
                m_swWriter = new StreamWriter(m_fsWriter);
            }
            catch (Exception ex)
            {

            }
        }
        private void InitMembers()
        {
            m_objListMember = new List<Member>();
            /**
             * 马丁,普卡,6236609999,9860
                王立,金卡,6630009999,48860
                李想,白金卡,8230009999,98860
                张三,钻石卡,9230009999,198860
             */
            Member member = new Member(0, "马丁", "6236609999", 9860, "");
            m_objListMember.Add(member);
            member = new Member(0, "王立", "6630009999", 48860, "");
            m_objListMember.Add(member);
            member = new Member(0, "李想", "8230009999", 98860, "");
            m_objListMember.Add(member);
            member = new Member(0, "张三", "9230009999", 198860, "");
            m_objListMember.Add(member);

        }

        private void InitGoods()
        {
            m_objListGoods = new List<Goods>();
            Goods goods = new Goods(1, "世园会五十国钱币册", "册", 998.00, "001001", Discount.Discount100, OpenDoorRed.Full);
            m_objListGoods.Add(goods);
            goods = new Goods(2, "2019北京世园会纪念银章大全40g", "盒", 1380.00, "001002", Discount.Discount90, OpenDoorRed.Full);
            m_objListGoods.Add(goods);
            goods = new Goods(3, " 招财进宝", "条", 1580.00, "003001", Discount.Discount100, OpenDoorRed.Full);
            m_objListGoods.Add(goods);
            goods = new Goods(4, "水晶之恋", "册", 980.00, "003002", Discount.Discount100, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            m_objListGoods.Add(goods);
            goods = new Goods(5, "中国经典钱币套装", "套", 998.00, "002002", Discount.Discount90 | Discount.Discount95, OpenDoorRed.Full);
            m_objListGoods.Add(goods);
            goods = new Goods(6, "守扩之羽比翼双飞4.8g", "条", 1080.00, "002001", Discount.Discount95, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            m_objListGoods.Add(goods);
            goods = new Goods(7, "中国银象棋12g", "套", 698.00, "002003", Discount.Discount90, OpenDoorRed.Full3000 | OpenDoorRed.Full2000 | OpenDoorRed.Full1000);
            m_objListGoods.Add(goods);

        }

        private bool GetCurrentMemberAndGoods()
        {
            for (int i = 0; i < m_objListMember.Count; ++i)
            {
                if (m_objOrderInfo.memberId == m_objListMember[i].CardNo)
                {
                    Member member = m_objListMember[i];
                    string strdiscountCard = "";
                    if (m_objOrderInfo.discountCards.Length > 0)
                    {
                        strdiscountCard = m_objOrderInfo.discountCards[0];
                    }
                    // 获取当前用户
                    m_objCurMember = new Member(member.Id, member.Name, member.CardNo, member.JiFen.GetJiFen(), strdiscountCard);
                    break;
                }
            }
            m_objSalesGoods = new List<Goods>();
            // 获取当前商品信息
            foreach (Item item in m_objOrderInfo.items)
            {
                int result = 0;
                int.TryParse(item.amount, out result);
                GoodsService goodService = new GoodsService(m_objListGoods, item.product, result);
                Goods goods = goodService.GetCurrentGoods();
                m_objSalesGoods.Add(goods);
            }

            return true;
        }

        public bool GenerateResult()
        {
            /**
             * 方鼎银行贵金属购买凭证

销售单号：0000001 日期：2019-07-02 15:00:00
客户卡号：6236609999 会员姓名：马丁 客户等级：金卡 累计积分：19720

商品及数量           单价         金额
(001001)世园会五十国钱币册x2, 998.00, 1996.00
(001002)2019北京世园会纪念银章大全40gx3, 1380.00, 4140.00
(002002)中国经典钱币套装x1, 998.00, 998.00
(002003)中国银象棋12gx5, 698.00, 3490.00
合计：10624.00

优惠清单：
(001002)2019北京世园会纪念银章大全40g: -414.00
(002003)中国银象棋12g: -350.00
优惠合计：764.00

应收合计：9860.00
收款：
 9折券
 余额支付：9860.00

客户等级与积分：
 新增积分：9860
 恭喜您升级为金卡客户！

             * ***/
            string strGoods = "";
            string strDiscounts = "";
            double totalPayPrice = 0.0f;
            double totalDiscountPrice = 0.0f;
            for (int i = 0; i < m_objSalesGoods.Count; ++i)
            {
                Goods goods = m_objSalesGoods[i];
                strGoods += string.Format("({0}){1}x{2}, {3}, {4}", goods.GoodsNo, goods.GoodsName, goods.Number, goods.Price, (goods.TotalPrice + goods.DiscountPrice).ToString("F"));
                if (goods.DiscountPrice > 0.0f)
                {
                    strDiscounts += string.Format("({0}){1}: -{2}", goods.GoodsNo, goods.GoodsName, goods.DiscountPrice.ToString("F"));
                    if (i + 1 < m_objSalesGoods.Count)
                    {
                        strDiscounts += "\r\n";
                    }
                }

                if (i + 1 < m_objSalesGoods.Count)
                {
                    strGoods += "\r\n";
                }
                totalPayPrice += goods.TotalPrice;
                totalDiscountPrice += goods.DiscountPrice;
            }

            m_swWriter.WriteLine("方鼎银行贵金属购买凭证");
            m_swWriter.WriteLine("");
            m_swWriter.WriteLine(string.Format("销售单号：{0} 日期：{1}", m_objOrderInfo.orderId, m_objOrderInfo.createTime));
            enumGradeLevel gradeLevel = m_objCurMember.JiFen.GetGradeLevel();
            enumSpeed speed = m_objCurMember.JiFen.GetSpeed();
            int jiFen = 0;

            switch (speed)
            {
                case enumSpeed.SPEED1:
                    jiFen = (int)(totalPayPrice * 1);
                    break;
                case enumSpeed.SPEED1_5:
                    jiFen = (int)(totalPayPrice * 1.5);
                    break;
                case enumSpeed.SPEED1_8:
                    jiFen = (int)(totalPayPrice * 1.8);
                    break;
                case enumSpeed.SPEED2:
                    jiFen = (int)(totalPayPrice * 2);
                    break;
                default:
                    jiFen = (int)(totalPayPrice * 1);
                    break;
            }
            m_objCurMember.JiFen.AddJiFen(jiFen);
            m_swWriter.WriteLine(string.Format("客户卡号：{0} 会员姓名：{1} 客户等级：{2} 累计积分：{3}", m_objCurMember.CardNo, m_objCurMember.Name, m_objCurMember.JiFen.GetGradeName(gradeLevel), m_objCurMember.JiFen.GetJiFen()));
            m_swWriter.WriteLine("");
            m_swWriter.WriteLine("商品及数量           单价         金额");
            m_swWriter.WriteLine(strGoods);
            m_swWriter.WriteLine("合计：" + (totalPayPrice + totalDiscountPrice).ToString("F"));
            m_swWriter.WriteLine("");
            m_swWriter.WriteLine("优惠清单：");
            m_swWriter.WriteLine(strDiscounts);
            m_swWriter.WriteLine("优惠合计：" + totalDiscountPrice.ToString("F"));
            m_swWriter.WriteLine("");
            m_swWriter.WriteLine("应收合计：" + totalPayPrice.ToString("F"));
            m_swWriter.WriteLine("收款：");
            if (m_objOrderInfo.discountCards.Length > 0)
            {
                m_swWriter.WriteLine(m_objOrderInfo.discountCards[0]);
            }
            m_swWriter.WriteLine("余额支付：" + totalPayPrice.ToString("F"));
            m_swWriter.WriteLine("");
            m_swWriter.WriteLine("客户等级与积分：");
            m_swWriter.WriteLine("新增积分：" + jiFen);
            enumGradeLevel newgradeLevel = m_objCurMember.JiFen.GetGradeLevel(m_objCurMember.JiFen.GetJiFen());
            if (newgradeLevel == m_objCurMember.JiFen.GetNextGradeLevel())
            {
                m_swWriter.WriteLine("恭喜您升级为{0}客户！", m_objCurMember.JiFen.GetGradeName(newgradeLevel));
            }
            m_swWriter.Flush();
            return true;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private void Release()
        {
            if (null != m_objListMember)
            {
                m_objListMember.Clear();
            }
            if (null != m_objListGoods)
            {
                m_objListGoods.Clear();
            }
            if (null != m_swWriter)
            {
                m_swWriter.Close();
                m_swWriter.Dispose();
                m_swWriter = null;
            }
            if (null != m_fsWriter)
            {
                m_fsWriter.Close();
                m_fsWriter.Dispose();
                m_fsWriter = null;
            }
        }
    }


}
