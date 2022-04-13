using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    [Serializable]
    public class StockEntryWithoutPOData : BaseData
    {
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public float Quantity { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public int ConvertingUnitID { get; set; }
        [DataMember]
        public string ConvertingUnitName { get; set; }      
        [DataMember]
        public int NetQuantity { get; set; }
        [DataMember]
        public string Expirydate { get; set; }
        [DataMember]
        public int StockStatusID { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public string YearName { get; set; }
        [DataMember]
        public int EquivalentQty { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public string jsondata { get; set; }
        [DataMember]
        public Int64 StockID { get; set; }
        [DataMember]
        public string StockNo { get; set; }       
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }       
        [DataMember]
        public int CUnitID { get; set; }
        [DataMember]
        public string CUnitName { get; set; }
        [DataMember]
        public double RecievedQty { get; set; }
        [DataMember]
        public double NetRecievedQty { get; set; }
        [DataMember]
        public double NetIndentQty { get; set; }
        [DataMember]
        public double IssuedQty { get; set; }
        [DataMember]
        public double ReturnQty { get; set; }
        [DataMember]
        public double CondemnQty { get; set; }
        [DataMember]
        public double NetBalanceQty { get; set; }
        [DataMember]
        public DateTime RecievedDT { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public DateTime StkReceivedDate { get; set; }
        [DataMember]
        public string VendorDetails { get; set; }
        [DataMember]
        public string StockStatus { get; set; }

    }
}
