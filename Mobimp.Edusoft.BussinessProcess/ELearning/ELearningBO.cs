using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.ELearning;
using Mobimp.Edusoft.DataAccess.ELearning;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.ELearning
{
    public class ELearningBO
    {
        public int UpdateSubjectTeacherMapping(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.UpdateSubjectTeacherMapping(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchSubjectTeacherMapping(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchSubjectTeacherMapping(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetSubjectTeacherMappingByID(ELearningData objLearn)
        {
            List<ELearningData> result = null;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.GetSubjectTeacherMappingByID(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteSubjectTeacherMappingByID(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.DeleteSubjectTeacherMappingByID(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchDailyTeacherLiveClassList(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchDailyTeacherLiveClassList(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int StartDailyTeacherLiveClass(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.StartDailyTeacherLiveClass(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int EndDailyTeacherLiveClass(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.EndDailyTeacherLiveClass(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchTeacherNamebyUserLoginID(Int64 ID)
        {
            List<ELearningData> result = null;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchTeacherNamebyUserLoginID(ID);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetTotalStudents(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.GetTotalStudents(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetTotalStudentsAttended(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.GetTotalStudentsAttended(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchStudentDetailsbyUserLoginID(Int64 ID, int AcademicSessionID)
        {
            List<ELearningData> result = null;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchStudentDetailsbyUserLoginID(ID, AcademicSessionID);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchDailyStudentLiveClassList(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchDailyStudentLiveClassList(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int JoinDailyStudentLiveClass(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.JoinDailyStudentLiveClass(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateStudentAttendance(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.UpdateStudentAttendance(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetClassLinkByID(ELearningData objLearn)
        {
            List<ELearningData> result = null;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.GetClassLinkByID(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateTeachersClassVideoLink(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.UpdateTeachersClassVideoLink(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //Assignment
        public List<ELearningData> SearchTotalAssignmentsForRespectiveTeacher(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchTotalAssignmentsForRespectiveTeacher(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int AddAssignment(ELearningData objLearn)
        {
            int result = 0;

            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.AddAssignment(objLearn);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchAssignmentList(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchAssignmentList(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetStudentListByAssignmentID(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.GetStudentListByAssignmentID(objLearn);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchAssignmentListByStudentID(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                ELearningDA objLearnDA = new ELearningDA();
                result = objLearnDA.SearchAssignmentListByStudentID(objLearn);
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
