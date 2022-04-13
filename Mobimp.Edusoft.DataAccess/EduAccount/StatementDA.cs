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
    public class StatementDA
    {       
        public List<StatementData> SearchAccountTransactionList(StatementData objst)
        {
            List<StatementData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

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

                    arParms[5] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[5].Value = objst.PaymentModeID;

                    arParms[6] = new SqlParameter("@AccountStatusID", SqlDbType.Int);
                    arParms[6].Value = objst.AccountStatusID;

                    arParms[7] = new SqlParameter("@CollectedByID", SqlDbType.Int);
                    arParms[7].Value = objst.CollectedByID;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objst.IsActive;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objst.CurrentIndex;

                    arParms[10] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[10].Value = objst.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_transactionstatement", arParms);
                    List<StatementData> lstDetails = ORHelper<StatementData>.FromDataReaderToList(sqlReader);
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
        public List<StatementData> ExpenditureTransactionList(StatementData objst)
        {
            List<StatementData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

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

                    arParms[5] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[5].Value = objst.PaymentModeID;

                    arParms[6] = new SqlParameter("@AccountStatusID", SqlDbType.Int);
                    arParms[6].Value = objst.AccountStatusID;

                    arParms[7] = new SqlParameter("@CollectedByID", SqlDbType.Int);
                    arParms[7].Value = objst.CollectedByID;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objst.IsActive;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objst.CurrentIndex;

                    arParms[10] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[10].Value = objst.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_exptransactionstatement", arParms);
                    List<StatementData> lstDetails = ORHelper<StatementData>.FromDataReaderToList(sqlReader);
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
    }
}
