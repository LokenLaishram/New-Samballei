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
    public class FeeDetailDA
    {
        public int UpdateFeesDetails(FeesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objfees.ClassID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objfees.FeeTypeID;

                    arParms[3] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[3].Value = objfees.StreamID;

                    arParms[4] = new SqlParameter("@FeeAmount", SqlDbType.Money);
                    arParms[4].Value = objfees.FeeAmount;

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

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = objfees.AcademicSessionID;

                    arParms[11] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[11].Value = objfees.AdmissionTypeID;

                    arParms[12] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[12].Value = objfees.StudentCategoryID;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateFeeDetail", arParms);
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
        public int UpdateBreakupFeesDetails(FeesData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objfees.xmlfeelist;

                    arParms[1] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[1].Value = objfees.AddedBy;

                    arParms[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[2].Value = objfees.CompanyID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_Updatebreakupfeedetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[3].Value);
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
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objfees.ClassID;

                    arParms[1] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[1].Value = objfees.StreamID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objfees.AcademicSessionID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.FeeTypeID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objfees.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objfees.CurrentIndex;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objfees.ActionType;

                    arParms[7] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[7].Value = objfees.AdmissionTypeID;

                    arParms[8] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[8].Value = objfees.StudentCategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SeacrhFeeDetails", arParms);
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
        public List<FeesData> SearchBreakupFeesDetails(FeesData objfees)
        {
            List<FeesData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objfees.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objfees.FeeTypeID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objfees.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objfees.CurrentIndex;

                    arParms[5] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[5].Value = objfees.AdmissionTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SeacrhBreakupFeeDetails", arParms);
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
        public List<FeesData> SearchMonthlyFeesDetails(FeesData objfees)
        {
            List<FeesData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objfees.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objfees.FeeTypeID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objfees.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objfees.CurrentIndex;

                    arParms[5] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[5].Value = objfees.AdmissionTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SeacrhMonthlyFeeDetails", arParms);
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
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_EditFeeDetail", arParms);
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
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objfees.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteDetail", arParms);
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
