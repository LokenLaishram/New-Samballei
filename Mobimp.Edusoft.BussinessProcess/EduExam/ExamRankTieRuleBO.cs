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
    public class ExamRankTieRuleBO
    {
        public int AddNewRowRecord(ExamRankTieRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamRankTieDA objDA = new ExamRankTieDA();
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
        public List<ExamRankTieRuleData> GetExamRankTieRuleList(ExamRankTieRuleData objsubject)
        {
            List<ExamRankTieRuleData> result = null;

            try
            {
                ExamRankTieDA objsubjectDA = new ExamRankTieDA();
                result = objsubjectDA.GetExamRankTieRuleList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateExamRankTieRule(ExamRankTieRuleData objdata)
        {
            int result = 0;

            try
            {
                ExamRankTieDA objDA = new ExamRankTieDA();
                result = objDA.UpdateExamRankTieRule(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteExamRankTieRuleByID(ExamRankTieRuleData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamRankTieDA objstdloyeeDA = new ExamRankTieDA();
                result = objstdloyeeDA.DeleteExamRankTieRuleByID(objexamMarks);

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
