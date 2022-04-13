using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.DataAccess.EduInventory;

namespace Mobimp.Edusoft.BussinessProcess.EduInventory
{
   public class IndentSaleBO
    {
        public List<IndentSaleData> SearchIndentDetailsList(IndentSaleData obj)
        {
            List<IndentSaleData> result = null;
            try
            {
                IndentSaleDA objUserAdminDA = new IndentSaleDA();
                result = objUserAdminDA.SearchIndentDetailsList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
       
        public List<IndentSaleData> GetItemDetailsByIndentNo(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                IndentSaleDA Objda = new IndentSaleDA();
                result = Objda.GetItemDetailsByIndentNo(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
       
        //----SAVE PAY----//

        public List<IndentSaleData> SaveIndentSalePayment(IndentSaleData objtran)
        {
            List<IndentSaleData> result = null;
            try
            {
                IndentSaleDA objDA = new IndentSaleDA();
                result = objDA.SaveIndentSalePayment(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //--TAB 3---/
        public List<IndentSaleData> SearchSaleDetailsList(IndentSaleData obj)
        {
            List<IndentSaleData> result = null;
            try
            {
                IndentSaleDA objUserAdminDA = new IndentSaleDA();
                result = objUserAdminDA.SearchSaleDetailsList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentSaleData> SearchChildBillDetails(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                IndentSaleDA Objda = new IndentSaleDA();
                result = Objda.SearchChildBillDetails(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteSaleByBillNo(IndentSaleData obj)
        {
            int result = 0;

            try
            {
                IndentSaleDA objDA = new IndentSaleDA();
                result = objDA.DeleteSaleByBillNo(obj);

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
