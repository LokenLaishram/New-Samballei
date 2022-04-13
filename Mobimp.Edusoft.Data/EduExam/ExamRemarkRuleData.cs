using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.EduExam
{
    public class ExamRemarkRuleData :BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }      
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public int DivisionID { get; set; }
        [DataMember]
        public string DivisionName { get; set; }
        [DataMember]
        public decimal MarkFrom { get; set; }
        [DataMember]
        public decimal MarkUpTo { get; set; }
        [DataMember]
        public string MarkRemarks { get; set; }
        [DataMember]
        public string xmlRemarkRulelist { get; set; }
    }

    public class ExamRankTieRuleData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }       
        [DataMember]
        public string Particular { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public string xmlRankTieRulelist { get; set; }
        [DataMember]
        public int typeid { get; set; }

    }
    public class ExamDivisionRuleData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public int DivisionID { get; set; }
        [DataMember]
        public string DivisionName { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string RemarkName { get; set; }
        [DataMember]
        public decimal PCFrom { get; set; }
        [DataMember]
        public decimal PCUpTo { get; set; }
        [DataMember]
        public int NoOfAbsent { get; set; }
        [DataMember]
        public int NoOfAbsentUpto { get; set; }
        [DataMember]
        public int NoOfFailed { get; set; } 
        [DataMember]
        public int NoOfFailedUpto { get; set; }
        [DataMember]
        public int NoOfFailedAbsent { get; set; }
        [DataMember]
        public int NoOfFailedAbsentUpto { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public decimal GPCFrom { get; set; }
        [DataMember]
        public decimal GPCUpTo { get; set; }
        [DataMember]
        public string DivisionRemark { get; set; }
        [DataMember] 
        public int IsDivision { get; set; }
        [DataMember]
        public int IsCommon { get; set; }
        [DataMember]
        public int IsGrade{ get; set; }
        [DataMember]
        public string xmlDivisionRulelist { get; set; }
        [DataMember]
        public string xmlRemarkRulelist { get; set; }
        [DataMember]
        public string xmlFailPassRulelist { get; set; }
        [DataMember]
        public string xmlGradeRulelist { get; set; }
        [DataMember]
        public string xmlExamRulelist { get; set; }
        [DataMember]
        public int MarkFrom { get; set; }
        [DataMember]
        public int MarkUpto { get; set; }
        [DataMember]
        public int IsGradeOrMark { get; set; }
        [DataMember]
        public int IsMarkOrPC { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public int Activate { get; set; }

    }
}
