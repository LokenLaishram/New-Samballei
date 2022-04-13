using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class VendortypeData : BaseData
    {
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public string VendorType { get; set; }
    }
    public class VendortypeDatatoXL
    {
        [DataMember]
        public string VendorType { get; set; }
    }
}
