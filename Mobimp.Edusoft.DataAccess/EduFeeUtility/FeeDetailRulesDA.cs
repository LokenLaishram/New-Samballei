using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduFeeUtility;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.DataAccess.EduFeeUtility
{
    public class FeeDetailRulesDA
    {
        public List<FeeDetailRulesData> SearchFeesDetails(FeeDetailRulesData objfees)
        {
            List<FeeDetailRulesData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objfees.ClassID;

                    arParms[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[2].Value = objfees.CategoryID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.FeeTypeID;

                    arParms[4] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[4].Value = objfees.ID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objfees.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objfees.CurrentIndex;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objfees.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchFeeDetails", arParms);
                    List<FeeDetailRulesData> lstFeesDetails = ORHelper<FeeDetailRulesData>.FromDataReaderToList(sqlReader);
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
        public int SaveFeeDetails(FeeDetailRulesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AcademicSession", SqlDbType.Int);
                    arParms[0].Value = objfees.SessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objfees.ClassID;

                    arParms[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[2].Value = objfees.CategoryID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.FeeTypeID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objfees.AddedBy;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[5].Value = objfees.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objfees.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_InsertDetailFeeRule", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[7].Value);
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
        public int UpdateFeeDetails(FeeDetailRulesData objfees)
        {
            int result = 0;
            try
            {
                {

                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[0].Value = objfees.UserId;

                    arParms[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[1].Value = objfees.CompanyID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[3].Value = objfees.ID;

                    arParms[4] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[4].Value = objfees.PaymentTypeID;

                    arParms[5] = new SqlParameter("@FeeNewStudent", SqlDbType.Decimal);
                    arParms[5].Value = objfees.FeeNewStudent;

                    arParms[6] = new SqlParameter("@FeeOldStudent", SqlDbType.Decimal);
                    arParms[6].Value = objfees.FeeOldStudent;

                    arParms[7] = new SqlParameter("@IsStudentTypeApply", SqlDbType.Int);
                    arParms[7].Value = objfees.IsStudentTypeApply;

                    arParms[8] = new SqlParameter("@FeeHeirarchy", SqlDbType.Int);
                    arParms[8].Value = objfees.FeeHeirarchy;

                    arParms[9] = new SqlParameter("@IsActivate", SqlDbType.Bit);
                    arParms[9].Value = objfees.IsActivate;

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = objfees.AcademicSessionID;

                    arParms[11] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[11].Value = objfees.ClassID;

                    arParms[12] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[12].Value = objfees.CategoryID;

                    arParms[13] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[13].Value = objfees.FeeTypeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateDetailFeeRule", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[2].Value);
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
        public int DeleteFeeDetailsByID(FeeDetailRulesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteFeeDetailsByID", arParms);
                    if (result_ > 0 || result_ == -1)
                    { 
                        result = Convert.ToInt32(arParms[1].Value);
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
