using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduFeeUtility;

namespace Mobimp.Edusoft.DataAccess.EduFeeUtility
{
    public class PaymentTypeDA
    {
        public int UpdatePaymentTypeDetails(PaymentTypeData objpayment)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[0].Value = objpayment.PaymentTypeID;

                    arParms[1] = new SqlParameter("@PaymentType", SqlDbType.VarChar);
                    arParms[1].Value = objpayment.PaymentType;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objpayment.AddedBy;

                    arParms[3] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[3].Value = objpayment.UserId;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objpayment.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objpayment.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdatePaymentTypeDetailMST", arParms);
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
        public List<PaymentTypeData> SearchPaymentTypeDetails(PaymentTypeData objpayment)
        {
            List<PaymentTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@PaymentType", SqlDbType.VarChar);
                    arParms[0].Value = objpayment.PaymentType;

                    arParms[1] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[1].Value = objpayment.PageSize;

                    arParms[2] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[2].Value = objpayment.CurrentIndex;

                    arParms[3] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[3].Value = objpayment.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhPaymentTypeDetailMST", arParms);
                    List<PaymentTypeData> lstPaymentTypeDetails = ORHelper<PaymentTypeData>.FromDataReaderToList(sqlReader);
                    result = lstPaymentTypeDetails;
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
        public List<PaymentTypeData> GetPaymentTypeDetailsByID(PaymentTypeData objpayment)
        {
            List<PaymentTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[0].Value = objpayment.PaymentTypeID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objpayment.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditPaymentTypeDetailMST", arParms);
                    List<PaymentTypeData> lstPaymentTypeDetails = ORHelper<PaymentTypeData>.FromDataReaderToList(sqlReader);
                    result = lstPaymentTypeDetails;
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
        public int DeletePaymentTypeDetailsByID(PaymentTypeData objpayment)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[0].Value = objpayment.PaymentTypeID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objpayment.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeletePaymentTypeDetailMST", arParms);
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
