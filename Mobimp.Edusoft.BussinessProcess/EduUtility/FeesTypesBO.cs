using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.BussinessProcess.EduUtility
{
    public class FeesTypesBO
    {
        public int UpdateFeeTypes(FeesData objfees)
        {
            int result = 0;

            try
            {
                FeesTypesDA objfeesDA = new FeesTypesDA();
                result = objfeesDA.UpdateFeeTypes(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeesData> SearchFeesDetails(FeesData objfees)
        {
            List<FeesData> result = null;

            try
            {
                FeesTypesDA objfeesDA = new FeesTypesDA();
                result = objfeesDA.SearchFeesDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeesData> GetFeesDetailsByID(FeesData objfees)
        {
            List<FeesData> result = null;

            try
            {
                FeesTypesDA objfeesDA = new FeesTypesDA();
                result = objfeesDA.GetFeesDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteFeesDetailsByID(FeesData objfeetype)
        {
            int result = 0;

            try
            {
                FeesTypesDA objfeetypeDA = new FeesTypesDA();
                result = objfeetypeDA.DeleteFeesDetailsByID(objfeetype);

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
