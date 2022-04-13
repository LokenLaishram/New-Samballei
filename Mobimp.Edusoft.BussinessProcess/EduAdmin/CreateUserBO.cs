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
    public class CreateUserBO
    {
        public bool UpdateCreateUser(CreateUser objCreateUser)
        {
            bool result = false;
            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.UpdateCreateUser(objCreateUser);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public UserCE getCreateUser(CreateUser objCreateUser)
        {
            UserCE result = null;
            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.getCreateUser(objCreateUser);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }


        //public UserCE Getsitemaplinks(CreateUser objCreateUser)
        //{

        //    UserCE result = null;

        //    try
        //    {
        //        CreateUserDA objCreateUserDA = new CreateUserDA();
        //        result = objCreateUserDA.Getsitemaplinks(objCreateUser);

        //    }
        //    catch (Exception ex)
        //    {
        //       PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new BusinessProcessException("4000001", ex);
        //    }
        //    return result;

        //}







        public List<CreateUser> BindLogin(CreateUser objCreateUser)
        {

            List<CreateUser> result = null;

            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.BindLogin(objCreateUser);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;



        }
        public bool DeleteLogin(CreateUser objCreateUser)
        {
            bool result = false;
            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.DeleteLogin(objCreateUser);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public CreateUser ScheduleLogin(CreateUser objCreateUser)
        {
            CreateUser result;

            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.ScheduleLogin(objCreateUser);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public bool ScheduleLogOut(CreateUser objCreateUser)
        {
            bool result = false;
            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.ScheduleLogOut(objCreateUser);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public bool CheckLogout(CreateUser objCreateUser)
        {
            bool result = false;
            try
            {
                CreateUserDA objCreateUserDA = new CreateUserDA();
                result = objCreateUserDA.CheckLogout(objCreateUser);
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
