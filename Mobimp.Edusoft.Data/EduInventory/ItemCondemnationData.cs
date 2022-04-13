using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    [Serializable]
    public class ItemCondemnationData : BaseData
    {
        [DataMember]
        public string CondemnNo { get; set; }
        [DataMember]
        public string StockNo { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public double NetRecievedQty { get; set; }
        [DataMember]
        public double NetBalanceQty { get; set; }
        [DataMember]
        public float CondemnQty { get; set; }
        [DataMember]
        public int CondemnTypeID { get; set; }
        [DataMember]
        public string CondemnType { get; set; }
        [DataMember]
        public string CondemnRemark { get; set; }
    }
}
