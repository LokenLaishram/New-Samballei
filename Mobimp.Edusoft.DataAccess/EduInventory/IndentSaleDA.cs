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
    public class IndentSaleDA
    {
        public List<IndentSaleData> SearchIndentDetailsList(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@IsApproved", SqlDbType.Int);
                    arParms[0].Value = objdata.IsApproved;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[8].Value = objdata.IndentNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_searchindentgenlist", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
     
        public List<IndentSaleData> GetItemDetailsByIndentNo(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.IndentNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_Getitemdetailsbyindentno", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
      
        //---TAB2-PAYMENT---//
        public List<IndentSaleData> SaveIndentSalePayment(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[24];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@VendorName", SqlDbType.VarChar);
                    arParms[3].Value = objdata.VendorName;

                    arParms[4] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[4].Value = objdata.IndentNo;

                    arParms[5] = new SqlParameter("@TotalIssueQty", SqlDbType.Int);
                    arParms[5].Value = objdata.TotalIssueQty;

                    arParms[6] = new SqlParameter("@GdTotalAmount", SqlDbType.Money);
                    arParms[6].Value = objdata.GdTotalAmount;

                    arParms[7] = new SqlParameter("@GdDiscount", SqlDbType.Money);
                    arParms[7].Value = objdata.GdDiscount;

                    arParms[8] = new SqlParameter("@GdDiscountValue", SqlDbType.Money);
                    arParms[8].Value = objdata.GdDiscountValue;

                    arParms[9] = new SqlParameter("@GdNetAmount", SqlDbType.Money);
                    arParms[9].Value = objdata.GdNetAmount;

                    arParms[10] = new SqlParameter("@Gdtax", SqlDbType.Money);
                    arParms[10].Value = objdata.Gdtax;

                    arParms[11] = new SqlParameter("@GdPayable", SqlDbType.Money);
                    arParms[11].Value = objdata.GdPayable;

                    arParms[12] = new SqlParameter("@GdPaid", SqlDbType.Money);
                    arParms[12].Value = objdata.GdPaid;

                    arParms[13] = new SqlParameter("@GdDue", SqlDbType.Money);
                    arParms[13].Value = objdata.GdDue;

                    arParms[14] = new SqlParameter("@BankPaymentDate", SqlDbType.DateTime);
                    arParms[14].Value = objdata.BankPaymentDate;

                    arParms[15] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[15].Value = objdata.PaymentModeID;

                    arParms[16] = new SqlParameter("@BankID", SqlDbType.Int);
                    arParms[16].Value = objdata.BankID;

                    arParms[17] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[17].Value = objdata.BankName;

                    arParms[18] = new SqlParameter("@Invoice", SqlDbType.VarChar);
                    arParms[18].Value = objdata.Invoice;

                    arParms[19] = new SqlParameter("@ChequeNo", SqlDbType.VarChar);
                    arParms[19].Value = objdata.ChequeNo;

                    arParms[20] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[20].Value = objdata.Remark;

                    arParms[21] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[21].Value = objdata.EmployeeID;

                    arParms[22] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[22].Value = objdata.AcademicSessionID;

                    arParms[23] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[23].Value = objdata.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_saveindentpayment", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        //--- TAB 3 ---//
        public List<IndentSaleData> SearchSaleDetailsList(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
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

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objdata.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_searchsaledetails", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        public List<IndentSaleData> SearchChildBillDetails(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_searchchildsaledetails", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        public int DeleteSaleByBillNo(IndentSaleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indentsale_deletesalepaymentbybillno", arParms);
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
