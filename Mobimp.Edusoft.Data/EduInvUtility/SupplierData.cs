using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class SupplierData : BaseData
    {
        [DataMember]
        public int SupplierID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Supplier { get; set; }
        [DataMember]
        public int Type { get; set; }      
        [DataMember]
        public string ContactNo { get; set; }       

    }
    public class SupplierDatatoXL
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SupplierID { get; set; }
        [DataMember]
        public string Supplier { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public int Type { get; set; }

    }
}
