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
    public class DesignationBO
    {
        public int UpdateDesignationDetails(DesignationData objdesignation)
        {
            int result = 0;

            try
            {
                DesignationDA objdesignationDA = new DesignationDA();
                result = objdesignationDA.UpdateDesignationDetails(objdesignation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DesignationData> SearchDesignationDetails(DesignationData objdesignation)
        {

            List<DesignationData> result = null;

            try
            {
                DesignationDA objdesignationDA = new DesignationDA();
                result = objdesignationDA.SearchDesignationDetails(objdesignation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DesignationData> GetDesignationDetailsByID(DesignationData objdesignation)
        {
            List<DesignationData> result = null;

            try
            {
                DesignationDA objdesignationDA = new DesignationDA();
                result = objdesignationDA.GetDesignationDetailsByID(objdesignation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteDesignationDetailsByID(DesignationData objdesignation)
        {
            int result = 0;

            try
            {
                DesignationDA objdesignationDA = new DesignationDA();
                result = objdesignationDA.DeleteDesignationDetailsByID(objdesignation);

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
