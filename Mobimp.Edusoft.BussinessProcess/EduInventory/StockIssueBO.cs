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
    public class StockIssueBO
    {
        public List<StockIssueData> GetAutoItemStockDetails(StockIssueData objdata)
        {
            List<StockIssueData> result = null;

            try
            {
                StockIssueDA objda = new StockIssueDA();
                result = objda.GetAutoItemStockDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StockIssueData> GetItemDetailsByStockNo(StockIssueData objData)
        {
            List<StockIssueData> result = null;
            try
            {
                StockIssueDA objDA = new StockIssueDA();
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

        public int SaveStockIssueList(StockIssueData objData)
        {
            int status = 0;
            try
            {
                StockIssueDA objDA = new StockIssueDA();
                status = objDA.SaveStockIssueList(objData);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }

         //-------------------Start Second Tab-----------------------

        public List<StockIssueData> GetStockIssueDetails(StockIssueData obj)
        {
            List<StockIssueData> result = null;
            try
            {
                StockIssueDA objDA = new StockIssueDA();
                result = objDA.GetStockIssueDetails(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteStockIssueByIssueID(StockIssueData objData)
        {
            int status = 0;
            try
            {
                StockIssueDA objDA = new StockIssueDA();
                status = objDA.DeleteStockIssueByIssueID(objData);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle JNH
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
    }
}
