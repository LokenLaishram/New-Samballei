using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;

namespace Mobimp.Campusoft.DataAccess.HRAndPayroll.HR
{
    public class LoanPaymentDA
    {
        public List<LoanPaymentData> GetEmployeeName(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.EmployeeName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoEmployeeName", arParms);
                    List<LoanPaymentData> lstEmployee = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = lstEmployee;
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

        public List<LoanPaymentData> SaveLoanPayment(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.EmployeeID;

                    arParms[1] = new SqlParameter("@LoanTypeID", SqlDbType.Int);
                    arParms[1].Value = ObjData.LoanTypeID;                    

                    arParms[2] = new SqlParameter("@LoanAmount", SqlDbType.VarChar);
                    arParms[2].Value = ObjData.LoanAmount;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = ObjData.AddedBy;

                    arParms[4] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[4].Value = ObjData.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = ObjData.CompanyID;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = ObjData.AcademicSessionID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_SaveLoanPayment", arParms);
                    List<LoanPaymentData> LoanPaymentNo = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanPaymentNo;
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

        public List<LoanPaymentData> GetLoanRecordDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.EmployeeID;

                    arParms[1] = new SqlParameter("@LoanTypeID", SqlDbType.Int);
                    arParms[1].Value = ObjData.LoanTypeID;

                    arParms[2] = new SqlParameter("@LoanStatusID", SqlDbType.Int);
                    arParms[2].Value = ObjData.LoanStatusID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = ObjData.IsActive;

                    arParms[4] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[4].Value = ObjData.DateFrom;

                    arParms[5] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[5].Value = ObjData.DateTo;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = ObjData.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = ObjData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetLoanRecordDetails", arParms);
                    List<LoanPaymentData> LoanRecordList = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanRecordList;
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

        public List<LoanPaymentData> SearchChildPaymentRecordDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@PaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.LoanPaymentNo;                                       

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_SearchChildPaymentRecordDetails", arParms);
                    List<LoanPaymentData> LoanRecordList = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanRecordList;
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

        public List<LoanPaymentData> GetLoanDetailsByPaymentNo(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@LoanPaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.LoanPaymentNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetLoanDetailsByPaymentNo", arParms);
                    List<LoanPaymentData> LoanRecordList = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanRecordList;
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

        public int DeleteLoanByPaymentNo(LoanPaymentData objData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@PaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = objData.LoanPaymentNo;

                    arParms[1] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[1].Value = objData.Remark;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objData.AddedBy;

                    arParms[3] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[3].Value = objData.UserId;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objData.CompanyID;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objData.AcademicSessionID;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Delete_LoanRecord", arParms);
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

        //------------------------------------- Start Loan Repayment -------------------------------------

        public List<LoanPaymentData> GetPaymentNo(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@LoanPaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.LoanPaymentNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoPaymentNo", arParms);
                    List<LoanPaymentData> lstEmployee = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = lstEmployee;
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

        public List<LoanPaymentData> SaveLoanRepayment(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@LoanPaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.LoanPaymentNo;

                    arParms[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[1].Value = ObjData.EmployeeName;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = ObjData.EmployeeID;

                    arParms[3] = new SqlParameter("@LoanAmount", SqlDbType.Money);
                    arParms[3].Value = ObjData.LoanAmount;

                    arParms[4] = new SqlParameter("@BalanceAmount", SqlDbType.Money);
                    arParms[4].Value = ObjData.BalanceAmount;

                    arParms[5] = new SqlParameter("@ReturnAmount", SqlDbType.Money);
                    arParms[5].Value = ObjData.ReturnAmount;

                    arParms[6] = new SqlParameter("@DueAmount", SqlDbType.Money);
                    arParms[6].Value = ObjData.DueAmount;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = ObjData.AddedBy;

                    arParms[8] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[8].Value = ObjData.UserId;

                    arParms[9] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[9].Value = ObjData.CompanyID;

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = ObjData.AcademicSessionID;
                    
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_SaveLoanRepayment", arParms);
                    List<LoanPaymentData> LoanRepaymentNo = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanRepaymentNo;
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

        public List<LoanPaymentData> GetLoanRepaymentDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.EmployeeID;

                    arParms[1] = new SqlParameter("@LoanTypeID", SqlDbType.Int);
                    arParms[1].Value = ObjData.LoanTypeID;

                    arParms[2] = new SqlParameter("@LoanStatusID", SqlDbType.Int);
                    arParms[2].Value = ObjData.LoanStatusID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = ObjData.IsActive;

                    arParms[4] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[4].Value = ObjData.DateFrom;

                    arParms[5] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[5].Value = ObjData.DateTo;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = ObjData.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = ObjData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetLoanRepaymentDetails", arParms);
                    List<LoanPaymentData> LoanRecordList = ORHelper<LoanPaymentData>.FromDataReaderToList(sqlReader);
                    result = LoanRecordList;
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

        public int DeleteLoanRepaymentByReturnNo(LoanPaymentData objData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@PaymentNo", SqlDbType.VarChar);
                    arParms[0].Value = objData.LoanPaymentNo;

                    arParms[1] = new SqlParameter("@ReturnNo", SqlDbType.VarChar);
                    arParms[1].Value = objData.LoanReturnNo;

                    arParms[2] = new SqlParameter("@ReturnAmount", SqlDbType.Money);
                    arParms[2].Value = objData.ReturnAmount;

                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objData.Remark;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objData.AddedBy;

                    arParms[5] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[5].Value = objData.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objData.CompanyID;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objData.AcademicSessionID;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_DeleteLoanRepaymentByReturnNo", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[8].Value);
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

        //------------------------------------- End Loan Repayment -------------------------------------
    }
}
