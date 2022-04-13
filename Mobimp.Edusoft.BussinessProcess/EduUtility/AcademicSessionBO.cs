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
    public class AcademicSessionBO
    {
        public int UpdateAcademicSession(AcademicSessionData objAcademic)
        {

            int result = 0;

            try
            {
                AcademicSessionDA objSessionDA = new AcademicSessionDA();
                result = objSessionDA.UpdateAcademicSession(objAcademic);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AcademicSessionData> SearchAcademicSessionDetails(AcademicSessionData objAcademic)
        {

            List<AcademicSessionData> result = null;

            try
            {
                AcademicSessionDA objSessionDA = new AcademicSessionDA();
                result = objSessionDA.SearchAcademicSessionDetails(objAcademic);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AcademicSessionData> GetAcademicSessionDetailsByID(AcademicSessionData objAcademic)
        {
            List<AcademicSessionData> result = null;

            try
            {
                AcademicSessionDA objSessionDA = new AcademicSessionDA();
                result = objSessionDA.GetAcademicSessionDetailsByID(objAcademic);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteAcademicSessionDetailsByID(AcademicSessionData objAcademic)
        {
            int result = 0;

            try
            {
                AcademicSessionDA objSessionDA = new AcademicSessionDA();
                result = objSessionDA.DeleteAcademicSessionDetailsByID(objAcademic);

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
