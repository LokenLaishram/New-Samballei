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
    public class OneTimePaymentDA
    {
        public List<OneTimePaymentData> GetOneTimePaymentList(OneTimePaymentData objpayment)
        {
            List<OneTimePaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objpayment.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objpayment.ClassID;

                    arParms[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[2].Value = objpayment.CategoryID;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objpayment.FeeTypeID;

                    arParms[4] = new SqlParameter("@PaymentId", SqlDbType.Int);
                    arParms[4].Value = objpayment.PaymentID;

                    arParms[5] = new SqlParameter("@AddRow", SqlDbType.Int);
                    arParms[5].Value = objpayment.AddRow;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchOneTimeFeePayment", arParms);
                    List<OneTimePaymentData> lstpayment = ORHelper<OneTimePaymentData>.FromDataReaderToList(sqlReader);
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
        public int UpdateOneTimePayment(OneTimePaymentData objonetime)
        {
            int result = 0;
            try
            {
                {

                    SqlParameter[] arParms = new SqlParameter[16];


                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objonetime.XMLData;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@Particulars", SqlDbType.VarChar);
                    arParms[2].Value = objonetime.Particulars;

                    arParms[3] = new SqlParameter("@FeeAmount_New", SqlDbType.Money);
                    arParms[3].Value = objonetime.FeeAmount_New;

                    arParms[4] = new SqlParameter("@FeeAmount_Old", SqlDbType.Money);
                    arParms[4].Value = objonetime.FeeAmount_Old;

                    arParms[5] = new SqlParameter("@IsActivate", SqlDbType.Bit);
                    arParms[5].Value = objonetime.IsActivate;

                    arParms[6] = new SqlParameter("@DiscountLimit", SqlDbType.Money);
                    arParms[6].Value = objonetime.DiscountLimit;
                    
                    arParms[7] = new SqlParameter("@DueDate", SqlDbType.VarChar);
                    arParms[7].Value = objonetime.DueDate;

                    arParms[8] = new SqlParameter("@Fine", SqlDbType.Money);
                    arParms[8].Value = objonetime.Fine;

                    arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[9].Value = objonetime.AcademicSessionID;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objonetime.ClassID;

                    arParms[11] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[11].Value = objonetime.CategoryID;

                    arParms[12] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[12].Value = objonetime.FeeTypeID;

                    arParms[13] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[13].Value = objonetime.UserId;

                    arParms[14] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[14].Value = objonetime.CompanyID;

                    arParms[15] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[15].Value = objonetime.ID;
                 
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateOneTimePayment", arParms);
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
        public int DeleteOneTimeByID(OneTimePaymentData objonetime)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objonetime.OnetimeID;
                    
                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;
                    
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteOneTimePayment", arParms);
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
