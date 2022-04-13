using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class CountryDA
    {
        public int UpdateCountryDetails(CountryData objcountry)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objcountry.ID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objcountry.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objcountry.Descriptions;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objcountry.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[4].Value = objcountry.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objcountry.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objcountry.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateCountryDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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
        public List<CountryData> SearchCountryDetails(CountryData objcountry)
        {
            List<CountryData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objcountry.Code;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objcountry.Descriptions;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objcountry.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objcountry.CurrentIndex;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = objcountry.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhCountryDetailMST", arParms);
                    List<CountryData> lstcountryDetails = ORHelper<CountryData>.FromDataReaderToList(sqlReader);
                    result = lstcountryDetails;
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
        public List<CountryData> GetCountryDetailsByID(CountryData objcountry)
        {
            List<CountryData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objcountry.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objcountry.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditCountryDetailMST", arParms);
                    List<CountryData> lstcountryDetails = ORHelper<CountryData>.FromDataReaderToList(sqlReader);
                    result = lstcountryDetails;
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
        public int DeleteCountryDetailsByID(CountryData objcountry)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objcountry.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objcountry.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteCountryDetailMST", arParms);
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
