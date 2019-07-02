using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem.Entity
{
    public enum enumGradeLevel
    {
        /*
         * 普卡：1倍基准积分，累计积分1万以下
            金卡：1.5倍基准积分，累计积分1万（含）-5万（不含）
            白金卡：1.8倍基准积分，累计积分5万（含）-10万（不含）
            钻石卡：2倍基准积分，累计积分10万以上
         */
        NORMAL,
        GOLD,
        PLATINUM,
        DIAMONDS
    }
    public enum enumJiFen
    {
        /**
         * 普卡：1倍基准积分，累计积分1万以下
金卡：1.5倍基准积分，累计积分1万（含）-5万（不含）
白金卡：1.8倍基准积分，累计积分5万（含）-10万（不含）
钻石卡：2倍基准积分，累计积分10万以上
         * */
        LEVEL10000 = 10000,
        LEVEL50000 = 50000,
        LEVEL100000 = 100000,
    }
    public enum enumSpeed
    {
        /**
        * 普卡：1倍基准积分，累计积分1万以下
金卡：1.5倍基准积分，累计积分1万（含）-5万（不含）
白金卡：1.8倍基准积分，累计积分5万（含）-10万（不含）
钻石卡：2倍基准积分，累计积分10万以上
        * */
        SPEED1,
        SPEED1_5,
        SPEED1_8,
        SPEED2
    }

    [Serializable]
    public class MemberGradeEntity
    {
        public MemberGradeEntity()
        {
            gradeId = 0;
            gradeLevel = enumGradeLevel.NORMAL;
            start = 0;
            end = 0;
            nextGradeLevel = enumGradeLevel.NORMAL;
            jiFen = 0;
            speed = enumSpeed.SPEED1;
        }
        public MemberGradeEntity(enumGradeLevel argGradeName,enumGradeLevel argNextGradeName,int argJiFen, enumSpeed argSpeed)
        {
            gradeId = 0;
            gradeLevel = argGradeName;
            start = 0;
            end = 0;
            nextGradeLevel = argNextGradeName;
            jiFen = argJiFen;
            speed = argSpeed;
        }

        private int gradeId;
        private enumGradeLevel gradeLevel;
        private int start;
        private int end;
        private enumGradeLevel nextGradeLevel;
        private enumSpeed speed;
        private int jiFen;


        /// <summary>
        /// 等级名称
        /// </summary>
        public enumGradeLevel GradeLevel
        {
            get
            {
                return gradeLevel;
            }

            set
            {
                gradeLevel = value;
            }
        }

        /// <summary>
        /// 积分倍速
        /// </summary>
        public enumSpeed Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        /// <summary>
        /// 等级开始区间
        /// </summary>
        public int Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        /// <summary>
        /// 等级结束区间
        /// </summary>
        public int End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        /// <summary>
        /// 下一等级名称
        /// </summary>
        public enumGradeLevel NextLevel
        {
            get
            {
                return nextGradeLevel;
            }

            set
            {
                nextGradeLevel = value;
            }
        }
        /// <summary>
        /// 等级ID
        /// </summary>
        public int GradeId
        {
            get
            {
                return gradeId;
            }

            set
            {
                gradeId = value;
            }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int JiFen
        {
            get
            {
                return jiFen;
            }

            set
            {
                jiFen = value;
            }
        }
    }
}
