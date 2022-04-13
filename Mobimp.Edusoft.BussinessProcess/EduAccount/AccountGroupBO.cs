using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduAccount;
using Mobimp.Edusoft.DataAccess.EduAccount;

namespace Mobimp.Edusoft.BussinessProcess.EduAccount
{
    public class AccountGroupBO
    {
        public int UpdateAccountGroupDetails(AccountGroupData objclass)
        {
            int result = 0;

            try
            {
                AccountGroupDA objclassDA = new AccountGroupDA();
                result = objclassDA.UpdateAccountGroupDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AccountGroupData> SearchAccountGroupDetails(AccountGroupData objclass)
        {
            List<AccountGroupData> result = null;
            try
            {
                AccountGroupDA objclassDA = new AccountGroupDA();
                result = objclassDA.SearchAccountGroupDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AccountGroupData> GetAccountGroupDetailsByID(AccountGroupData objclass)
        {
            List<AccountGroupData> result = null;

            try
            {
                AccountGroupDA objclassDA = new AccountGroupDA();
                result = objclassDA.GetAccountGroupDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteAccountGroupDetailsByID(AccountGroupData objclass)
        {
            int result = 0;

            try
            {
                AccountGroupDA objclassDA = new AccountGroupDA();
                result = objclassDA.DeleteAccountGroupDetailsByID(objclass);

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
