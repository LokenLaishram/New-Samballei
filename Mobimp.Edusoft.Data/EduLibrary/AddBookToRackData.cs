using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduLibrary
{
    public class AddBookToRackData : BaseData
    {
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
        [DataMember]
        public string Books { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string XmlSubGrouplist { get; set; }
        [DataMember]
        public Int32 Qty { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int RackID { get; set; }
        [DataMember]
        public int BooksID { get; set; }
        [DataMember]
        public string BookDetails { get; set; }
    }
    public class AddBookToRackDatatoExcel
    {
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
    }
}
