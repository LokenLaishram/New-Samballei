using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduHostel
{
    public class DepositFeeData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }//tap1
        [DataMember]
        public Int64 StudentsID { get; set; }//tap1
        [DataMember]
        public Int64 AcademicSessionID { get; set; }
        [DataMember]
        public Int64 AdmissioNo { get; set; }//tap1
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int PaymentType { get; set; }//tap1
        [DataMember]
        public string PaymentTypename { get; set; }//tap1
        [DataMember]
        public int PayModeID { get; set; }//tap1
        [DataMember]
        public string PayMode { get; set; }//tap1
        [DataMember]
        public string BankName { get; set; }//tap1
        [DataMember]
        public string ChalanNo { get; set; }//tap1
        [DataMember]
        public Decimal TotalBalanceAmount { get; set; }
        [DataMember]
        public Decimal TotalDepositAmount { get; set; }
        [DataMember]
        public Decimal CurrentAjustedAmount { get; set; }
        [DataMember]
        public Decimal TotalCurrentAjustedAmount { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public Decimal DepositAmount { get; set; } //tap1
        [DataMember]
        public Decimal BalanceAmount { get; set; }
        [DataMember]
        public Decimal PreBalanceAmount { get; set; }
        [DataMember]
        public DateTime DepositDate { get; set; }//tap1
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public int ActionTypes { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
    }
}
