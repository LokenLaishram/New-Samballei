using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Mobimp.Edusoft.Web.AppCode
{
    public class Messagealert_
    {
        public static void ShowMessage(Label lbl, string message, int msgType)
        {
            message = message.ToLower() == "system" ? "System could not process your request, please try again." : message;
            message = message.ToLower() == "save" ? "Saved Successfully." : message;
            message = message.ToLower() == "Paid" ? "Paid Successfully." : message;
            message = message.ToLower() == "update" ? "Updated Successfully." : message;
            message = message.ToLower() == "Error" ? "Could Not Updated Successfully." : message;
            message = message.ToLower() == "delete" ? "Deleted Successfully." : message;
            message = message.ToLower() == "Remark" ? "Please enter remark." : message;
            message = message.ToLower() == "Login" ? "Login Successfully." : message;
            message = message.ToLower() == "Logout" ? "Logout Successfully." : message;
            message = message.ToLower() == "BlankPassword" ? "Please enter password." : message;
            message = message.ToLower() == "Password" ? "Please use correct password." : message;
            message = message.ToLower() == "Promotedclass" ? "Please select same or higher class." : message;
            message = message.ToLower() == "checkadmission" ? "Admission No. cannot be NULL for Old Adm.Type." : message;
            message = message.ToLower() == "duplicate" ? "Already Exist." : message;
            message = message.ToLower() == "register" ? "Not Registered." : message;
            message = message.ToLower() == "checkduplicateadmissionno" ? "Admission number already exist." : message;
            message = message.ToLower() == "checkdoubleadmissionno" ? "More than one same Admission number exist can't update." : message;
            message = message.ToLower() == "checkduplicatestudent" ? "Already done admission for the current academic session." : message;
            message = message.ToLower() == "checkadmissionno" ? "Sory! Can't update Admission number does not exist." : message;
            message = message.ToLower() == "checkadmissionfee" ? "Already paid." : message;
            message = message.ToLower() == "grid" ? "No record found." : message;
            message = message.ToLower() == "Paid Amount Should be equal to total Fee amount." ? "Paid Amount Should be equal to total Fee amount." : message;
            message = message.ToLower() == "Please enter remarks" ? "Please enter remarks." : message;
            message = message.ToLower() == "OldAdmissionNoNull" ? "Please enter Admission No. for old Student" : message;
            message = message.ToLower() == "CheckFeeAmount" ? "Pls Check Fee Amount!" : message;
            lbl.Visible = true;
            lbl.Text = message;
            //  lbl.CssClass = msgType == 1 ? "success-alert" : "Message";
            return;
        }
        public static string Alertmessage(string message)
        {
            message = message.Trim() == "system" ? "System could not process your request, please try again." : message;
            message = message.Trim() == "save" ? "Saved Successfully." : message;
            message = message.Trim() == "Add" ? "Successfully Added." : message;
            message = message.Trim() == "Import" ? "Data imported successfully." : message;
            message = message.Trim() == "Paid" ? "Paid Successfully." : message;
            message = message.Trim() == "upload" ? "Successfully uploaded." : message;
            message = message.Trim() == "Activate" ? "Succesffuly Activated." : message;
            message = message.Trim() == "update" ? "Updated Successfully." : message;
            message = message.Trim() == "Error" ? "Could Not Updated Successfully." : message;
            message = message.Trim() == "delete" ? "Deleted Successfully." : message;
            message = message.Trim() == "Remark" ? "Please enter remark." : message;
            message = message.Trim() == "Login" ? "Login Successfully." : message;
            message = message.Trim() == "Logout" ? "Logout Successfully." : message;
            message = message.Trim() == "BlankPassword" ? "Please enter password." : message;
            message = message.Trim() == "Password" ? "Please use correct password." : message;
            message = message.Trim() == "Promotedclass" ? "Please select same or higher class." : message;
            message = message.Trim() == "checkadmission" ? "Admission No. cannot be NULL for Old Adm.Type." : message;
            message = message.Trim() == "duplicate" ? "Already Exist." : message;
            message = message.Trim() == "SameRollSameSec" ? "There is duplicate roll numbers." : message;
            message = message.Trim() == "register" ? "Not Registered." : message;
            message = message.Trim() == "checkduplicateadmissionno" ? "Admission number already exist." : message;
            message = message.Trim() == "checkdoubleadmissionno" ? "More than one same Admission number exist can't update." : message;
            message = message.Trim() == "checkduplicatestudent" ? "Already done admission for the current academic session." : message;
            message = message.Trim() == "checkadmissionno" ? "Sory! Can't update Admission number does not exist." : message;
            message = message.Trim() == "checkadmissionfee" ? "Already paid." : message;
            message = message.Trim() == "grid" ? "No record found." : message;
            message = message.Trim() == "Paid Amount Should be equal to total Fee amount." ? "Paid Amount Should be equal to total Fee amount." : message;
            message = message.Trim() == "Please enter remarks" ? "Please enter remarks." : message;
            message = message.Trim() == "OldAdmissionNoNull" ? "Please enter Admission No. for old Student." : message;
            message = message.Trim() == "Class" ? "Please select class." : message;
            message = message.Trim() == "mark" ? "Please enter correct mark." : message;
            message = message.Trim() == "publish" ? "Successfully published the result." : message;
            message = message.Trim() == "markentry" ? "please complete mark entry." : message;
            message = message.Trim() == "section" ? "please select section." : message;
            message = message.Trim() == "Class" ? "please select class." : message;
            message = message.Trim() == "Checkexmsteps" ? "Please check all the exam steps. " +
                                        "1. Exam mark details " +
                                        "2. Exam mark entry subject list. " +
                                        "3. publish the result." : message;
            message = message.Trim() == "session" ? "Please select session." : message;
            message = message.Trim() == "class" ? "Please select class." : message;
            message = message.Trim() == "from" ? "Please enter period starts from." : message;
            message = message.Trim() == "to" ? "Please enter period end to." : message;
            message = message.Trim() == "Period" ? "Please enter no. period." : message;
            message = message.Trim() == "Pduartion" ? "Please enter period duration." : message;
            message = message.Trim() == "Recess" ? "Please enter no. recess." : message;
            message = message.Trim() == "Precess" ? "Please enter recess duration." : message;
            message = message.Trim() == "Recessperiod" ? "Please enter recess periods." : message;
            message = message.Trim() == "Group" ? "Please select group." : message;
            message = message.Trim() == "PeriodCorrection" ? "Total period not equal to total alloted subject.Please check the subject counts." : message;
            message = message.Trim() == "Timetableruleexist" ? "Already exist the rule." : message;
            message = message.Trim() == "Convenience" ? "Please Enter Convenience charge." : message;
            message = message.Trim() == "Paymode" ? "Please select payment mode." : message;
            message = message.Trim() == "reciept" ? "Please upload payment receipt." : message;
            message = message.Trim() == "Duepay" ? "Please pay all the due months." : message;
            message = message.Trim() == "paidamount" ? "Payable amount is zero.You can not proceed." : message;
            message = message.Trim() == "Billdate" ? "Please enter bill date." : message;
            message = message.Trim() == "FailStartingOnlineClass" ? "Could not Start Class. Please contact Admin." : message;
            message = message.Trim() == "FailEndingOnlineClass" ? "Could not end Class. Please contact Admin." : message;
            message = message.Trim() == "SuccessEndingOnlineClass" ? "Class ended successfully." : message;
            message = message.Trim() == "Day" ? "Please select a day." : message;
            message = message.Trim() == "DateOutOfRange" ? "Please select a Date of current month or earlier." : message;
            message = message.Trim() == "OngoingTeacherClass" ? "Cannot Update an ongoing class. Concerned Teacher has alreeady started the class." : message;
            message = message.Trim() == "OngoingStudentClass" ? "Cannot Update an ongoing class. Students have already joined the class." : message;
            message = message.Trim() == "DeleteOnlineClass" ? "Cannot delete an ongoing class." : message;
            message = message.Trim() == "TimeError" ? "Please select appropriate Time." : message;
            message = message.Trim() == "File" ? "Please select the file to be uploaded." : message;
            message = message.Trim() == "FileExtension" ? "Please select a jpg file or pdf file." : message;
            return message;
        }
    }
}