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
    public class StockEntryWithOrderBO
    {
        public List<WorkOrderData> SearchWorkOrderList(WorkOrderData obj)
        {
            List<WorkOrderData> result = null;
            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.SearchWorkOrderList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> GetItemDetailsByWorkOrder(WorkOrderData obj)
        {
            List<WorkOrderData> result = null;
            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.GetItemDetailsByWorkOrder(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> UpdateStockReceived(WorkOrderData objtran)
        {
            List<WorkOrderData> result = null;
            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.UpdateStockReceived(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //---TAB-2--//
        public List<WorkOrderData> SearchStockReceivedList(WorkOrderData obj)
        {
            List<WorkOrderData> result = null;
            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.SearchStockReceivedList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteStockReceivedNo(WorkOrderData obj)
        {
            int result = 0;

            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.DeleteStockReceivedNo(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> GetItemDetailsByRecNo(WorkOrderData obj)
        {
            List<WorkOrderData> result = null;
            try
            {
                StockEntryWithOrderDA objDA = new StockEntryWithOrderDA();
                result = objDA.GetItemDetailsByRecNo(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<StockEntryWithoutPOData> GetAutoVendorName(StockEntryWithoutPOData objdata)
        {
            List<StockEntryWithoutPOData> result = null;

            try
            {
                StockEntryWithOrderDA objda = new StockEntryWithOrderDA();
                result = objda.GetAutoVendorName(objdata);
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
