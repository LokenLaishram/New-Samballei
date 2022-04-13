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
    public class StockReleasedBO
    {
        public List<IndentSaleData> SearchPaidIndentDetailsList(IndentSaleData obj)
        {
            List<IndentSaleData> result = null;
            try
            {
                StockReleasedDA objDA = new StockReleasedDA();
                result = objDA.SearchPaidIndentDetailsList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentSaleData> GetItemDetailsByBillNo(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                StockReleasedDA Objda = new StockReleasedDA();
                result = Objda.GetItemDetailsByBillNo(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //----SAVE STOCK RELEASED----//

        public List<IndentSaleData> SaveStockReleasedDetails(IndentSaleData objtran)
        {
            List<IndentSaleData> result = null;
            try
            {
                StockReleasedDA objDA = new StockReleasedDA();
                result = objDA.SaveStockReleasedDetails(objtran);
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
        public List<IndentSaleData> SearchStockReleasedDetailsList(IndentSaleData obj)
        {
            List<IndentSaleData> result = null;
            try
            {
                StockReleasedDA objUserAdminDA = new StockReleasedDA();
                result = objUserAdminDA.SearchStockReleasedDetailsList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentSaleData> SearchChildStockReleasedDetails(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                StockReleasedDA Objda = new StockReleasedDA();
                result = Objda.SearchChildStockReleasedDetails(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteStockReleasedByRNo(IndentSaleData obj)
        {
            int result = 0;

            try
            {
                StockReleasedDA objDA = new StockReleasedDA();
                result = objDA.DeleteStockReleasedByRNo(obj);

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
