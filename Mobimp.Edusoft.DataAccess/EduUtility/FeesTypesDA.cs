using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class FeesTypesDA
    {
        public int UpdateFeeTypes (FeesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@FeeID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;
                    
                    arParms[1] = new SqlParameter("@FeeCode", SqlDbType.NVarChar);
                    arParms[1].Value = objfees.FeeCode;

                    arParms[2] = new SqlParameter("@FeeName", SqlDbType.NVarChar);
                    arParms[2].Value = objfees.FeeName;

                    arParms[3] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[3].Value = objfees.CategoryID;

                    arParms[4] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[4].Value = objfees.Status;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objfees.AddedBy;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[6].Value = objfees.UserId;

                    arParms[7] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[7].Value = objfees.CompanyID;
                    
                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objfees.ActionType;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateFeeTypes", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[9].Value);
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
        public List<FeesData> SearchFeesDetails(FeesData objfees)
        {
            List<FeesData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objfees.ClassID;

                    arParms[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[2].Value = objfees.CategoryID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.FeeTypeID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objfees.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objfees.CurrentIndex;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objfees.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchFeeDetails", arParms);
                    List<FeesData> lstFeesDetails = ORHelper<FeesData>.FromDataReaderToList(sqlReader);
                    result = lstFeesDetails;
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
        public List<FeesData> GetFeesDetailsByID(FeesData objfees)
        {
            List<FeesData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objfees.ActionType;
               
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_GetFeeTypeByID", arParms);
                    List<FeesData> lstFeesDetails = ORHelper<FeesData>.FromDataReaderToList(sqlReader);
                    result = lstFeesDetails;
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


        public int DeleteFeesDetailsByID(FeesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objfees.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Remarks;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteFeeTypeDetailMST", arParms);
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
