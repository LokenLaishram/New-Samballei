using Mobimp.Campusoft.Data.EduFeeUtility;
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
    public class ExtraCuricularGradeBO
    {
        public int UpdateExtraCuricularGrade(ExamGradeData objdata)
        {
            int result = 0;

            try
            {
                ExtraCuricularDA objDA = new ExtraCuricularDA();
                result = objDA.UpdateExtraCuricularGrade(objdata);

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
                ExtraCuricularDA objsubjectDA = new ExtraCuricularDA();
                result = objsubjectDA.GetExtraCuricularGradeList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ExamGradeData> GetExtraCuricularGradeList(ExamGradeData objsubject)
        {
            List<ExamGradeData> result = null;

            try
            {
                ExtraCuricularDA objsubjectDA = new ExtraCuricularDA();
                result = objsubjectDA.GetExtraCuricularGradeByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteExtraCuricularGradeByID(ExamGradeData objexamMarks)
        {
            int result = 0;

            try
            {
                ExtraCuricularDA objstdloyeeDA = new ExtraCuricularDA();
                result = objstdloyeeDA.DeleteExtraCuricularGradeByID(objexamMarks);

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
