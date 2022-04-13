using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class SubjectData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public bool ICompulsory { get; set; }
        [DataMember]
        public string Stream { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int SubjectCategoryID { get; set; }
        [DataMember]
        public string SubjectlistXML { get; set; }
        [DataMember]
        public int  IsGrade { get; set; }
        [DataMember]
        public int IsOptional { get; set; }
        [DataMember]
        public int IsAlternative { get; set; }
        [DataMember]
        public int IsMain { get; set; }
        [DataMember]
        public string Xmlsublist { get; set; }
        [DataMember]
        public string SubjectCategory { get; set; }
    }
    public class SubjectTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public bool ICompulsory { get; set; }
        [DataMember]
        public string Stream { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int SubjectCategoryID { get; set; }
        [DataMember]
        public string SubjectlistXML { get; set; }
        [DataMember]
        public int IsGrade { get; set; }
        [DataMember]
        public int IsOptional { get; set; }
        [DataMember]
        public int IsAlternative { get; set; }
        [DataMember]
        public int IsMain { get; set; }
        [DataMember]
        public string Xmlsublist { get; set; }

    }
}
