using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Data;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
    public class CreateUser : BaseData
    {
        [DataMember]
        public int LoginID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public string LoginDate { get; set; }
        [DataMember]
        public string LogOutDate { get; set; }
        [DataMember]
        public string LoginTime { get; set; }
        [DataMember]
        public string Logintime { get; set; }
        [DataMember]
        public string LogOuttime { get; set; }
        [DataMember]
        public string LogOutTime { get; set; }
        [DataMember]
        public int scheduleID { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public int AcademicSessionID { get; set; }
        [DataMember]
        public string AcademicSessionName { get; set; }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public int SiteMapID { get; set; }
        [DataMember]
        public string IPaddress { get; set; }
        [DataMember]
        public int SaveEnable { get; set; }
        [DataMember]
        public int UpdateEnable { get; set; }
        [DataMember]
        public int SearchEnable { get; set; }
        [DataMember]
        public int EditEnable { get; set; }
        [DataMember]
        public int DeleteEnable { get; set; }
        [DataMember]
        public int PrintEnable { get; set; }
        [DataMember]
        public int ExportEnable { get; set; }
        [DataMember]
        public int AmountEnable { get; set; }

    }
}
