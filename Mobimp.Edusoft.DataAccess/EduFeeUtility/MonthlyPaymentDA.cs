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
    public class MonthlyPaymentDA
    {
        public List<MonthlyPaymentData> GetMonthlyPayment(MonthlyPaymentData objpayment)
        {
            List<MonthlyPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

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

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchMonthlyPayment", arParms);
                    List<MonthlyPaymentData> lstpayment = ORHelper<MonthlyPaymentData>.FromDataReaderToList(sqlReader);
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
        public int UpdateMonthlyPayment(MonthlyPaymentData objpayment)
        {
            int result = 0;
            try
            {
                {


                    SqlParameter[] arParms = new SqlParameter[15];


                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objpayment.XMLData;

                    arParms[1] = new SqlParameter("@Prepaid", SqlDbType.Int);
                    arParms[1].Value = objpayment.Prepaid;

                    arParms[2] = new SqlParameter("@Postpaid", SqlDbType.Int);
                    arParms[2].Value = objpayment.Postpaid;

                    arParms[3] = new SqlParameter("@Fine", SqlDbType.Money);
                    arParms[3].Value = objpayment.Fine;

                    arParms[4] = new SqlParameter("@IsOneTimePayment", SqlDbType.Int);
                    arParms[4].Value = objpayment.IsOneTimePayment;

                    arParms[5] = new SqlParameter("@DiscountDate", SqlDbType.DateTime);
                    arParms[5].Value = objpayment.DiscountDate;

                    arParms[6] = new SqlParameter("@DiscountLimit", SqlDbType.Money);
                    arParms[6].Value = objpayment.DiscountLimit;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objpayment.AcademicSessionID;

                    arParms[8] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[8].Value = objpayment.ClassID;

                    arParms[9] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[9].Value = objpayment.CategoryID;

                    arParms[10] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[10].Value = objpayment.FeeTypeID;

                    arParms[11] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[11].Value = objpayment.UserId;

                    arParms[12] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[12].Value = objpayment.CompanyID;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;


                    arParms[14] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[14].Value = objpayment.ID;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateMonthlyPayment", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[13].Value);
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
