using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.DataAccess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduFees;

namespace Mobimp.Edusoft.BussinessProcess.EduStudent
{
    public class AddstudentBO
    {
        public int UpdateStudentDetails(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentDetailData> GetnewregistrationbyID(StudentDetailData obj)
        {

            List<StudentDetailData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetnewregistrationbyID(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteRegistrationDetailsByID(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.DeleteRegistrationDetailsByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetregistrationdetailbyID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetregistrationdetailbyID(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetOnlineregistrationlist(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetOnlineregistrationlist(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateonlineregistartionDetails(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateonlineregistartionDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentPasswordlist(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentPasswordlist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int AcitvateStudent(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.AcitvateStudent(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentNames(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA StudentDA = new AddstudentDA();
                result = StudentDA.GetStudentNames(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetHostelStudentNames(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA StudentDA = new AddstudentDA();
                result = StudentDA.GetHostelStudentNames(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentID(StudentData objemp)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetStudentID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetHostelStudentID(StudentData objemp)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetHostelStudentID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentDetailData> GetStudentdetailbyRoll(StudentDetailData obj)
        {

            List<StudentDetailData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetStudentdetailbyRoll(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentDetailData> GetcurrentStudentdetailbyRoll(StudentDetailData obj)
        {

            List<StudentDetailData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetcurrentStudentdetailbyRoll(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentDetailData> GetcurrentStudentdetailbyStudentID(StudentDetailData obj)
        {

            List<StudentDetailData> result = null;

            try
            {
                AddstudentDA objEmployeeDA = new AddstudentDA();
                result = objEmployeeDA.GetcurrentStudentdetailbyStudentID(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentRollnos(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentRollnos(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentpassword(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentpassword(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateSubjects(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateSubjects(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpLoadStudentPhoto(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpLoadStudentPhoto(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentTransportlist(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentTransportlist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentAttenedance(StudentAttendance objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentAttenedance(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateRegdDetails(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateRegdDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateAdmissionDetails(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateAdmissionDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
       
        public int Updateexpenditure(Expenditure objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Updateexpenditure(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }       
        public List<StudentData> SearchStudentDetails(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchStudentDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentList(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentList(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentListoexcel(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentListoexcel(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }       
        public List<Expenditure> SearchExpendtiureDetails(Expenditure objstd)
        {

            List<Expenditure> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchExpendtiureDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
       
        public List<StudentData> GetstudentDetailByID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<StudentData> GetStudentDetailByName(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentDetailByName(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<StudentData> GetBroaderstudentDetailByID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetBroaderstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetHostelStudentByID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetHostelStudentByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetHostelStudentByName(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetHostelStudentByName(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> Getclasswisestudentlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getclasswisestudentlist(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AutoRollData> Getautogenartedrollnumberst(AutoRollData objstd)
        {
            List<AutoRollData> result = null;
            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getautogenartedrollnumberst(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> Getclass910tudentlist(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getclass910tudentlist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetclassstudentPhotolist(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetclassstudentPhotolist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentAttendance> Getclasswisesattendancetudentlist(StudentAttendance objstd)
        {

            List<StudentAttendance> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getclasswisesattendancetudentlist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetStudentListRegd(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentListRegd(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<StudentData> Getclasswisetransportstudentlist(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getclasswisetransportstudentlist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentAttendance> Getclasswisesattendancelist(StudentAttendance objstd)
        {

            List<StudentAttendance> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Getclasswisesattendancelist(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<GetTodaysDateDetails> GetdateDetails(GetTodaysDateDetails objstd)
        {

            List<GetTodaysDateDetails> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetdateDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> SearchStudentDetailsByID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchStudentDetailsByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> GetCsubjectlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetCsubjectlist(objstd);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteStudentDetailsByID(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.DeleteStudentDetailsByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        
        public int DeleteExpenditureByID(Expenditure objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.DeleteExpenditureByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int CreatePTcertficate(ProvisionalTransfer objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.CreatePTcertficate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ProvisionalTransfer> SearchPTcertificate(ProvisionalTransfer objstd)
        {

            List<ProvisionalTransfer> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchPTcertificate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeletePTCertificateByID(ProvisionalTransfer objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.DeletePTCertificateByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<StudentData> SearchStudentProfile(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchStudentProfile(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        ///////////////////////Certificate//////////////////////////////////////////////
        public int Createcertficate(Characterdata objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Createcertficate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Updatecertficate(Characterdata objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Updatecertficate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Characterdata> GetStudentCharacterdata(Characterdata objstd)
        {

            List<Characterdata> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetStudentCharacterdata(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Characterdata> Searchcertificate(Characterdata objstd)
        {

            List<Characterdata> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.Searchcertificate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Characterdata> SearchCreatecertificate(Characterdata objstd)
        {

            List<Characterdata> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.SearchCreatecertificate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

  
        
        
        
        }

        ///////////////////////////////////////STUDENT EDITOR////////////////////////
        public List<StudentData> GetclasswisestudentIDDetails(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.GetclasswisestudentIDDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentIDDetails(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentIDDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentData> ActivatedStudentDetails(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.ActivatedStudentDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        // Update Student Profile 
        public int UpdateStudentProfileTab1(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab1(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab2(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab2(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab3(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab3(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab4(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab4(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab5(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab5(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab6(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab6(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab7(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab7(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab8(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab8(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateStudentProfileTab9(StudentData objstd)
        {
            int result = 0;

            try
            {
                AddstudentDA objstdloyeeDA = new AddstudentDA();
                result = objstdloyeeDA.UpdateStudentProfileTab9(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
    }
}
