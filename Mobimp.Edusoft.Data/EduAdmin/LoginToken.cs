using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
    public class LoginToken
    {
        public LoginToken()
        {

        }
        //User Login detail
        [DataMember]
        public int UserLoginId { get; set; }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public string UserTypeCode { get; set; }
        [DataMember]
        public string UserTypeName { get; set; }
        [DataMember]
        public string LoginId { get; set; }
        [DataMember]
        public Guid LoginUniqueId { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int AcademicSessionID { get; set; }
        [DataMember]
        public string FinancialYearCode { get; set; }
        [DataMember]
        public string AcademicSessionName { get; set; }
        [DataMember]
        public int CompanyID { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string CompanyCode { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string CompanyPhoneSTDCode { get; set; }
        [DataMember]
        public string CompanyPhoneNo { get; set; }
        [DataMember]
        public string CompanyPhoneAltNo { get; set; }
        [DataMember]
        public string CompanyMobileNo { get; set; }
        [DataMember]
        public string CompanyFaxNo { get; set; }
        [DataMember]
        public string CompanyEmailID { get; set; }
        [DataMember]
        public string CompanyWebsite { get; set; }
        //Role Detail
        [DataMember]
        public string[] RoleNames { get; set; }
        [DataMember]
        public int[] RoleIds { get; set; }
        [DataMember]
        public int RoleID { get; set; }
        //Navigation Data
        [DataMember]
        public string NavigationXmlData { get; set; }
        //User Detail (It could be Employee, Customer, Suppilier etc)  
        [DataMember]
        public int UserDetailID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserCode { get; set; }
        [DataMember]
        public int DesignationID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public int MaritalStatusID { get; set; }
        [DataMember]
        public static int MgtTypeID { get; set; }
        [DataMember]
        // Access Role for Buttons such as Delete, Add, Print etc.
        public Boolean IsAddOn { get; set; }
        [DataMember]
        public Boolean IsModify { get; set; }
        [DataMember]
        public Boolean IsCancelOn { get; set; }
        [DataMember]
        public Boolean IsDeleteOn { get; set; }
        [DataMember]
        public Boolean IsPrintOn { get; set; }
        [DataMember]
        public Boolean IsPrintExportOn { get; set; }
        [DataMember]
        public Boolean IsChangeDateOn { get; set; }
        [DataMember]
        public Boolean IsChangeBranchOn { get; set; }
        [DataMember]
        public Boolean IsApproverReturnOn { get; set; }
        [DataMember]
        public Boolean IsApproverReimbursementOn { get; set; }
        [DataMember]
        public Boolean IsApproverRecievedOn { get; set; }
        [DataMember]
        public Boolean IsCheckOut { get; set; }
        [DataMember]
        public Boolean IsRateChangeOn { get; set; }
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
        [DataMember]
        public int MgtType { get; set; }
        [DataMember]
        public int IsActiveLogin { get; set; }
        [DataMember]
        public int EnableMultiLogin { get; set; }
    }
}
