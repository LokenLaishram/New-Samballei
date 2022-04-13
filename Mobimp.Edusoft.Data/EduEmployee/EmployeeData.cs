using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduEmployee
{
    public class EmployeeData : BaseData
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public int EmployeeTypeID { get; set; }
        [DataMember]
        public int EmployeeCatgeroyID { get; set; }
        [DataMember]
        public int StaffTypeID { get; set; }
        [DataMember]
        public string EmployeeCode { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public int DesignationID { get; set; }
        [DataMember]
        public int CurrentCountryID { get; set; }
        [DataMember]
        public int CurrentStateID { get; set; }
        [DataMember]
        public int CurrentPIN { get; set; }
        [DataMember]
        public string CurrentLandMark { get; set; }
        [DataMember]
        public int CurrentDistrictID { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string DigitalSignatureLocation { get; set; }
        [DataMember]
        public string EmployeePhotoLocation { get; set; }
        [DataMember]
        public string CurrentAddress { get; set; }
        [DataMember]
        public string PermAddress { get; set; }
        [DataMember]
        public int PermCountryID { get; set; }
        [DataMember]
        public int PermStateID { get; set; }
        [DataMember]
        public int PermDistrictID { get; set; }
        [DataMember]
        public int PermPIN { get; set; }
        [DataMember]
        public string PermLandMark { get; set; }
        [DataMember]
        public int CastID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public int SalutationID { get; set; }
        [DataMember]
        public int ReligionID { get; set; }
        [DataMember]
        public string EmaildID { get; set; }
        [DataMember]
        public int MaritalStatusID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public string CurrCountry { get; set; }
        [DataMember]
        public string PerCountry { get; set; }
        [DataMember]
        public string CurrState { get; set; }
        [DataMember]
        public string PerState { get; set; }
        [DataMember]
        public string CurrDistrict { get; set; }
        [DataMember]
        public string PerDistrict { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string CastName { get; set; }
        [DataMember]
        public string EmployeeType { get; set; }
        [DataMember]
        public string MaritalStatus { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string Experience { get; set; }
        [DataMember]
        public DateTime DOJ { get; set; }
        [DataMember]
        public string IDmarks { get; set; }
        [DataMember]
        public int BloodGroupID { get; set; }
        [DataMember]
        public byte[] DigitalSignatureImage { get; set; }
        [DataMember]
        public byte[] EmployeePhotoImage { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public bool Istransfer { get; set; }
        [DataMember]
        public string ProfessionalQualification { get; set; }
        [DataMember]
        public string University { get; set; }
        [DataMember]
        public string EPF { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string AC { get; set; }
        [DataMember]
        public string ExcelDOB { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string RealPassword { get; set; }
        [DataMember]
        public string XmlEmployeeList { get; set; }
    }
    public class EmployeeAttendanceData : BaseData
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public int EmployeeTypeID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public DateTime LoginTime { get; set; }
        [DataMember]
        public DateTime LogoutTime { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int IsLogin { get; set; }
        [DataMember]
        public int IsLogout { get; set; }
        [DataMember]
        public string DaysName { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public string XmlEmployeeAttendancelist { get; set; }
        [DataMember]
        public int TotalPresent { get; set; }
        [DataMember]
        public int TotalAbsent { get; set; }
        [DataMember]
        public int TotalOnleave { get; set; }
    }
    public class EmployeeLeaveData : BaseData
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public int LeaveID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int NosDays { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public int LeaveStatus { get; set; }
        [DataMember]
        public string LeaveDocumentpath { get; set; }
        [DataMember]
        public string AprroveBy { get; set; }
        [DataMember]
        public string Lstatus { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public int ApprovedDays { get; set; }
        [DataMember]
        public DateTime ApprovedDate { get; set; }
        [DataMember]
        public string RejRemarks { get; set; }

    }
    public class userdetails : BaseData
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int LoginID { get; set; }
        [DataMember]
        public int UserLoginID { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string RealPassword { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserNewPassword { get; set; }
    }
    public class Logintrackdata : BaseData
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int LoginID { get; set; }
        [DataMember]
        public string Logintime { get; set; }
        [DataMember]
        public string LogOuttime { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
    }
    public class EmployeeSalary : BaseData
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public decimal SalaryAmount { get; set; }
        [DataMember]
        public int SalaryID { get; set; }
        [DataMember]
        public int SalaryGeneratorID { get; set; }
        [DataMember]
        public DateTime LastRevisedDate { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public decimal Basic { get; set; }
        [DataMember]
        public decimal Increament { get; set; }
        [DataMember]
        public decimal Bonus { get; set; }
        [DataMember]
        public decimal Incentives { get; set; }
        [DataMember]
        public decimal Allowance { get; set; }
        [DataMember]
        public decimal Surplus { get; set; }
        [DataMember]
        public decimal Proxy { get; set; }
        [DataMember]
        public decimal Subduction { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public decimal TotalPaidAmount { get; set; }
        [DataMember]
        public int TotalAbsent { get; set; }
        [DataMember]
        public int TotalOnleave { get; set; }
        [DataMember]
        public int SalaryStatus { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int EmployeeCategory { get; set; }
    }
    public class ExcelEmployeeList
    {
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string MotherTongue { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public int PIN { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string AadharNo { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string EmailID { get; set; }
    }
    public class EmployeeIDCardDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Class { get; set; }
    }
    public class ExcelAssignEmployeepassword
    {
        [DataMember]
        public Int64 EmployeeID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
    }
}
