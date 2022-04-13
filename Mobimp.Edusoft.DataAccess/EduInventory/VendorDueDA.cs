using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduInventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mobimp.Edusoft.DataAccess.EduInventory
{
    public class VendorDueDA
    {
        public List<VendorDueData> SearchSaleDetailsList(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objdata.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objdata.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_searchvendorduedetails", arParms);
                    List<VendorDueData> lstDetails = ORHelper<VendorDueData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public List<VendorDueData> SearchChildBillDetails(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_searchchildvendorduedetails", arParms);
                    List<VendorDueData> lstDetails = ORHelper<VendorDueData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        //--Tab 2 due pament--//
        public List<VendorDueData> GetPaymentDetailsByBillNo(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_getpaymentdetailsbybillno", arParms);
                    List<VendorDueData> lstDetails = ORHelper<VendorDueData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public List<VendorDueData> SaveDuePayment(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[0].Value = objdata.Remark;

                    arParms[1] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[1].Value = objdata.BillNo;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@GdTotalAmount", SqlDbType.Money);
                    arParms[3].Value = objdata.GdTotalAmount;

                    arParms[4] = new SqlParameter("@GdDiscount", SqlDbType.Money);
                    arParms[4].Value = objdata.GdDiscount;

                    arParms[5] = new SqlParameter("@GdPayable", SqlDbType.Money);
                    arParms[5].Value = objdata.GdPayable;

                    arParms[6] = new SqlParameter("@GdPaid", SqlDbType.Money);
                    arParms[6].Value = objdata.GdPaid;

                    arParms[7] = new SqlParameter("@GdDue", SqlDbType.Money);
                    arParms[7].Value = objdata.GdDue;

                    arParms[8] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[8].Value = objdata.PaymentModeID;

                    arParms[9] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[9].Value = objdata.BankName;

                    arParms[10] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[10].Value = objdata.CompanyID;

                    arParms[11] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[11].Value = objdata.EmployeeID;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objdata.AcademicSessionID;

                    arParms[13] = new SqlParameter("@Invoice", SqlDbType.VarChar);
                    arParms[13].Value = objdata.Invoice;

                    arParms[14] = new SqlParameter("@ChequeNo", SqlDbType.VarChar);
                    arParms[14].Value = objdata.ChequeNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_saveduepaymentdetails", arParms);
                    List<VendorDueData> lstDetails = ORHelper<VendorDueData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        //---TAB3 DUE COLLECTION ----//
        public List<VendorDueData> SearchDueCollectionList(VendorDueData objdata)
        {
            List<VendorDueData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objdata.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objdata.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_searchvendorduecollectionlist", arParms);
                    List<VendorDueData> lstDetails = ORHelper<VendorDueData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public int DeleteDueCollectionByDueBillNo(VendorDueData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@DueBillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.DueBillNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_due_deleteduecolletionbyduebillno", arParms);
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
