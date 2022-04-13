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
    public class AccountLedgerDA
    {   
        public int UpdateAccountLedgerDetails(AccountLedgerData objGroup)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@AccountLedgerID", SqlDbType.Int);
                    arParms[0].Value = objGroup.AccountLedgerID;

                    arParms[1] = new SqlParameter("@AccountLedgerName", SqlDbType.VarChar);
                    arParms[1].Value = objGroup.AccountLedgerName;

                    arParms[2] = new SqlParameter("@AccountGroupID", SqlDbType.Int);
                    arParms[2].Value = objGroup.AccountGroupID;

                    arParms[3] = new SqlParameter("@AccountNatureID", SqlDbType.Bit);
                    arParms[3].Value = objGroup.AccountNatureID;

                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[4].Value = objGroup.EmployeeID;

                    arParms[5] = new SqlParameter("@OpeningBalance", SqlDbType.Money);
                    arParms[5].Value = objGroup.OpeningBalance;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objGroup.ActionType;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objGroup.AcademicSessionID;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[9].Value = objGroup.IsActive;

                    arParms[10] = new SqlParameter("@FeetypeID", SqlDbType.Int);
                    arParms[10].Value = objGroup.Feetypeid;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_account_updateaccountledgername", arParms);
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
        public List<AccountLedgerData> SearchAccountLedgerDetails(AccountLedgerData objgrp)
        {
            List<AccountLedgerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AccountGroupID", SqlDbType.Int);
                    arParms[0].Value = objgrp.AccountGroupID;

                    arParms[1] = new SqlParameter("@AccountLedgerID", SqlDbType.Int);
                    arParms[1].Value = objgrp.AccountLedgerID;

                    arParms[2] = new SqlParameter("@AccountLedgerName", SqlDbType.VarChar);
                    arParms[2].Value = objgrp.AccountLedgerName;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objgrp.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objgrp.CurrentIndex;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objgrp.IsActive;

                    arParms[6] = new SqlParameter("@AccountNatureID", SqlDbType.Int);
                    arParms[6].Value = objgrp.AccountNatureID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_getaccountledgerlist", arParms);
                    List<AccountLedgerData> lstDetails = ORHelper<AccountLedgerData>.FromDataReaderToList(sqlReader);
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
        public List<AccountLedgerData> GetAccountLedgerDetailsByID(AccountLedgerData objgrp)
        {
            List<AccountLedgerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AccountLedgerID", SqlDbType.Int);
                    arParms[0].Value = objgrp.AccountLedgerID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_account_getaccountledgerdetailsbyid", arParms);
                    List<AccountLedgerData> lstDetails = ORHelper<AccountLedgerData>.FromDataReaderToList(sqlReader);
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
        public int DeleteAccountLedgerDetailsByID(AccountLedgerData objGroup)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AccountLedgerID", SqlDbType.Int);
                    arParms[0].Value = objGroup.AccountLedgerID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objGroup.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objGroup.Remark;
                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[4].Value = objGroup.EmployeeID;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_account_deleteaccountledgerbyid", arParms);
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
