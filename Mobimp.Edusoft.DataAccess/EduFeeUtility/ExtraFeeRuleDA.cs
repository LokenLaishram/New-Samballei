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
    public class ExtraFeeRuleDA
    {
        public List<ExtraFeeRuleData> GetExtraRule(ExtraFeeRuleData objextra)
        {
            List<ExtraFeeRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objextra.AcademicSessionID;

                    arParms[1] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[1].Value = objextra.CategoryID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objextra.FeeTypeID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objextra.ClassID;

                    arParms[4] = new SqlParameter("@AddRow", SqlDbType.Int);
                    arParms[4].Value = objextra.AddRow;

                    arParms[5] = new SqlParameter("@IsOptional", SqlDbType.Int);
                    arParms[5].Value = objextra.IsOptional;

                    arParms[6] = new SqlParameter("@IsMisc", SqlDbType.Int);
                    arParms[6].Value = objextra.IsMisc;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchExtraRule", arParms);
                    List<ExtraFeeRuleData> lstpayment = ORHelper<ExtraFeeRuleData>.FromDataReaderToList(sqlReader);
                    result = lstpayment;
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
        public int UpdateExtraFeeRule(ExtraFeeRuleData objextra)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[0].Value = objextra.FeeTypeID;

                    arParms[1] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[1].Value = objextra.CategoryID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objextra.ClassID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objextra.AcademicSessionID;

                    arParms[4] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[4].Value = objextra.XMLData;
                    
                    arParms[5] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[5].Value = objextra.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objextra.CompanyID;
                    
                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateExtraFeeRule", arParms);
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
        public int DeleteExtraRuleByID(ExtraFeeRuleData objextra)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objextra.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteExtraFeeRule", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
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
