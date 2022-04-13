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
    public class ItemCondemnationBO
    {
        public List<ItemCondemnationData> GetItemNameWithStockNo(ItemCondemnationData objData)
        {
            List<ItemCondemnationData> result = null;
            try
            {
                ItemCondemnationDA objDA = new ItemCondemnationDA();
                result = objDA.GetItemNameWithStockNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ItemCondemnationData> GetItemDetailsByStockNo(ItemCondemnationData objData)
        {
            List<ItemCondemnationData> result = null;
            try
            {
                ItemCondemnationDA objDA = new ItemCondemnationDA();
                result = objDA.GetItemDetailsByStockNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ItemCondemnationData> SaveItemCondemn(ItemCondemnationData objData)
        {
            List<ItemCondemnationData> status = null;
            try
            {
                ItemCondemnationDA objDA = new ItemCondemnationDA();
                status = objDA.SaveItemCondemn(objData);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
    }
}
