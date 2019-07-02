using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem.Entity
{
    [Serializable]
    public class MemberGradeEntity
    {
        private int gradeId;
        private string gradeName;
        private int start;
        private int end;
        private string nextName;
        private double speed;

        /// <summary>
        /// 等级名称
        /// </summary>
        public string GradeName
        {
            get
            {
                return gradeName;
            }

            set
            {
                gradeName = value;
            }
        }
        
        /// <summary>
        /// 积分倍速
        /// </summary>
        public double Speed
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
        public string NextName
        {
            get
            {
                return nextName;
            }

            set
            {
                nextName = value;
            }
        }

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
    }
}
