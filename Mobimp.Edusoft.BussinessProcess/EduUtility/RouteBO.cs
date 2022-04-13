using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class RouteBO
    {
        public int UpdateRouteDetails(RouteData objclass)
        {
            int result = 0;

            try
            {
                RouteDA objclassDA = new RouteDA();
                result = objclassDA.UpdateRouteDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RouteData> SearchRouteDetails(RouteData objclass)
        {
            List<RouteData> result = null;
            try
            {
                RouteDA objclassDA = new RouteDA();
                result = objclassDA.SearchRouteDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RouteData> GetRouteDetailsByID(RouteData objclass)
        {
            List<RouteData> result = null;

            try
            {
                RouteDA objclassDA = new RouteDA();
                result = objclassDA.GetRouteDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

       


        public int DeleteRouteDetailsByID(RouteData objclass)
        {
            int result = 0;

            try
            {
                RouteDA objclassDA = new RouteDA();
                result = objclassDA.DeleteRouteDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(RouteData objclass)
        {
            int result = 0;

            try
            {
                RouteDA objstdloyeeDA = new RouteDA();
                result = objstdloyeeDA.ActivateRoute(objclass);

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
