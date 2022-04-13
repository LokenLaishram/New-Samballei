using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduAdmin
{
    public class UserAdminDA //: DataAccessObjectBase
    {
        public bool SaveRole(Role objRole)
        {
            bool status = false;
            try
            {
                SqlParameter[] arParms = new SqlParameter[7];

                arParms[0] = new SqlParameter("@RoleName", SqlDbType.VarChar);
                arParms[0].Value = objRole.RoleName;
                arParms[1] = new SqlParameter("@RoleCode", SqlDbType.VarChar);
                arParms[1].Value = objRole.RoleCode;
                arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[2].Value = objRole.AddedBy;
                arParms[3] = new SqlParameter("@LastModBy", SqlDbType.VarChar);
                arParms[3].Value = objRole.LastModBy;
                arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[4].Value = objRole.ActionType;
                arParms[5] = new SqlParameter("@RoleID", SqlDbType.Int);
                arParms[5].Value = objRole.RoleID;
                int noOfEffectedRecords = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateRole", arParms);
                if (noOfEffectedRecords > 0)
                    status = true;

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return status;
        }
        public bool SavePageRole(RolesData objRole)
        {
            bool status = false;
            try
            {

                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@RoleId", SqlDbType.Int);
                arParms[0].Value = objRole.RoleID;

                arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                arParms[1].Value = objRole.XMLData;

                arParms[2] = new SqlParameter("@LastModBy", SqlDbType.BigInt);
                arParms[2].Value = objRole.EmployeeID;

                int noOfEffectedRecords = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SavePageRoles", arParms);
                if (noOfEffectedRecords == -1 || noOfEffectedRecords > 0)
                    status = true;

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return status;
        }
        public List<SiteMapData> GetMedPagesbyRoleID(RolesData objRole)
        {
            List<SiteMapData> lstSiteMap = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                arParms[0].Value = objRole.RoleID;

                arParms[1] = new SqlParameter("@MenuHeaderID", SqlDbType.Int);
                arParms[1].Value = objRole.MenuHeaderID;

                arParms[2] = new SqlParameter("@PageID", SqlDbType.Int);
                arParms[2].Value = objRole.PageID;

                DataSet ds = new DataSet();
                SqlHelper.FillDataset(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetMediquraPages", ds, new string[] { "SiteMap" }, arParms);
                lstSiteMap = ORHelper<SiteMapData>.FromDataTableToList(ds.Tables["SiteMap"]);

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return lstSiteMap;
        }
        public List<Role> getRole(Role objRole)
        {

            List<Role> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[0].Value = objRole.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_GetRole", arParms);
                    List<Role> listservice = ORHelper<Role>.FromDataReaderToList(sqlReader);
                    result = listservice;
                }
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public bool DeleteRole(Role objRole)
        {
            bool status = false;
            try
            {

                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                arParms[0].Value = objRole.RoleID;

                arParms[1] = new SqlParameter("@LastModBy", SqlDbType.VarChar);
                arParms[1].Value = objRole.LastModBy;

                arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[2].Value = objRole.ActionType;

                int noOfEffectedRecords = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_DeleteRole", arParms);
                if (noOfEffectedRecords > 0)
                    status = true;

            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return status;
        }

        public List<CreateUser> getTrackUser(CreateUser objCreateUser)
        {

            List<CreateUser> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[0].Value = objCreateUser.ActionType;

                    arParms[1] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[1].Value = objCreateUser.LoginID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_GetTrackUser", arParms);
                    List<CreateUser> listservice = ORHelper<CreateUser>.FromDataReaderToList(sqlReader);
                    result = listservice;
                }
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public bool DeleteTrackUser(CreateUser objCreateUser)
        {
            bool status = false;
            try
            {

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[0].Value = objCreateUser.scheduleID;

                int noOfEffectedRecords = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_DeleteTrackUser", arParms);
                if (noOfEffectedRecords > 0)
                    status = true;

            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return status;
        }


        public List<SiteMapData> GetAllSiteMapItem(SiteMapData objSiteMap)
        {
            List<SiteMapData> lstSiteMap = null;
            try
            {
                DataSet ds = new DataSet();
                SqlHelper.FillDataset(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAllSiteMapItem", ds, new string[] { "SiteMap" }, null);
                lstSiteMap = ORHelper<SiteMapData>.FromDataTableToList(ds.Tables["SiteMap"]);

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return lstSiteMap;

        }

        public List<SiteMapData> GetSiteMapRoleByRoleID(Role objRole)
        {
            List<SiteMapData> lstSiteMap = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                arParms[0].Value = objRole.RoleID;  //objRole.UserTypeID;

                DataSet ds = new DataSet();
                SqlHelper.FillDataset(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSiteMapRoleByRoleID", ds, new string[] { "SiteMap" }, arParms);
                lstSiteMap = ORHelper<SiteMapData>.FromDataTableToList(ds.Tables["SiteMap"]);

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return lstSiteMap;
        }

        public bool SaveSiteMapRole(Role objRole)
        {
            bool status = false;
            try
            {

                SqlParameter[] arParms = new SqlParameter[7];

                arParms[0] = new SqlParameter("@RoleId", SqlDbType.Int);
                arParms[0].Value = objRole.RoleID;

                arParms[1] = new SqlParameter("@XMLData", SqlDbType.VarChar);
                arParms[1].Value = objRole.XMLData;

                arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[2].Value = objRole.AddedBy;
                arParms[3] = new SqlParameter("@LastModBy", SqlDbType.VarChar);
                arParms[3].Value = objRole.LastModBy;

                arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[4].Value = objRole.ActionType;

                int noOfEffectedRecords = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SaveSiteMapRole", arParms);
                if (noOfEffectedRecords > 0)
                    status = true;

            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "5000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return status;
        }

        public List<SideMenu> GetSideBar(SideMenu objsidemenu)
        {
            List<SideMenu> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                    arParms[0].Value = objsidemenu.RoleID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_Getparentenus", arParms);
                    List<SideMenu> lstEmployeeTypeDetails = ORHelper<SideMenu>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeTypeDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
    }
}
