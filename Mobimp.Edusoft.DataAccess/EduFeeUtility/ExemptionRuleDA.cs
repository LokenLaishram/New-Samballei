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
    public class ExemptionRuleDA
    {
        public List<ExemptionRuleData> GetExemptionRule(ExemptionRuleData objpayment)
        {
            List<ExemptionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objpayment.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objpayment.ClassID;

                    arParms[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[2].Value = objpayment.CategoryID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objpayment.FeeTypeID;
                    
                    arParms[4] = new SqlParameter("@PaymentID", SqlDbType.Int);
                    arParms[4].Value = objpayment.PaymentID;

                    arParms[5] = new SqlParameter("@FeeAmount_New", SqlDbType.Decimal);
                    arParms[5].Value = objpayment.FeeAmount_New;

                    arParms[6] = new SqlParameter("@FeeAmount_Old", SqlDbType.Decimal);
                    arParms[6].Value = objpayment.FeeAmount_Old;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchExemptionRule", arParms);
                    List<ExemptionRuleData> lstpayment = ORHelper<ExemptionRuleData>.FromDataReaderToList(sqlReader);
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
        public int UpdateExemptionRule(ExemptionRuleData objpayment)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objpayment.XMLData;
                    
                    arParms[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[1].Value = objpayment.UserId;

                    arParms[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[2].Value = objpayment.CompanyID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objpayment.AcademicSessionID;

                    arParms[5] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[5].Value = objpayment.ClassID;

                    arParms[6] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[6].Value = objpayment.CategoryID;

                    arParms[7] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[7].Value = objpayment.FeeTypeID;

                    arParms[8] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[8].Value = objpayment.ID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateExemptionRule", arParms);
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
        public List<TransportExemptionRuleData> GetTransportExemptionRule(TransportExemptionRuleData objpayment)
        {
            List<TransportExemptionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objpayment.AcademicSessionID;

                    arParms[1] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[1].Value = objpayment.RouteID;

                    arParms[2] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[2].Value = objpayment.VehicleNo;

                    arParms[3] = new SqlParameter("@FeeID", SqlDbType.Int);
                    arParms[3].Value = objpayment.FeeID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objpayment.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchTransportExemptionRule", arParms);
                    List<TransportExemptionRuleData> lstpayment = ORHelper<TransportExemptionRuleData>.FromDataReaderToList(sqlReader);
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
        public int UpdateTransportExemptionRule(TransportExemptionRuleData objpayment)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objpayment.XMLData;

                    arParms[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[1].Value = objpayment.CompanyID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objpayment.AcademicSessionID;

                    arParms[4] = new SqlParameter("@FeeID", SqlDbType.Int);
                    arParms[4].Value = objpayment.FeeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateTransportExemptionRule", arParms);
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
    }
}
