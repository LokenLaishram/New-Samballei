using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.DataAccess.EduEmployee;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduEmployee
{
  public class AssignSubjectBO
    {
      public int UpdateAssignDetails(AssignSubjectData objasign)
        {
            int result = 0;

            try
            {
                AssignSubjectDA objAssignSubjectDA = new AssignSubjectDA();
                result = objAssignSubjectDA.UpdateAssignDetails(objasign);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
      public List<AssignSubjectData> SearchAssignDetails(AssignSubjectData objasign)
        {

            List<AssignSubjectData> result = null;

            try
            {
                AssignSubjectDA objAssignSubjectDA = new AssignSubjectDA();
                result = objAssignSubjectDA.SearchAssignDetails(objasign);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AssignSubjectData> GetEmpnames(AssignSubjectData objasign)
        {

            List<AssignSubjectData> result = null;

            try
            {
                AssignSubjectDA objAssignSubjectDA = new AssignSubjectDA();
                result = objAssignSubjectDA.GetEmpnames(objasign);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AssignSubjectData> GetAssignDetailsByID(AssignSubjectData objasign)
        {
            List<AssignSubjectData> result = null;

            try
            {
                AssignSubjectDA objAssignSubjectDA = new AssignSubjectDA();
                result = objAssignSubjectDA.GetAssignDetailsByID(objasign);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteAssignDetailsByID(AssignSubjectData objasign)
        {
            int result = 0;

            try
            {
                AssignSubjectDA objAssignSubjectDA = new AssignSubjectDA();
                result = objAssignSubjectDA.DeleteAssignDetailsByID(objasign);

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
