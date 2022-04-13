using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    public class IndentGenerationData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
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
        public int TotalBalanceStock { get; set; }
        [DataMember]
        public decimal GdTotalPrice { get; set; }
        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public decimal DiscountValue { get; set; }
        [DataMember]
        public decimal FormPrice { get; set; }
        [DataMember]
        public decimal Payable { get; set; }
        [DataMember]
        public int IsApproved { get; set; }
        [DataMember]
        public string ApproveStatus { get; set; }
        [DataMember]
        public int BatchYearID { get; set; }
        [DataMember]
        public string YearName { get; set; }
        [DataMember]
        public string StockNo { get; set; }
        [DataMember]
        public int Stock { get; set; }

    }
    public class IndentDatatoXL
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
