using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Mobimp.Edusoft.Data.EduSMS
{
    public class SmsData : BaseData
    {
        //Template Manager
        [DataMember]
        public int TemplateID { get; set; }
        [DataMember]
        public string Template { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public string SuggestedParameter { get; set; }
        //Student
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string ExamData { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        //Employee
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int DesignationID { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public int StaffTypeID { get; set; }
        [DataMember]
        public string StaffTypeName { get; set; }

        //Common for Students and Employees
        [DataMember]
        public Int64 RecipientUniqueID { get; set; }
        [DataMember]
        public string RecipientName { get; set; }
        [DataMember]
        public Int64 SmsID { get; set; }
        [DataMember]
        public int SendTo { get; set; }
        [DataMember]
        public int SmsTypeID { get; set; }
        [DataMember]
        public int SMSCategoryID { get; set; }
        [DataMember]
        public string SentToDesc { get; set; }
        [DataMember]
        public string SmsTypeDesc { get; set; }
        [DataMember]
        public int CharCount { get; set; }
        [DataMember]
        public string DeliveredSMS { get; set; }
        [DataMember]
        public DateTime SentTime { get; set; }
        [DataMember]
        public string SentBy { get; set; }
        [DataMember]
        public int RecipientCount { get; set; }
        [DataMember]
        public int SmsCost { get; set; }
        [DataMember]
        public int TotalSmsCost { get; set; }
        [DataMember]
        public Int64 BalanceBefore { get; set; }
        [DataMember]
        public Int64 BalanceAfter { get; set; }
        [DataMember]
        public string ResponseID { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int StatusID { get; set; }
        [DataMember]
        public string HeaderStatus { get; set; }
        [DataMember]
        public int HeaderStatusID { get; set; }
        [DataMember]
        public string XmlSendSMS { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public DateTime SentDate { get; set; }
    }
    public class ImportSmsData : BaseData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        
    }
    public class SmsDatatoExcel
    {
        [DataMember]
        public string Template { get; set; }
        [DataMember]
        public string Description { get; set; }
        
    }
    public class ExcelSmsHeaderHistory
    {
        [DataMember]
        public Int64 SMSID { get; set; }
        [DataMember]
        public string SmsDescription { get; set; }
        [DataMember]
        public int TotalRecipients { get; set; }
        [DataMember]
        public int TotalSmsCost { get; set; }
        [DataMember]
        public string DateSent { get; set; }
        [DataMember]
        public string SentBy { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
