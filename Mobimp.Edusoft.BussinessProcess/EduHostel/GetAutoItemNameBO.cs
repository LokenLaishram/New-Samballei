using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Campusoft.DataAccess.EduHostel;

namespace Mobimp.Campusoft.BussinessProcess.EduHostel
{
    public class GetAutoItemNameBO
    {
        public List<ItemData> GetstudentDetailByID(ItemData objstd)
        {

            List<ItemData> result = null;

            try
            {
                GetAutoItemNameDA objstdloyeeDA = new GetAutoItemNameDA();
                result = objstdloyeeDA.GetstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<ItemData> GetAutoItemName(ItemData objitemName)
        {
            List<ItemData> result = null;

            try
            {
                GetAutoItemNameDA objitemDA = new GetAutoItemNameDA();
                result = objitemDA.GetAutoItemName(objitemName);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ItemData> GetItemDetailByID(ItemData objitem)
        {

            List<ItemData> result = null;

            try
            {
                GetAutoItemNameDA objitemDA = new GetAutoItemNameDA();
                result = objitemDA.GetitemDetailByID(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateTakingServiceItem(ItemData objitem)
        {
            int result = 0;

            try
            {
                GetAutoItemNameDA objitemDA = new GetAutoItemNameDA();
                result = objitemDA.UpdateTakingServiceItem(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ItemData> SearchTakingItemListDetails(ItemData objitemlist)
        {

            List<ItemData> result = null;

            try
            {
                GetAutoItemNameDA objtakingDA = new GetAutoItemNameDA();
                result = objtakingDA.SearchTakingItemtDetails(objitemlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ItemData> SearchTakingItemByRecieptNo(ItemData objitemData)
        {
            List<ItemData> result = null;

            try
            {
                GetAutoItemNameDA objitemDA = new GetAutoItemNameDA();
                result = objitemDA.SearchTakingItemByRecieptNo(objitemData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteTakingItemByReceiptNo(ItemData objitemdata)
        {
            int result = 0;
            try
            {
                GetAutoItemNameDA objitemDA = new GetAutoItemNameDA();
                result = objitemDA.DeleteTakingItemByReceiptNo(objitemdata);
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
