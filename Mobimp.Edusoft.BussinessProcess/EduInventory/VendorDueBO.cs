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
    public class VendorDueBO
    {
        public List<VendorDueData> SearchSaleDetailsList(VendorDueData obj)
        {
            List<VendorDueData> result = null;
            try
            {
                VendorDueDA objUserAdminDA = new VendorDueDA();
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
        public List<VendorDueData> SearchChildBillDetails(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                VendorDueDA Objda = new VendorDueDA();
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
        //---Tab-2 Due Payment---//
        public List<VendorDueData> GetPaymentDetailsByBillNo(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                VendorDueDA Objda = new VendorDueDA();
                result = Objda.GetPaymentDetailsByBillNo(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VendorDueData> SaveDuePayment(VendorDueData objtran)
        {
            List<VendorDueData> result = null;
            try
            {
                VendorDueDA objDA = new VendorDueDA();
                result = objDA.SaveDuePayment(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //---TAB3 DUE COLLECTION LIST ---//
        public List<VendorDueData> SearchDueCollectionList(VendorDueData obj)
        {
            List<VendorDueData> result = null;
            try
            {
                VendorDueDA objDA = new VendorDueDA();
                result = objDA.SearchDueCollectionList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteDueCollectionByDueBillNo(VendorDueData obj)
        {
            int result = 0;

            try
            {
                VendorDueDA objDA = new VendorDueDA();
                result = objDA.DeleteDueCollectionByDueBillNo(obj);

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
