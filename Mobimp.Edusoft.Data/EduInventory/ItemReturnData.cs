using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    [Serializable]
    public class ItemReturnData : BaseData
    {
        [DataMember]
        public Int64 ReturnID { get; set; }
        [DataMember]
        public string ReturnNo { get; set; }
        [DataMember]
        public Int64 IssueID { get; set; }
        [DataMember]
        public string IssueNo { get; set; }
        [DataMember]
        public string StockNo { get; set; }
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public string VendorTypeName { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]       
        public decimal Price { get; set; }
        [DataMember]
        public double AvailableQty { get; set; }
        [DataMember]
        public double TotalAvailableQty { get; set; }
        [DataMember]
        public double IssueQty { get; set; }
        [DataMember]
        public double TotalIssueQty { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public Int64 Return { get; set; }
        [DataMember]
        public double ReturnQty { get; set; }
        [DataMember]
        public double TotalReturnQty { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        [DataMember]
        public string jsondata { get; set; }
        [DataMember]
        public string ExpiryDates { get; set; }
    }
}
