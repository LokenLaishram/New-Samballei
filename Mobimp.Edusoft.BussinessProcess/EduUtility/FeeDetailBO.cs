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
    public class FeeDetailBO
    {
        public int UpdateFeesDetails(FeesData objfees)
        {
            int result = 0;

            try
            {
                FeeDetailDA objfeesDA = new FeeDetailDA();
                result = objfeesDA.UpdateFeesDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateBreakupFeesDetails(FeesData objfees)
        {
            int result = 0;

            try
            {
                FeeDetailDA objfeesDA = new FeeDetailDA();
                result = objfeesDA.UpdateBreakupFeesDetails(objfees);

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
                FeeDetailDA objfeesDA = new FeeDetailDA();
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
        public List<FeesData> SearchBreakupFeesDetails(FeesData objfees)
        {

            List<FeesData> result = null;

            try
            {
                FeeDetailDA objfeesDA = new FeeDetailDA();
                result = objfeesDA.SearchBreakupFeesDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeesData> SearchMonthlyFeesDetails(FeesData objfees)
        {

            List<FeesData> result = null;

            try
            {
                FeeDetailDA objfeesDA = new FeeDetailDA();
                result = objfeesDA.SearchMonthlyFeesDetails(objfees);

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
                FeeDetailDA objfeesDA = new FeeDetailDA();
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
        

        public int DeleteFeesDetailsByID(FeesData objfees)
        {
            int result = 0;

            try
            {
                FeeDetailDA objfeesDA = new FeeDetailDA();
                result = objfeesDA.DeleteFeesDetailsByID(objfees);

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
