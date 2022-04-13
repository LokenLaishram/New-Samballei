using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class DepartmentData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class DepartmentDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Details { get; set; }
    }
}
