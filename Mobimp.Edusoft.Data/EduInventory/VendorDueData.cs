using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    public class VendorDueData :BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string SaleNo { get; set; }
        [DataMember]
        public string BillNo { get; set; }
        [DataMember]
        public string DueBillNo { get; set; }
        [DataMember]
        public string IndentNo { get; set; }
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public string VendorTypeName { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemCode { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int IndentQty { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public string jsondata { get; set; }
        [DataMember]
        public int GdTotalIndentQty { get; set; }
        [DataMember]
        public decimal GdTotalPrice { get; set; }
        [DataMember]
        public int IsApproved { get; set; }
        [DataMember]
        public string ApproveStatus { get; set; }
        [DataMember]
        public int AvailableQty { get; set; }
        [DataMember]
        public int IssueQty { get; set; }
        [DataMember]
        public int TotalIssueQty { get; set; }
        [DataMember]
        public decimal GdTotalAmount { get; set; }
        [DataMember]
        public decimal GdDiscount { get; set; }
        [DataMember]
        public decimal GdNetAmount { get; set; }
        [DataMember]
        public decimal Gdtax { get; set; }
        [DataMember]
        public decimal GdPayable { get; set; }
        [DataMember]
        public decimal GdPaid { get; set; }
        [DataMember]
        public decimal GdDue { get; set; }
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string PaymentModeName { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Invoice { get; set; }
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public decimal TotalDueAmount { get; set; }
        [DataMember]
        public decimal DueDiscount { get; set; }
        [DataMember]
        public decimal TotalDueDiscount { get; set; }        
        [DataMember]
        public decimal DuePayable { get; set; }
        [DataMember]
        public decimal DuePaid { get; set; }
        [DataMember]
        public decimal LastDuePaid { get; set; }        
        [DataMember]
        public decimal TotalDuePaid { get; set; }
        [DataMember]
        public decimal DueBalance { get; set; }
       

    }
}
