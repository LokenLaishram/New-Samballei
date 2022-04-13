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
    public class WorkOrderBO
    {
        public List<WorkOrderData> GetItemName(WorkOrderData objData)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.GetItemName(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> SaveWorkOrderGeneration(WorkOrderData objtran)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.SaveWorkOrderGeneration(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> SearchWorkOrderList(WorkOrderData obj)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
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
        public List<WorkOrderData> SearchOrderTemplate(WorkOrderData ObjOrder)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA ObjOrderTypeDA = new WorkOrderDA();
                result = ObjOrderTypeDA.SearchOrderTemplate(ObjOrder);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> GetWorkOrderDetailsByWONo(WorkOrderData objData)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.GetWorkOrderDetailsByWONo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<WorkOrderData> PrintWorkOrderDetailsByOrderNo(WorkOrderData objData)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.PrintWorkOrderDetailsByOrderNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteWorkOrdeByWONo(WorkOrderData obj)
        {
            int result = 0;

            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.DeleteWorkOrdeByWONo(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<WorkOrderData> GetAutoItemDetails(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;

            try
            {
                WorkOrderDA objda = new WorkOrderDA();
                result = objda.GetAutoItemDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<WorkOrderData> GetItemDetailByID(WorkOrderData objData)
        {
            List<WorkOrderData> result = null;
            try
            {
                WorkOrderDA objDA = new WorkOrderDA();
                result = objDA.GetItemDetailByID(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }


        public List<WorkOrderData> GetAutoVendorDetails(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;

            try
            {
                WorkOrderDA objda = new WorkOrderDA();
                result = objda.GetAutoVendorDetails(objdata);

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
