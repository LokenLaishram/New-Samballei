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
    public class StockEntryWithoutPOBO
    {
        public List<StockEntryWithoutPOData> GetItemNameAuto(StockEntryWithoutPOData objData)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                StockEntryWithoutPODA objDA = new StockEntryWithoutPODA();
                result = objDA.GetItemNameAuto(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<StockEntryWithoutPOData> GetItemNameWithPrice(StockEntryWithoutPOData objData)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                StockEntryWithoutPODA objDA = new StockEntryWithoutPODA();
                result = objDA.GetItemNameWithPrice(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<StockEntryWithoutPOData> SaveStockWithoutPO(StockEntryWithoutPOData objData)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                StockEntryWithoutPODA objDA = new StockEntryWithoutPODA();
                result = objDA.SaveStockWithoutPO(objData);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //----TAB2---//
        public List<StockEntryWithoutPOData> GetGRNWithoutPOList(StockEntryWithoutPOData obj)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                StockEntryWithoutPODA objDA = new StockEntryWithoutPODA();
                result = objDA.GetGRNWithoutPOList(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteGRNoteByStockNo(StockEntryWithoutPOData obj)
        {
            int result = 0;

            try
            {
                StockEntryWithoutPODA objDA = new StockEntryWithoutPODA();
                result = objDA.DeleteGRNoteByStockNo(obj);
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
