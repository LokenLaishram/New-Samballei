using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class ItemData : BaseData
    {
        [DataMember]
        public Int64 Itemid { get; set; }
        [DataMember]
        public string Itemname { get; set; }
        [DataMember]
        public int Groupid { get; set; }
        [DataMember]
        public string Groupname { get; set; }
        [DataMember]
        public int Subgroupid { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitName { get; set; }
    }
    public class ItemDatatoXL
    {
        [DataMember]
        public string Itemname { get; set; }
        [DataMember]
        public string Groupname { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
        [DataMember]
        public string UnitName { get; set; }
    }

    public class ItemPriceData : BaseData
    {
        [DataMember]
        public Int64 ItemPriceID { get; set; }
        [DataMember]
        public Int64 Itemid { get; set; }
        [DataMember]
        public int Groupid { get; set; }
        [DataMember]
        public string Itemname { get; set; }
        [DataMember]
        public int Subgroupid { get; set; }
        [DataMember]
        public string Groupname { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public string YearName { get; set; }
        public string ItemDetails { get; set; }
    }
    public class ItemPriceDatatoXL

    {
        [DataMember]
        public string Itemname { get; set; }
        [DataMember]
        public string Groupname { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}
