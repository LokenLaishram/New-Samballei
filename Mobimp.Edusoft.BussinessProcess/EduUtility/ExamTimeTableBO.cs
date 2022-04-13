using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
   public class ExamTimeTableBO
   {
        public int UpdateExamscheduler(ExamSchedulerData objexamscheduler)
        {
            int result = 0;

            try
            {
                ExamTimeTableDA objexamschedulerDA = new ExamTimeTableDA();
                result = objexamschedulerDA.UpdateExamscheduler(objexamscheduler);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamSchedulerData> SearchExamscheduler(ExamSchedulerData objexamscheduler)
        {

            List<ExamSchedulerData> result = null;

            try
            {
                ExamTimeTableDA objexamschedulerDA = new ExamTimeTableDA();
                result = objexamschedulerDA.SearchExamscheduler(objexamscheduler);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamSchedulerData> GetExamschedulerByID(ExamSchedulerData objexamscheduler)
        {
            List<ExamSchedulerData> result = null;

            try
            {
                ExamTimeTableDA objexamschedulerDA = new ExamTimeTableDA();
                result = objexamschedulerDA.GetExamschedulerByID(objexamscheduler);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteExamschedulerByID(ExamSchedulerData objexamscheduler)
        {
            int result = 0;

            try
            {
                ExamTimeTableDA objexamschedulerDA = new ExamTimeTableDA();
                result = objexamschedulerDA.DeleteExamschedulerByID(objexamscheduler);

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
