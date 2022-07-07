using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduAdmin;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduEmployee;

namespace Mobimp.Edusoft.DataAccess.EduAdmin
{
    public class AddUsersDA
    {
        public int UpdateUserDetails(AddUsersData objusers)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[0].Value = objusers.LoginID;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objusers.EmployeeID;

                    arParms[2] = new SqlParameter("@UserName", SqlDbType.VarChar);
                    arParms[2].Value = objusers.UserName;

                    arParms[3] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                    arParms[3].Value = objusers.UserPassword;

                    arParms[4] = new SqlParameter("@RoleID", SqlDbType.Int);
                    arParms[4].Value = objusers.RoleID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objusers.AddedBy;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[6].Value = objusers.UserId;

                    arParms[7] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[7].Value = objusers.CompanyID;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objusers.ActionType;

                    arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[9].Value = objusers.AcademicSessionID;

                    arParms[10] = new SqlParameter("@MgtType", SqlDbType.Int);
                    arParms[10].Value = objusers.MgtType;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    arParms[12] = new SqlParameter("@RealPassword", SqlDbType.NVarChar);
                    arParms[12].Value = objusers.RealPassword;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_UpdateUserDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[11].Value);
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
        public int UpdateChangepassword(userdetails objusers)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[0].Value = objusers.UserId;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objusers.EmployeeID;

                    arParms[2] = new SqlParameter("@UserName", SqlDbType.VarChar);
                    arParms[2].Value = objusers.UserName;

                    arParms[3] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
                    arParms[3].Value = objusers.UserPassword;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@RealPassword", SqlDbType.VarChar);
                    arParms[5].Value = objusers.RealPassword;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_UpdateCahngePassword", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
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
        public List<AddUsersData> SearchUserDetails(AddUsersData objusers)
        {
            List<AddUsersData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[0].Value = objusers.EmployeeID;

                    arParms[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
                    arParms[1].Value = objusers.UserName;

                    arParms[2] = new SqlParameter("@RoleID", SqlDbType.Int);
                    arParms[2].Value = objusers.RoleID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objusers.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objusers.CurrentIndex;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objusers.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_SearchUserDetail", arParms);
                    List<AddUsersData> lstUserDetails = ORHelper<AddUsersData>.FromDataReaderToList(sqlReader);
                    result = lstUserDetails;
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
        public List<AddUsersData> GetUserDetailsByID(AddUsersData objusers)
        {
            List<AddUsersData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[0].Value = objusers.LoginID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objusers.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_EditUserDetail", arParms);
                    List<AddUsersData> lstUserDetails = ORHelper<AddUsersData>.FromDataReaderToList(sqlReader);
                    result = lstUserDetails;
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
        public int DeleteUserDetailsByID(AddUsersData objusers)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[0].Value = objusers.LoginID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objusers.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_DeleteUserDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[2].Value);
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
