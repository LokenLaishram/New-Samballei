using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduLibrary
{
    public class IssueBookData : BaseData
    {
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
        [DataMember]
        public string Books { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string XmlBookIssuelist { get; set; }
        [DataMember]
        public Int32 Qty { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int RackID { get; set; }
        [DataMember]
        public int BooksID { get; set; }
        [DataMember]
        public Int32 HID { get; set; }
        [DataMember]
        public string BookDetails { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        [DataMember]
        public Int32 TotalItemQty { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string IssueNo { get; set; }
        [DataMember]
        public Int32 ReturnQty { get; set; }
        [DataMember]
        public string ReturnStatus { get; set; }
        [DataMember]
        public int GenerateID { get; set; }
    }
    public class IssueBookDatatoExcel
    {
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
    }
}
