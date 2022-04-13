using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
/****************************************************
  Description of the class	    : BaseData
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.Data.Common
{
    [Serializable]
    public class BaseData
    {
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public Int64 DeletedUserId { get; set; }
        [DataMember]
        public String DeletedBy { get; set; }
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public DateTime AddedDate { get; set; }
        [DataMember]
        public DateTime DeletedDatetime { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public EnumActionType ActionType;
        [DataMember]
        public int tab;
        [DataMember]
        public int Rememberpassword;
        [DataMember]
        public int AcademicSessionID { get; set; }
        [DataMember]
        public string AcademicSessionName { get; set; }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string IsActiveALL { get; set; }
        [DataMember]
        public DateTime AddedDTM { get; set; }
        [DataMember]
        public string LastModBy { get; set; }
        [DataMember]
        public DateTime LastModDTM { get; set; }
        [DataMember]
        public int CurrentIndex { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int MaximumRows { get; set; }
        [DataMember]
        public string XMLData { get; set; }
        [DataMember]
        public int MgtType { get; set; }
        //Item
        [DataMember]
        public string StudentDetail { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassIsActive { get; set; }
        [DataMember]
        public string SubIsActive { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public DateTime Billdate { get; set; }
        [DataMember]
        public string classname { get; set; } 
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public int Output { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public byte[] Paymentreceipt { get; set; }
    }

}
