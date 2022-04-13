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
  public class OrderTypeBO
    {
        public int SaveOrderType(OrderTypeData ObjOrder)
        {
            int result = 0;

            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
                result = ObjOrderTypeDA.SaveOrderType(ObjOrder);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<OrderTypeData> Searchordertype(OrderTypeData ObjOrder)
        {
            List<OrderTypeData> result = null;
            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
                result = ObjOrderTypeDA.Searchordertype(ObjOrder);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<OrderTypeData> GetordertypebyID(OrderTypeData ObjOrder)
        {
            List<OrderTypeData> result = null;

            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
                result = ObjOrderTypeDA.GetordertypebyID(ObjOrder);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteordertypebyID(OrderTypeData ObjOrder)
        {
            int result = 0;

            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
                result = ObjOrderTypeDA.DeleteordertypebyID(ObjOrder);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Activate(OrderTypeData objdata)
        {
            int result = 0;

            try
            {
                OrderTypeDA objstdloyeeDA = new OrderTypeDA();
                result = objstdloyeeDA.ActivateOrderType(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //------ORDER TEMPLATE---//
        public List<OrderTypeData> SearchOrderTemplate(OrderTypeData ObjOrder)
        {
            List<OrderTypeData> result = null;
            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
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
        public int SaveOrderTemplate(OrderTypeData ObjOrder)
        {
            int result = 0;

            try
            {
                OrderTypeDA ObjOrderTypeDA = new OrderTypeDA();
                result = ObjOrderTypeDA.SaveOrderTemplate(ObjOrder);

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
