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
    public class StockStatusBO
    {
    
        public List<StockStatusData> GetStockStatus(StockStatusData obj)
        {
            List<StockStatusData> result = null;
            try
            {
                StockStatusDA objDA = new StockStatusDA();
                result = objDA.GetStockStatus(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<StockStatusData> GetStockStatusByItemGroup(StockStatusData obj)
        {
            List<StockStatusData> result = null;
            try
            {
                StockStatusDA objDA = new StockStatusDA();
                result = objDA.GetStockStatusByItemGroup(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //----TAB2-------//
        public List<StockStatusData> GetItemwiseStockStatus(StockStatusData obj)
        {
            List<StockStatusData> result = null;
            try
            {
                StockStatusDA objDA = new StockStatusDA();
                result = objDA.GetItemwiseStockStatus(obj);
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
