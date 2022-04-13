using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInvUtility;
using Mobimp.Edusoft.DataAccess.EduInvUtilityDA;

namespace Mobimp.Edusoft.BussinessProcess.EduInvUtility
{
   public class ItemBO
    {
        public int SaveItemData(ItemData objitem)
        {
            int result = 0;
            try
            {
                ItemDA objitemDA = new ItemDA();
                result = objitemDA.SaveItemData(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ItemData> SearchItem(ItemData objclass)
        {
            List<ItemData> result = null;
            try
            {
                ItemDA objclassDA = new ItemDA();
                result = objclassDA.SearchItem(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ItemPriceData> SearchItempricelist(ItemPriceData objitem)
        {
            List<ItemPriceData> result = null;
            try
            {
                ItemDA objclassDA = new ItemDA();
                result = objclassDA.SearchItempricelist(objitem);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ItemData> GetItembyID(ItemData objitem)
        {
            List<ItemData> result = null;

            try
            {
                ItemDA objitemDA = new ItemDA();
                result = objitemDA.GetItembyID(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteItembyID(ItemData objitem)
        {
            int result = 0;

            try
            {
                ItemDA objitemDA = new ItemDA();
                result = objitemDA.DeleteItembyID(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Updateitemprice(ItemPriceData objitem)
        {
            int result = 0;
            try
            {
                ItemDA objitemDA = new ItemDA();
                result = objitemDA.Updateitemprice(objitem);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int Activate(ItemData objgrp)
        {
            int result = 0;

            try
            {
                ItemDA objstdloyeeDA = new ItemDA();
                result = objstdloyeeDA.Activate(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ItemPriceData> GetAutoItemDetails(ItemPriceData objdata)
        {
            List<ItemPriceData> result = null;

            try
            {
                ItemDA objda = new ItemDA();
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
    }
}
