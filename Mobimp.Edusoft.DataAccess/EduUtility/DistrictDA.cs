using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class DistrictDA
    {
        public int UpdateDistrictDetails(DistrictData objDistrict)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                    arParms[0].Value = objDistrict.DistrictID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objDistrict.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objDistrict.Descriptions;

                    arParms[3] = new SqlParameter("@CountryID", SqlDbType.Int);
                    arParms[3].Value = objDistrict.CountryID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objDistrict.AddedBy;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[5].Value = objDistrict.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objDistrict.CompanyID;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objDistrict.ActionType;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    arParms[9] = new SqlParameter("@StateID", SqlDbType.SmallInt);
                    arParms[9].Value = objDistrict.StateID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateDistrictDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[8].Value);
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
        public List<DistrictData> SearchDistrictDetails(DistrictData objDistrict)
        {
            List<DistrictData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objDistrict.Code;
                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objDistrict.Descriptions;
                    arParms[2] = new SqlParameter("@CountryID", SqlDbType.Int);
                    arParms[2].Value = objDistrict.CountryID;
                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objDistrict.PageSize;
                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objDistrict.CurrentIndex;
                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objDistrict.ActionType;
                    arParms[6] = new SqlParameter("@StateID", SqlDbType.Int);
                    arParms[6].Value = objDistrict.StateID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhDistrictDetailMST", arParms);
                    List<DistrictData> lstDistrictDetails = ORHelper<DistrictData>.FromDataReaderToList(sqlReader);
                    result = lstDistrictDetails;
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
        public List<DistrictData> GetDistrictDetailsByID(DistrictData objDistrict)
        {
            List<DistrictData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                    arParms[0].Value = objDistrict.DistrictID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objDistrict.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditDistrictDetailMST", arParms);
                    List<DistrictData> lstDistrictDetails = ORHelper<DistrictData>.FromDataReaderToList(sqlReader);
                    result = lstDistrictDetails;
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
        public int DeleteDistrictDetailsByID(DistrictData objDistrict)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                    arParms[0].Value = objDistrict.DistrictID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objDistrict.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteDistrictDetailMST", arParms);
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


        public List<LookupItem> GetStatelistByCountryID(int CountryID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@CountryID", SqlDbType.Int);
                arParms[0].Value = CountryID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetStateByCountryID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
    }
}

