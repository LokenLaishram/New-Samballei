using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
   public class IndentSaleData:BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string SaleNo { get; set; }
        [DataMember] 
        public string BillNo { get; set; }
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
        public decimal GdDiscountValue { get; set; } 
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
        public DateTime BankPaymentDate { get; set; }
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string PaymentModeName { get; set; }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Invoice { get; set; }
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public int BatchYearID { get; set; }
        [DataMember]
        public string YearName { get; set; }
        [DataMember]
        public string StockNo { get; set; }
        [DataMember]
        public decimal Stock { get; set; }

        //-----RELEASED STOCK---//
        [DataMember]
        public int TotalApprovedQty { get; set; }
        [DataMember]
        public int TotalReleasedQty { get; set; }
        [DataMember]
        public int NowReleasedQty { get; set; }
        [DataMember]
        public int TotalDueReleasedQty { get; set; }       
        [DataMember]
        public int GdTotalApprovedQty { get; set; }
        [DataMember]
        public int GdTotalReleasedQty { get; set; }
        [DataMember]
        public int GdTotalReleasedNow { get; set; }
        [DataMember]
        public int GdTotalDueReleasedQty { get; set; }       
        [DataMember]
        public int NetApprovedQty { get; set; }
        [DataMember]
        public int NetReleasedQty { get; set; }
        [DataMember]
        public int NetDueRelease { get; set; }
        [DataMember]
        public int IsItemReleasedClosed { get; set; }
        [DataMember]
        public int IsReleasedClosed { get; set; }
        [DataMember]
        public int ReleasedStatusID { get; set; }
        [DataMember]
        public string ReleasedStatus { get; set; }
        [DataMember]
        public string ReleasedNo { get; set; }
    }
    public class IndentSaleDatatoXL
    {
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemCode { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int IndentQty { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
    }
}
