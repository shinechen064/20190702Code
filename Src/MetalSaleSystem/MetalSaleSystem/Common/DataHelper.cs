using MetalSaleSystem.Entity;
using System.Collections.Generic;

namespace MetalSaleSystem.Common
{
    public class DataHelper
    {
        public List<MemberGradeEntity> GetMemberGradeData()
        {
            List<MemberGradeEntity> listMemberGrade = new List<MemberGradeEntity>();
            MemberGradeEntity memberGrade1 = new MemberGradeEntity();
            memberGrade1.GradeName = "普卡";
            memberGrade1.Speed = 1;
            memberGrade1.Start = 0;
            memberGrade1.End = 10000;
            memberGrade1.NextName = "金卡";
            listMemberGrade.Add(memberGrade1);

            MemberGradeEntity memberGrade2 = new MemberGradeEntity();
            memberGrade2.GradeName = "金卡";
            memberGrade2.Speed = 1;
            memberGrade2.Start = 10000;
            memberGrade2.End = 50000;
            memberGrade2.NextName = "白金卡";
            listMemberGrade.Add(memberGrade2);

            MemberGradeEntity memberGrad3 = new MemberGradeEntity();
            memberGrad3.GradeName = "白金卡";
            memberGrad3.Speed = 1;
            memberGrad3.Start = 50000;
            memberGrad3.End = 100000;
            memberGrad3.NextName = "钻石卡";
            listMemberGrade.Add(memberGrad3);

            MemberGradeEntity memberGrad4 = new MemberGradeEntity();
            memberGrad4.GradeName = "钻石卡";
            memberGrad4.Speed = 1;
            memberGrad4.Start = 100000;
            memberGrad4.End = 9999999;
            memberGrad4.NextName = "";
            listMemberGrade.Add(memberGrad4);

            return listMemberGrade;
        }
    }
}
