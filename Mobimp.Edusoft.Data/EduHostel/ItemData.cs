using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduHostel
{
    public class ItemData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public int GsexID { get; set; }
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
        public Decimal DepositBalance { get; set; }// Service fee deposit balance mainly for hosteler

        //Item
        [DataMember]
        public int SlNo { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public decimal ItemRate { get; set; }
        [DataMember]
        public Int64 ItemQty { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public int TotalItemQty { get; set; }
        [DataMember]
        public int NetItemQty { get; set; }
        [DataMember]
        public decimal NetAmount { get; set; }
        [DataMember]
        public decimal TotalNetAmount { get; set; }
        [DataMember]
        public decimal AjustedAmt { get; set; }
        [DataMember]
        public decimal TotalAjustedAmount { get; set; }
        [DataMember]
        public decimal CurrentAjustedAmount { get; set; }
        [DataMember] 
        public int IsAjusted { get; set; }
        [DataMember]
        public string xmlItemList { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }

        //Search 
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

        //Detele Taking Item 
        [DataMember]
        public string Remarks { get; set; } 
        
    }
}
