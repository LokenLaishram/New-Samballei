using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.DataAccess.StudentPortalDA
{
    public class OnlinepaymentDA
    {
        public List<PaymentData> Getfeepaymentdetails(PaymentData objDA)
        {
            List<PaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objDA.StudentID;

                    arParms[1] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[1].Value = objDA.FeeTypeID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objDA.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_Get_OnlinePaymentdetails", arParms);
                    List<PaymentData> listdetails = ORHelper<PaymentData>.FromDataReaderToList(sqlReader);
                    result = listdetails;
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
        public int Payfee(PaymentData objDA)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objDA.XMLData;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objDA.StudentID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objDA.FeeTypeID;

                    arParms[3] = new SqlParameter("@TotalAmount", SqlDbType.Money);
                    arParms[3].Value = objDA.TotalAmount;

                    arParms[4] = new SqlParameter("@TotalFineAmount", SqlDbType.Money);
                    arParms[4].Value = objDA.FineAmount;

                    arParms[5] = new SqlParameter("@TotalDiscountAmount", SqlDbType.Money);
                    arParms[5].Value = objDA.ExemptionAmount;

                    arParms[6] = new SqlParameter("@TotalPaidAmount", SqlDbType.Money);
                    arParms[6].Value = objDA.TotalPaidAmount;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objDA.AcademicSessionID;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objDA.CompanyID;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    arParms[10] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[10].Value = objDA.PaymentType;

                    arParms[11] = new SqlParameter("@Addedby", SqlDbType.Int);
                    arParms[11].Value = objDA.EmployeeID;

                    arParms[12] = new SqlParameter("@Paymentreceipt", SqlDbType.Image);
                    arParms[12].Value = objDA.Paymentreceipt;

                    arParms[13] = new SqlParameter("@Billdate", SqlDbType.DateTime);
                    arParms[13].Value = objDA.Billdate;

                    arParms[14] = new SqlParameter("@PaymentID", SqlDbType.VarChar);
                    arParms[14].Value = objDA.PaymentID;

                    arParms[15] = new SqlParameter("@OrderID", SqlDbType.VarChar);
                    arParms[15].Value = objDA.OrderID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_MakeOnlinepayment", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[9].Value);
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
