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
        private List<Member> m_objMember;
        private List<Goods> listGoods ;
        public Result(OrderInformation objOI,string argOutputFile)
        {
            if(string.IsNullOrWhiteSpace(argOutputFile))
            {
                m_strOutputFile = "Result.txt";
            }
            else
            {
                m_strOutputFile = argOutputFile;
            }
            m_objOrderInfo = objOI;
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if(string.IsNullOrWhiteSpace(m_strOutputFile))
            {
                m_strOutputFile = "Result.txt";
            }
            if(!File.Exists(m_strOutputFile))
            {
                File.Create(m_strOutputFile);
            }
            m_objMember = new List<Member>();
            /**
             * 马丁,普卡,6236609999,9860
                王立,金卡,6630009999,48860
                李想,白金卡,8230009999,98860
                张三,钻石卡,9230009999,198860
             */
            Member member = new Member(0, "马丁", "6236609999", 9860,"");
            m_objMember.Add(member);
            member = new Member(0, "王立", "6630009999", 48860, "");
            m_objMember.Add(member);
            member = new Member(0, "李想", "8230009999", 98860, "");
            m_objMember.Add(member);
            member = new Member(0, "张三", "9230009999", 198860, "");
            m_objMember.Add(member);

            listGoods = new List<Goods>();
            Goods goods = new Goods(1, "世园会五十国钱币册", "册", 998.00, "001001", Discount.Discount1, OpenDoorRed.Full);
            listGoods.Add(goods);
            goods = new Goods(2, "2019北京世园会纪念银章大全40g", "盒", 1380.00, "001002", Discount.Discount9, OpenDoorRed.Full);
            listGoods.Add(goods);
            goods = new Goods(3, " 招财进宝", "条", 1580.00, "003001", Discount.Discount1, OpenDoorRed.Full);
            listGoods.Add(goods);
            goods = new Goods(4, "水晶之恋", "册", 980.00, "003002", Discount.Discount1, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            listGoods.Add(goods);
            goods = new Goods(5, "中国经典钱币套装", "套", 998.00, "002002", Discount.Discount9 | Discount.Discount95, OpenDoorRed.Full);
            listGoods.Add(goods);
            goods = new Goods(6, "守扩之羽比翼双飞4.8g", "条", 1080.00, "002001", Discount.Discount95, OpenDoorRed.Full3Half | OpenDoorRed.Full3Give1);
            listGoods.Add(goods);
            goods = new Goods(7, "中国银象棋12g", "套", 698.00, "002003", Discount.Discount9, OpenDoorRed.Full3000 | OpenDoorRed.Full2000 | OpenDoorRed.Full1000);
            listGoods.Add(goods);

            try
            {
                m_fsWriter = new FileStream(m_strOutputFile, FileMode.Create);
                m_swWriter = new StreamWriter(m_fsWriter);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private void Release()
        {
            if(null!=m_swWriter)
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
