using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduEmployee
{
    public class AssignSubjectData : BaseData
    {

        [DataMember]
        public int AssignID { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int StaffCategoryID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }

    }
}
