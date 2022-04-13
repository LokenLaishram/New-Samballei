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
    public class ExamRemarkRuleBO
    {
        public int AddNewRowRecord(ExamRemarkRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamRemarkRuleDA objDA = new ExamRemarkRuleDA();
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
        public List<ExamRemarkRuleData> GetExamRemarkRuleList(ExamRemarkRuleData objsubject)
        {
            List<ExamRemarkRuleData> result = null;

            try
            {
                ExamRemarkRuleDA objsubjectDA = new ExamRemarkRuleDA();
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
        public int UpdateExamRemarkRule(ExamRemarkRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamRemarkRuleDA objDA = new ExamRemarkRuleDA();
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
        public int DeleteExamRemarkRuleByID(ExamRemarkRuleData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamRemarkRuleDA objstdloyeeDA = new ExamRemarkRuleDA();
                result = objstdloyeeDA.DeleteExamRemarkRuleByID(objexamMarks);

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
