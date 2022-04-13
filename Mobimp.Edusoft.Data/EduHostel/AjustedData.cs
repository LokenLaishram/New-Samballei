using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduHostel
{
    public class AjustedData:BaseData
    {
        [DataMember]
        public int AID { get; set; }
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
        public Decimal AjustedBalance { get; set; }// Service fee Ajusted balance mainly for hosteler
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal AjustedAmount { get; set; }
        [DataMember]
        public decimal TotalAjustedAmount { get; set; }
        [DataMember]
        public decimal PreAjustedBlc { get; set; }
        [DataMember]
        public decimal TotalCollectedAmount { get; set; }

        //Search 
        [DataMember]
        public int ACID { get; set; }
        [DataMember]
        public string PaidRecieptNo { get; set; }
        [DataMember]
        public DateTime PaidDate { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        //[DataMember]
        //public bool IsActive { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Duestatus { get; set; }
       
    }
}
