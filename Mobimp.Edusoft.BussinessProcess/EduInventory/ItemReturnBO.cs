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
    public class ItemReturnBO
    {

        public List<ItemReturnData> GetItemDetailsByIssueNo(ItemReturnData objData)
        {
            List<ItemReturnData> result = null;
            try
            {
                ItemReturnDA objDA = new ItemReturnDA();
                result = objDA.GetItemDetailsByIssueNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ItemReturnData> SaveReturnItemList(ItemReturnData objData)
        {
            List<ItemReturnData> result = null;
            try
            {
                ItemReturnDA objDA = new ItemReturnDA();
                result = objDA.SaveReturnItemList(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //--------------------------Start Tab 2-------------------------------------

        public List<ItemReturnData> GetItemReturnList(ItemReturnData objData)
        {
            List<ItemReturnData> result = null;
            try
            {
                ItemReturnDA objDA = new ItemReturnDA();
                result = objDA.GetItemReturnList(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
    }
}
