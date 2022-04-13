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
    public class AccountLedgerBO
    {
        public int UpdateAccountLedgerDetails(AccountLedgerData objclass)
        {
            int result = 0;

            try
            {
                AccountLedgerDA objclassDA = new AccountLedgerDA();
                result = objclassDA.UpdateAccountLedgerDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AccountLedgerData> SearchAccountLedgerDetails(AccountLedgerData objclass)
        {
            List<AccountLedgerData> result = null;
            try
            {
                AccountLedgerDA objclassDA = new AccountLedgerDA();
                result = objclassDA.SearchAccountLedgerDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AccountLedgerData> GetAccountLedgerDetailsByID(AccountLedgerData objclass)
        {
            List<AccountLedgerData> result = null;

            try
            {
                AccountLedgerDA objclassDA = new AccountLedgerDA();
                result = objclassDA.GetAccountLedgerDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteAccountLedgerDetailsByID(AccountLedgerData objclass)
        {
            int result = 0;

            try
            {
                AccountLedgerDA objclassDA = new AccountLedgerDA();
                result = objclassDA.DeleteAccountLedgerDetailsByID(objclass);

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
