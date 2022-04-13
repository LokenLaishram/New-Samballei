using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
    public class AddUsersData : BaseData
    {
        [DataMember]
        public int LoginID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public DateTime AddedDate { get; set; }
         [DataMember]
        public int AcademicSessionID { get; set; }
        [DataMember]
        public int MgtTypeID { get; set; }
       
    }
}
