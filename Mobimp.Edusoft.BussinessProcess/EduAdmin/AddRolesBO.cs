using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.DataAccess.EduAdmin;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduAdmin
{
    public class AddRolesBO
    {
        public int UpdateRoleDetails(RolesData objCast)
        {
            int result = 0;
            try
            {
                AddRolesDA objAddRolesDA = new AddRolesDA();
                result = objAddRolesDA.UpdateRoleDetails(objCast);
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RolesData> SearchRoleDetails(RolesData objCast)
        {
          List<RolesData> result = null;
            try
            {
                AddRolesDA objAddRolesDA = new AddRolesDA();
                result = objAddRolesDA.SearchRoleDetails(objCast);
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RolesData> GetRoleDetailsByID(RolesData objCast)
        {
            List<RolesData> result = null;

            try
            {
                AddRolesDA objAddRolesDA = new AddRolesDA();
                result = objAddRolesDA.GetRoleDetailsByID(objCast);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteRoleDetailsByID(RolesData objCast)
        {
            int result = 0;
            try
            {
                AddRolesDA objAddRolesDA = new AddRolesDA();
                result = objAddRolesDA.DeleteRoleDetailsByID(objCast);
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
