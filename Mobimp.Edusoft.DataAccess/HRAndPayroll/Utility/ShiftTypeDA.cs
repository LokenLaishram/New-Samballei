using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility
{
    public class ShiftTypeDA
    {
        public int UpdateShiftType(ShiftData objshift)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objshift.ID;

                    arParms[1] = new SqlParameter("@Shift", SqlDbType.VarChar);
                    arParms[1].Value = objshift.Shift;

                    arParms[2] = new SqlParameter("@StartTime", SqlDbType.Int);
                    arParms[2].Value = objshift.StartTime;

                    arParms[3] = new SqlParameter("@EndTime", SqlDbType.Int);
                    arParms[3].Value = objshift.EndTime;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objshift.AddedBy;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[5].Value = objshift.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objshift.CompanyID;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objshift.ActionType;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objshift.IsActive;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateShiftMST", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[9].Value);
                    }
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
        public List<ShiftData> Searchshifts(ShiftData objshift)
        {
            List<ShiftData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@Shift", SqlDbType.VarChar);
                    arParms[0].Value = objshift.Shift;

                    arParms[1] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[1].Value = objshift.PageSize;

                    arParms[2] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[2].Value = objshift.CurrentIndex;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objshift.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchShitMST", arParms);
                    List<ShiftData> lstLoanTypeDetails = ORHelper<ShiftData>.FromDataReaderToList(sqlReader);
                    result = lstLoanTypeDetails;
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
        public List<ShiftData> GetShiftByID(ShiftData objshift)
        {
            List<ShiftData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objshift.ID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditShiftMST", arParms);
                    List<ShiftData> lstLoanTypeDetails = ORHelper<ShiftData>.FromDataReaderToList(sqlReader);
                    result = lstLoanTypeDetails;
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

        public int DeleteShiftByID(ShiftData objshift)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objshift.ID;

                    arParms[1] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[1].Value = objshift.Remark;

                    arParms[2] = new SqlParameter("@UserID", SqlDbType.Int);
                    arParms[2].Value = objshift.UserId;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteShitMST", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[3].Value);
                    }
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
