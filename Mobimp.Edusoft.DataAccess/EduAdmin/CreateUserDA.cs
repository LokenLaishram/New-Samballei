using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduAdmin;
using System.Data.SqlClient;
using System.Data;

using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.DataAccess.EduAdmin
{
    public class CreateUserDA
    {
        public bool UpdateCreateUser(CreateUser objCreateUser)
        {
            bool result = false;

            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                arParms[0].Value = objCreateUser.LoginID;

                arParms[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
                arParms[1].Value = objCreateUser.UserName;

                arParms[2] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                arParms[2].Value = objCreateUser.UserPassword;

                arParms[3] = new SqlParameter("@RoleID", SqlDbType.Int);
                arParms[3].Value = objCreateUser.RoleID;

                arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[4].Value = objCreateUser.AddedBy;

                //arParms[5] = new SqlParameter("@AddedDate", SqlDbType.DateTime);
                //arParms[5].Value = objCreateUser.AddedDTM;

                arParms[6] = new SqlParameter("@ModifiedBy", SqlDbType.VarChar);
                arParms[6].Value = objCreateUser.LastModBy;

                //arParms[7] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                //arParms[7].Value = objCreateUser.LastModDTM;

                arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[8].Value = objCreateUser.ActionType;


                int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateCreateUser", arParms);
                if (records == -1 || records > 0)
                    result = true;
            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }
        public UserCE getCreateUser(CreateUser objCreateUser)
        {
            UserCE result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                    arParms[0].Value = objCreateUser.UserName;

                    arParms[1] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                    arParms[1].Value = objCreateUser.UserPassword;

                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objCreateUser.ActionType;

                    arParms[3] = new SqlParameter("@MgtType", SqlDbType.Int);
                    arParms[3].Value = objCreateUser.MgtType;

                    DataSet ds = new DataSet();
                    SqlHelper.FillDataset(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ADM_GetLoginDetails", ds, new string[] { "CreateUser", "Role", "SiteMap" }, arParms);
                    List<SiteMapData> objSiteMap = ORHelper<SiteMapData>.FromDataTableToList(ds.Tables["SiteMap"]);
                    List<Role> lstRole = ORHelper<Role>.FromDataTableToList(ds.Tables["Role"]);
                    CreateUser listservice = ORHelper<CreateUser>.FromDataTable(ds.Tables["CreateUser"]);
                    if (listservice != null)
                    {
                        result = new UserCE();

                        result.objCreateUser = listservice;
                        result.RoleList = lstRole;
                        result.SiteMapList = objSiteMap;
                        result.SiteMapDT = ds.Tables["SiteMap"];
                    }
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

        //public UserCE Getsitemaplinks(CreateUser objCreateUser)
        //{
        //    UserCE result = null;
        //    try
        //    {
        //        {
        //            SqlParameter[] arParms = new SqlParameter[2];

        //            arParms[0] = new SqlParameter("@SiteMapID", SqlDbType.Int);
        //            arParms[0].Value = objCreateUser.SiteMapID;
        //            arParms[1] = new SqlParameter("@RoleID", SqlDbType.Int);
        //            arParms[1].Value = objCreateUser.RoleID;

        //            DataSet ds = new DataSet();
        //            SqlHelper.FillDataset(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_GetSiteMap", ds, new string[] { "CreateUser", "SiteMap" }, arParms);
        //            List<SiteMap> objSiteMap = ORHelper<SiteMap>.FromDataTableToList(ds.Tables["SiteMap"]);
        //            CreateUser listservice = ORHelper<CreateUser>.FromDataTable(ds.Tables["CreateUser"]);

        //            if (listservice != null)
        //            {
        //                result = new UserCE();
        //                result.objCreateUser = listservice;
        //                result.SiteMapDT = ds.Tables["SiteMap"];
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new DataAccessException("5000001", ex);
        //    }
        //    return result;
        //}
        public List<CreateUser> BindLogin(CreateUser objCreateUser)
        {

            List<CreateUser> result = null;


            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[0].Value = objCreateUser.ActionType;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateCreateUser", arParms);
                List<CreateUser> listservice = ORHelper<CreateUser>.FromDataReaderToList(sqlReader);
                result = listservice;
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public bool DeleteLogin(CreateUser objCreateUser)
        {
            bool result = false;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                arParms[0].Value = objCreateUser.LoginID;

                arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[1].Value = objCreateUser.ActionType;



                int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateCreateUser", arParms);
                if (records == -1 || records > 0)
                    result = true;
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public CreateUser ScheduleLogin(CreateUser objCreateUser)
        {
            CreateUser result;

            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                arParms[0].Value = objCreateUser.LoginID;

                arParms[1] = new SqlParameter("@LoginDate", SqlDbType.VarChar);
                arParms[1].Value = objCreateUser.LoginDate;

                arParms[2] = new SqlParameter("@LoginTime", SqlDbType.VarChar);
                arParms[2].Value = objCreateUser.LoginTime;

                arParms[3] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[3].Value = objCreateUser.ActionType;


                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateTrackUser", arParms);
                CreateUser listservice = ORHelper<CreateUser>.FromDataReader(sqlReader);
                result = listservice;


            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }
        public bool ScheduleLogOut(CreateUser objCreateUser)
        {
            bool result = false;

            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[0].Value = objCreateUser.scheduleID;

                arParms[1] = new SqlParameter("@LogOutDate", SqlDbType.VarChar);
                arParms[1].Value = objCreateUser.LogOutDate;

                arParms[2] = new SqlParameter("@LogOutTime", SqlDbType.VarChar);
                arParms[2].Value = objCreateUser.LogOutTime;

                arParms[3] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[3].Value = objCreateUser.ActionType;

                int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateTrackUser", arParms);
                if (records == -1 || records > 0)
                    result = true;


            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }
        public bool CheckLogout(CreateUser objCreateUser)
        {
            bool result = false;

            try
            {
                SqlParameter[] arParms = new SqlParameter[0];
                int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Checklogout", arParms);
                if (records == -1 || records > 0)
                    result = true;
            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }


    }
}
