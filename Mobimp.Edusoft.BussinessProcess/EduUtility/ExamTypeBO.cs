using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class ExamTypeBO
    {
        public int UpdateExamtypeDetails(ExamTypeData objexam)
        {
            int result = 0;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.UpdateExamtypeDetails(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteStudentfromexamlist(Examdata objexam)
        {
            int result = 0;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.DeleteStudentfromexamlist(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int SubjectwiseAddStudent(Examdata objexam)
        {
            int result = 0;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.SubjectwiseAddStudent(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Examdata> GetSubjectWiseStudentList(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetSubjectWiseStudentList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int ProcessVerification(ExamTypeData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.ProcessVerification(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamTypeData> Getyearwiseexamlist(ExamTypeData objexam)
        {

            List<ExamTypeData> result = null;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.Getyearwiseexamlist(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteExamByID(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.DeleteExamByID(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Examdata> GetExamNameByID(Examdata objsubject)
        {
            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetExamNameByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> GetExamList(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetExamList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateExamName(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateExamName(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> SearchexamSubjectDetails(Examdata objsubject)
        {
            List<Examdata> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.SearchexamSubjectDetails(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateCorrectRanklist(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateCorrectRanklist(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int PromoteStudent(PromoteSrudent objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.PromoteStudent(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamMarkslist(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateExamMarkslist(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int PublishExamresult(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.PublishExamresult(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int PublishExamresultF(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.PublishExamresultF(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int ProcessExamresult(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.ProcessExamresult(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int CalculateExamresult(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.CalculateExamresult(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int ProsessResultSummary(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.ProsessResultSummary(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Examdata> GetstudentRankDetails(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetstudentRankDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> GetPromoteStudent(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetPromoteStudent(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> GetClassTopper(Examdata objsubject)
        {
            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetClassTopper(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteWrongrecords(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.DeleteWrongrecords(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamMarks(ExamTypeData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateExamMarks(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateClassExamMarkslist(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateClassExamMarkslist(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateSubjectWiseExamMarkslist(ExammarkentryData objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateSubjectWiseExamMarkslist(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int updateonlineexammanager(OnlineExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.updateonlineexammanager(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Publishresult(ExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.Publishresult(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Publishoverallresult(ExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.Publishoverallresult(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamTypeData> SearchExamtypeDetails(ExamTypeData objexam)
        {

            List<ExamTypeData> result = null;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.SearchExamtypeDetail(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Examdata> GetstudenrmarkDetails(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetstudenrmarkDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamsubjectData> GetSubjectWiseMarkDetails(ExamsubjectData objsubject)
        {
            List<ExamsubjectData> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetSubjectWiseMarkDetails(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamresultData> GetExamresultlist(ExamresultData objsubject)
        {
            List<ExamresultData> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetExamresultlist(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<OnlineExamresultData> GetonlineexamResults(OnlineExamresultData objsubject)
        {
            List<OnlineExamresultData> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetonlineexamResults(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<OnlineExamresultData> GetgetexamresultbyStudentID(OnlineExamresultData objsubject)
        {
            List<OnlineExamresultData> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetgetexamresultbyStudentID(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExammarkentryData> Getsubjectwisestudentlist(ExammarkentryData objsubject)
        {
            List<ExammarkentryData> result = null;
            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.Getsubjectwisestudentlist(objsubject);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamTypeData> GetExamtypeDetailsByID(ExamTypeData objexam)
        {
            List<ExamTypeData> result = null;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.GetExamtypeDetailByID(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteExamtypeDetailsByID(ExamTypeData objexam)
        {
            int result = 0;

            try
            {
                ExamTypeDA objexamDA = new ExamTypeDA();
                result = objexamDA.DeleteExamtypeDetailByID(objexam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //Manual attendence
        public List<AttendanceData> GetstudAttendanceDetails(AttendanceData objAttendance)
        {
            List<AttendanceData> result = null;
            try
            {
                ExamTypeDA objDA = new ExamTypeDA();
                result = objDA.GetstudAttendanceDetails(objAttendance);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int Updatestudattendlist(AttendanceData objexamMarks)
        {
            int result = 0;
            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.Updatestudattendlist(objexamMarks);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> GetStudentRankResult(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetStudentRankResult(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //////////////////////////////////////////////////////////////////////////
        public int UpdateStudentRankResult(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.UpdateStudentRankResult(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        /////////////////////////////////////////////////////////////////////////
        public List<Examdata> GetCTPCertifcateDetails(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubjectDA = new ExamTypeDA();
                result = objsubjectDA.GetCTPCertifcateDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int CreateCTPCertificate(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.CreateCTPCertificate(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<Examdata> SubCount(Examdata objsubcount)
        {
            List<Examdata> result = null;

            try
            {
                ExamTypeDA objsubcountDA = new ExamTypeDA();
                result = objsubcountDA.SubCount(objsubcount);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        ////////////////////////////////////////////////////
        public int OverallProcessExamresult(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.OverallProcessExamresult(objexamMarks);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int PublishOverallResultP(Examdata objexamMarks)
        {
            int result = 0;

            try
            {
                ExamTypeDA objstdloyeeDA = new ExamTypeDA();
                result = objstdloyeeDA.PublishOverallResultP(objexamMarks);

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
