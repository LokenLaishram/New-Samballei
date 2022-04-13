using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    [Serializable]
    public class StockStatusData : BaseData
    {
        [DataMember]
        public Int64 StockID { get; set; }
        [DataMember]
        public string StockNo { get; set; }      
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string SubGroupName { get; set; } 
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
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
        public double GdRecievedQty { get; set; }       
        [DataMember]
        public double GdIssuedQty { get; set; }
        [DataMember]
        public double GdReturnQty { get; set; }
        [DataMember]
        public double GdCondemnQty { get; set; }
        [DataMember]
        public double GdBalanceQty { get; set; }
        [DataMember]
        public double GdIndentQty { get; set; }
        [DataMember]
        public DateTime RecievedDT { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public int StockStatusID { get; set; }


    }
}
