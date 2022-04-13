using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.DataAccess.EduAdmin;

namespace Mobimp.Edusoft.BussinessProcess.EduAdmin
{
    public class UserAdminBO //:BusinessObjectBase
    {
        public bool SaveRole(Role objRole)
        {
            bool status = false;
            try
            {
                //LogManager.WriteLog(new LogSource(this, LogManager.WhoCalledMe(), EnumLogCategory.BusinessProcessEvents, EnumPriority.High, EnumLogEvenType.Information));
                UserAdminDA objUserAdminDA = new UserAdminDA();
                status = objUserAdminDA.SaveRole(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
        public List<SiteMapData> GetMedPagesbyRoleID(RolesData objRole)
        {
            List<SiteMapData> objUserCE = null;
            try
            {
                UserAdminDA objUserAdminDA = new UserAdminDA();
                objUserCE = objUserAdminDA.GetMedPagesbyRoleID(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return objUserCE;
        }
        public bool SavePageRole(RolesData objRole)
        {
            bool status = false;
            try
            {
                LogManager.WriteLog(new LogSource(this, LogManager.WhoCalledMe(), EnumLogCategory.BusinessProcessEvents, EnumPriority.High, EnumLogEvenType.Information));
                UserAdminDA objUserAdminDA = new UserAdminDA();
                status = objUserAdminDA.SavePageRole(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
        public List<Role> getRole(Role objRole)
        {

            List<Role> result = null;

            try
            {
                UserAdminDA objRoleDA = new UserAdminDA();
                result = objRoleDA.getRole(objRole);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public bool DeleteRole(Role objRole)
        {
            bool status = false;
            try
            {
                //LogManager.WriteLog(new LogSource(this, LogManager.WhoCalledMe(), EnumLogCategory.BusinessProcessEvents, EnumPriority.High, EnumLogEvenType.Information));
                UserAdminDA objRoleDA = new UserAdminDA();
                status = objRoleDA.DeleteRole(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
        public List<CreateUser> getTrackUser(CreateUser objCreateUser)
        {

            List<CreateUser> result = null;

            try
            {
                UserAdminDA objRoleDA = new UserAdminDA();
                result = objRoleDA.getTrackUser(objCreateUser);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public bool DeleteTrackUser(CreateUser objCreateUser)
        {
            bool status = false;
            try
            {
                //LogManager.WriteLog(new LogSource(this, LogManager.WhoCalledMe(), EnumLogCategory.BusinessProcessEvents, EnumPriority.High, EnumLogEvenType.Information));
                UserAdminDA objRoleDA = new UserAdminDA();
                status = objRoleDA.DeleteTrackUser(objCreateUser);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }
        #region Site Map
        public List<SiteMapData> GetAllSiteMapItem(SiteMapData objSiteMap)
        {
            List<SiteMapData> objUserCE = null;
            try
            {
                UserAdminDA objUserAdminDA = new UserAdminDA();
                objUserCE = objUserAdminDA.GetAllSiteMapItem(objSiteMap);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return objUserCE;
        }
        public List<SiteMapData> GetSiteMapRoleByRoleID(Role objRole)
        {
            List<SiteMapData> objUserCE = null;
            try
            {
                UserAdminDA objUserAdminDA = new UserAdminDA();
                objUserCE = objUserAdminDA.GetSiteMapRoleByRoleID(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return objUserCE;
        }
        public bool SaveSiteMapRole(Role objRole)
        {
            bool status = false;
            try
            {
                //LogManager.WriteLog(new LogSource(this, LogManager.WhoCalledMe(), EnumLogCategory.BusinessProcessEvents, EnumPriority.High, EnumLogEvenType.Information));
                UserAdminDA objUserAdminDA = new UserAdminDA();
                status = objUserAdminDA.SaveSiteMapRole(objRole);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return status;
        }


        public List<SideMenu> GetSideBar(SideMenu objsidemenu)
        {

            List<SideMenu> result = null;

            try
            {
                UserAdminDA objEmployeeTypeDA = new UserAdminDA();
                result = objEmployeeTypeDA.GetSideBar(objsidemenu);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        #endregion


    }
}
