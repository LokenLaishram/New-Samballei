using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    [Serializable]
    public class AcademicSessionData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string ExcelStatus { get; set; }

    }
    public class AcademicSessionDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
}
