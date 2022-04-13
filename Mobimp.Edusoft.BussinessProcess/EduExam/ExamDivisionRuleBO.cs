using Mobimp.Campusoft.Data.EduExam;
using Mobimp.Campusoft.DataAccess.EduExam;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.EduExam
{
    public class ExamDivisionRuleBO
    {
        //For Div
        public int AddNewRowRecord(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.AddNewRowRecord(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int AddNewRowRecordForRemark(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.AddNewRowRecordForRemark(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int AddNewRowRecordForFailPass(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.AddNewRowRecordForFailPass(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int AddNewRowRecordForGrade(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.AddNewRowRecordForGrade(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamDivisionRuleData> GetExamDivisionRuleList(ExamDivisionRuleData objsubject)
        {
            List<ExamDivisionRuleData> result = null;

            try
            {
                ExamDivisionRuleDA objsubjectDA = new ExamDivisionRuleDA();
                result = objsubjectDA.GetExamDivisionRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamDivisionRuleData> GetExamFailPassRuleList(ExamDivisionRuleData objsubject)
        {
            List<ExamDivisionRuleData> result = null;

            try
            {
                ExamDivisionRuleDA objsubjectDA = new ExamDivisionRuleDA();
                result = objsubjectDA.GetExamFailPassRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamDivisionRuleData> GetExamRemarkRuleList(ExamDivisionRuleData objsubject)
        {
            List<ExamDivisionRuleData> result = null;

            try
            {
                ExamDivisionRuleDA objsubjectDA = new ExamDivisionRuleDA();
                result = objsubjectDA.GetExamRemarkRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamDivisionRuleData> GetExamGradeRuleList(ExamDivisionRuleData objsubject)
        {
            List<ExamDivisionRuleData> result = null;

            try
            {
                ExamDivisionRuleDA objsubjectDA = new ExamDivisionRuleDA();
                result = objsubjectDA.GetExamGradeRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamDivisionRuleData> GetExamRankRuleList(ExamDivisionRuleData objsubject)
        {
            List<ExamDivisionRuleData> result = null;

            try
            {
                ExamDivisionRuleDA objsubjectDA = new ExamDivisionRuleDA();
                result = objsubjectDA.GetExamGradeRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateExamDivisionRule(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.UpdateExamDivisionRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamRule(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.UpdateExamRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamFailPassRule(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.UpdateExamFailPassRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamRemarkRule(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.UpdateExamRemarkRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateExamGradeRule(ExamDivisionRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objDA = new ExamDivisionRuleDA();
                result = objDA.UpdateExamGradeRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteExamDivisionRuleByID(ExamDivisionRuleData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamDivisionRuleDA objstdloyeeDA = new ExamDivisionRuleDA();
                result = objstdloyeeDA.DeleteExamDivisionRuleByID(objexamMarks);

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
