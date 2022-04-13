using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.DataAccess.EduFeeUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.BussinessProcess.EduFeeUtility
{
    public class OneTimePaymentBO
    {
        public List<OneTimePaymentData> GetOneTimePaymentList(OneTimePaymentData objpayment)
        {
            List<OneTimePaymentData> result = null;
            try
            {
                OneTimePaymentDA objpaymentDA = new OneTimePaymentDA();
                result = objpaymentDA.GetOneTimePaymentList(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateOneTimePayment(OneTimePaymentData objonetime)
        {
            int result = 0;
            try
            {
                OneTimePaymentDA objfeesDA = new OneTimePaymentDA();
                result = objfeesDA.UpdateOneTimePayment(objonetime);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteOneTimeByID(OneTimePaymentData objonetime)
        {
            int result = 0;
            try
            {
                OneTimePaymentDA objfeesDA = new OneTimePaymentDA();
                result = objfeesDA.DeleteOneTimeByID(objonetime);

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
