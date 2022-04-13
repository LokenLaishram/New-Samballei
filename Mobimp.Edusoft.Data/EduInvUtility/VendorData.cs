using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class VendorData : BaseData
    {
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public string VendorType { get; set; }
        [DataMember]
        public string VendorCode { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public string GSTIN { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
    public class VendorDatatoXL
    {
        [DataMember]
        public string VendorType { get; set; }
        [DataMember]
        public string VendorName { get; set; }
    }
}
