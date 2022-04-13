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
    public class TransactionBO
    {
        public List<TransactionData> SaveAccountTransaction(TransactionData objtran)
        {
            List<TransactionData> result = null;
            try
            {
                TransactionDA objDA = new TransactionDA();
                result = objDA.SaveAccountTransaction(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TransactionData> SearchAccountTransactionList(TransactionData obj)
        {
            List<TransactionData> result = null;
            try
            {
                TransactionDA objDA = new TransactionDA();
                result = objDA.SearchAccountTransactionList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TransactionData> SearchChildTransactionDetails(TransactionData objdata)
        {
            List<TransactionData> result = null;
            try
            {
                TransactionDA Objda = new TransactionDA();
                result = Objda.SearchChildTransactionDetails(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteTransactionbyTranNo(TransactionData obj)
        {
            int result = 0;

            try
            {
                TransactionDA objDA = new TransactionDA();
                result = objDA.DeleteTransactionbyTranNo(obj);

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
