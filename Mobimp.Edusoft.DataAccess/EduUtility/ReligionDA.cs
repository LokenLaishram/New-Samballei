using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class ReligionDA
    {
        public int UpdateReligionDetails(ReligionData objreligion)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[0].Value = objreligion.ReligionID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objreligion.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objreligion.Descriptions;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objreligion.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[4].Value = objreligion.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objreligion.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objreligion.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateReligionDetailMST", arParms);
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
        public List<ReligionData> SearchReligionDetails(ReligionData objreligion)
        {
            List<ReligionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objreligion.Code;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objreligion.Descriptions;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objreligion.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objreligion.CurrentIndex;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = objreligion.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhReligionDetailMST", arParms);
                    List<ReligionData> lstReligionDetails = ORHelper<ReligionData>.FromDataReaderToList(sqlReader);
                    result = lstReligionDetails;
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
        public List<ReligionData> GetReligionDetailsByID(ReligionData objreligion)
        {
            List<ReligionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[0].Value = objreligion.ReligionID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objreligion.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditReligionDetailMST", arParms);
                    List<ReligionData> lstReligionDetails = ORHelper<ReligionData>.FromDataReaderToList(sqlReader);
                    result = lstReligionDetails;
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
        public int DeleteReligionDetailsByID(ReligionData objreligion)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[0].Value = objreligion.ReligionID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objreligion.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteReligionDetailMST", arParms);
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
