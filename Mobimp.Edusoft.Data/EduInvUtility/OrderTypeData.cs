using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class OrderTypeData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int OrderTypeID { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public int OrderTemplateID { get; set; }
        [DataMember]
        public string OrderTemplateName { get; set; }
        [DataMember]
        public string TemplateHeader { get; set; }
        [DataMember]
        public string DecodeTemplateHeader { get; set; }
        [DataMember]
        public string TemplateFooter { get; set; }
        [DataMember]
        public string DecodeTemplateFooter { get; set; }
    }
    public class OrderTypeDatatoXML
    {
        [DataMember]
        public string OrderType { get; set; }
    }
}
