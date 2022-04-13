using Mobimp.Campusoft.Data.EduFeeUtility;
using Mobimp.Campusoft.DataAccess.EduExam;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;

namespace Mobimp.Campusoft.BussinessProcess.EduExam
{
    public class ExamGradeBO
    {
        public int UpdateSubjectGrade(ExamGradeData objdata)
        {
            int result = 0;

            try
            {
                ExamGradeDA objDA = new ExamGradeDA();
                result = objDA.UpdateSubjectGrade(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ExamGradeData> GetSubjectGradeList(ExamGradeData objsubject)
        {
            List<ExamGradeData> result = null;

            try
            {
                ExamGradeDA objsubjectDA = new ExamGradeDA();
                result = objsubjectDA.GetSubjectGradeList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamGradeData> GetSubjectGradeByID(ExamGradeData objsubject)
        {
            List<ExamGradeData> result = null;

            try
            {
                ExamGradeDA objsubjectDA = new ExamGradeDA();
                result = objsubjectDA.GetSubjectGradeByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteSubjectGradeByID(ExamGradeData objexamMarks)
        {
            int result = 0;

            try
            {
                ExamGradeDA objstdloyeeDA = new ExamGradeDA();
                result = objstdloyeeDA.DeleteSubjectGradeByID(objexamMarks);

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
