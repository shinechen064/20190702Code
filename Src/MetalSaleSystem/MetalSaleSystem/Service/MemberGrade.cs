using MetalSaleSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem
{

    public class MemberGrade
    {
        public MemberGrade()
        {
            m_objGrade = new MemberGradeEntity();
        }
        public MemberGrade(int argJiFen)
        {
            enumGradeLevel objLevel = GetGradeLevel(argJiFen);
            enumSpeed objSpeed = GetSpeed(objLevel);
            m_objGrade = new MemberGradeEntity(objLevel, GetNextGradeLevel(objLevel),argJiFen,objSpeed);
        }
        public int AddJiFen(int argAddJiFen)
        {
            m_objGrade.JiFen += argAddJiFen;
            return m_objGrade.JiFen;
        }
        public int GetJiFen()
        {
            return m_objGrade.JiFen;
        }

        public enumGradeLevel GetGradeLevel()
        {
            return m_objGrade.GradeLevel;
        }
        public enumGradeLevel GetNextGradeLevel()
        {
            return m_objGrade.NextLevel;
        }
        public enumSpeed GetSpeed()
        {
            return m_objGrade.Speed;
        }
        /// <summary>
        /// 通过积分获取客户的等级
        /// </summary>
        /// <param name="argJiFen"></param>
        /// <returns></returns>
        private enumGradeLevel GetGradeLevel(int argJiFen)
        {
            if (argJiFen < (int)enumJiFen.LEVEL10000)
            {
                return enumGradeLevel.NORMAL;
            }
            else if ((argJiFen >= (int)enumJiFen.LEVEL10000) && (argJiFen < (int)enumJiFen.LEVEL50000))
            {
                return enumGradeLevel.GOLD;
            }
            else if((argJiFen >= (int)enumJiFen.LEVEL50000) && (argJiFen < (int)enumJiFen.LEVEL100000))
            {
                return enumGradeLevel.PLATINUM;
            }
            else if((argJiFen >= (int)enumJiFen.LEVEL100000))
            {
                return enumGradeLevel.DIAMONDS;
            }
            else
            {
                return enumGradeLevel.NORMAL;
            }
        }
        /// <summary>
        /// 通过等级获取客户下一等级
        /// </summary>
        /// <param name="argGrade"></param>
        /// <returns></returns>
        private enumGradeLevel GetNextGradeLevel(enumGradeLevel argGrade)
        {
           switch(argGrade)
            {
                case enumGradeLevel.NORMAL:
                    return enumGradeLevel.GOLD;
                case enumGradeLevel.GOLD:
                    return enumGradeLevel.PLATINUM;
                case enumGradeLevel.PLATINUM:
                    return enumGradeLevel.DIAMONDS;
                case enumGradeLevel.DIAMONDS:
                    return enumGradeLevel.DIAMONDS;
                default:
                    return enumGradeLevel.NORMAL;
            }
        }
        /// <summary>
        /// 通过等级获取客户下一等级
        /// </summary>
        /// <param name="argGrade"></param>
        /// <returns></returns>
        private enumSpeed GetSpeed(enumGradeLevel argGrade)
        {
            switch (argGrade)
            {
                case enumGradeLevel.NORMAL:
                    return enumSpeed.SPEED1;
                case enumGradeLevel.GOLD:
                    return enumSpeed.SPEED1_5;
                case enumGradeLevel.PLATINUM:
                    return enumSpeed.SPEED1_8;
                case enumGradeLevel.DIAMONDS:
                    return enumSpeed.SPEED2;
                default:
                    return enumSpeed.SPEED1;
            }
        }
        private MemberGradeEntity m_objGrade;
    }
}
