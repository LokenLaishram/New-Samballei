using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduAccount;

namespace Mobimp.Edusoft.DataAccess.EduAccount
{
    public class TransactionDA
    {
        public List<TransactionData> SaveAccountTransaction(TransactionData objtran)
        {
            List<TransactionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objtran.XMLData;

                    arParms[1] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
                    arParms[1].Value = objtran.TransactionTypeID;

                    arParms[2] = new SqlParameter("@TransactionDate", SqlDbType.DateTime);
                    arParms[2].Value = objtran.TransactionDate;

                    arParms[3] = new SqlParameter("@TotalCredit", SqlDbType.Money);
                    arParms[3].Value = objtran.TotalCredit;

                    arParms[4] = new SqlParameter("@OverallNaration", SqlDbType.VarChar);
                    arParms[4].Value = objtran.OverallNaration;

                    arParms[5] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[5].Value = objtran.PaymentModeID;

                    arParms[6] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[6].Value = objtran.BankName;

                    arParms[7] = new SqlParameter("@Invoice", SqlDbType.VarChar);
                    arParms[7].Value = objtran.Invoice;

                    arParms[8] = new SqlParameter("@ChequeNo", SqlDbType.VarChar);
                    arParms[8].Value = objtran.ChequeNo;

                    arParms[9] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[9].Value = objtran.EmployeeID;

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = objtran.AcademicSessionID;

                    arParms[11] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[11].Value = objtran.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_savetransactiondetails", arParms);
                    List<TransactionData> lstDetails = ORHelper<TransactionData>.FromDataReaderToList(sqlReader);
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
        //--Tab2--//
        public List<TransactionData> SearchAccountTransactionList(TransactionData objst)
        {
            List<TransactionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
                    arParms[0].Value = objst.TransactionTypeID;

                    arParms[1] = new SqlParameter("@AccountLedgerID", SqlDbType.Int);
                    arParms[1].Value = objst.AccountLedgerID;

                    arParms[2] = new SqlParameter("@TransactionNo", SqlDbType.VarChar);
                    arParms[2].Value = objst.TransactionNo;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objst.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objst.Dateto;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objst.IsActive;

                    arParms[6] = new SqlParameter("@AccountStatusID", SqlDbType.Int);
                    arParms[6].Value = objst.AccountStatusID;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objst.CurrentIndex;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objst.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_searchtransactiondetails", arParms);
                    List<TransactionData> lstDetails = ORHelper<TransactionData>.FromDataReaderToList(sqlReader);
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
        public List<TransactionData> SearchChildTransactionDetails(TransactionData objgrp)
        {
            List<TransactionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@TransactionNo", SqlDbType.VarChar);
                    arParms[0].Value = objgrp.TransactionNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_searchchildtransactiondetails", arParms);
                    List<TransactionData> lstDetails = ORHelper<TransactionData>.FromDataReaderToList(sqlReader);
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
        public int DeleteTransactionbyTranNo(TransactionData objtran)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@TransactionNo", SqlDbType.VarChar);
                    arParms[0].Value = objtran.TransactionNo;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objtran.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objtran.Remark;
                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[4].Value = objtran.EmployeeID;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_account_deletetransactionbytranno", arParms);
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
