using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.DataAccess.EduAdmin;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduEmployee;

namespace Mobimp.Edusoft.BussinessProcess.EduAdmin
{
    public class AddUsersBO
    {
        public int UpdateUserDetails(AddUsersData objCast)
        {
            int result = 0;
            try
            {
                AddUsersDA objAddUsersDA = new AddUsersDA();
                result = objAddUsersDA.UpdateUserDetails(objCast);
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateChangepassword(userdetails objlogin)
        {
            int result = 0;
            try
            {
                AddUsersDA objAddUsersDA = new AddUsersDA();
                result = objAddUsersDA.UpdateChangepassword(objlogin);
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AddUsersData> SearchUserDetails(AddUsersData objCast)
        {

            List<AddUsersData> result = null;

            try
            {
                AddUsersDA objAddUsersDA = new AddUsersDA();
                result = objAddUsersDA.SearchUserDetails(objCast);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AddUsersData> GetUserDetailsByID(AddUsersData objCast)
        {
            List<AddUsersData> result = null;

            try
            {
                AddUsersDA objAddUsersDA = new AddUsersDA();
                result = objAddUsersDA.GetUserDetailsByID(objCast);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteUserDetailsByID(AddUsersData objCast)
        {
            int result = 0;
            try
            {
                AddUsersDA objAddUsersDA = new AddUsersDA();
                result = objAddUsersDA.DeleteUserDetailsByID(objCast);

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
