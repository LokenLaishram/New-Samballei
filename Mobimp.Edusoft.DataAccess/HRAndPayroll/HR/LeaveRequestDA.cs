using Mobimp.Campusoft.Data.HRAndPayroll.HR;
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

namespace Mobimp.Campusoft.DataAccess.HRAndPayroll.HR
{
    public class LeaveRequestDA
    {
        public List<LeaveRequestData> GetLeaveRequestDetails(LeaveRequestData objData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = objData.YearID;

                    arParms[1] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[1].Value = objData.Year;

                    arParms[2] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[2].Value = objData.MonthID;

                    arParms[3] = new SqlParameter("@Month", SqlDbType.VarChar);
                    arParms[3].Value = objData.Month;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objData.AddedBy;

                    arParms[5] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[5].Value = objData.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objData.CompanyID;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objData.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetLeaveRequest", arParms);
                    List<LeaveRequestData> lstleaveRequest = ORHelper<LeaveRequestData>.FromDataReaderToList(sqlReader);
                    result = lstleaveRequest;
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
        public List<LeaveRequestData> InsertLeaveRequestDetails(LeaveRequestData objData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objData.XMLData;

                    arParms[1] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[1].Value = objData.AddedBy;

                    arParms[2] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[2].Value = objData.UserId;

                    arParms[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[3].Value = objData.CompanyID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objData.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@LeaveID", SqlDbType.Int);
                    arParms[6].Value = objData.LeaveID;

                    arParms[7] = new SqlParameter("@TotalDays", SqlDbType.Int);
                    arParms[7].Value = objData.TotalDays;

                    arParms[8] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[8].Value = objData.Remark;

                    arParms[9] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[9].Value = objData.YearID;

                    arParms[10] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[10].Value = objData.Year;

                    arParms[11] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[11].Value = objData.MonthID;

                    arParms[12] = new SqlParameter("@Month", SqlDbType.VarChar);
                    arParms[12].Value = objData.Month;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_SendLeaveRequest", arParms);
                    List<LeaveRequestData> lstresult = ORHelper<LeaveRequestData>.FromDataReaderToList(sqlReader);
                    result = lstresult;
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
        public int UpdateLeaveApproval(LeaveRequestData objData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objData.XMLData;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objData.EmployeeID;

                    arParms[2] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[2].Value = objData.UserId;

                    arParms[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[3].Value = objData.CompanyID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objData.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@TotalDays", SqlDbType.Int);
                    arParms[6].Value = objData.TotalDays;

                    arParms[7] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[7].Value = objData.Remark;

                    arParms[8] = new SqlParameter("@LRno", SqlDbType.VarChar);
                    arParms[8].Value = objData.LeaveRequestNo;

                    arParms[9] = new SqlParameter("@ApprovalStatus", SqlDbType.Int);
                    arParms[9].Value = objData.ApprovalStatus;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Update_Leave_Approval_Status", arParms);
                    if (result_ > 0 || result_ == -1)
                    { 
                        result = Convert.ToInt32(arParms[5].Value);
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
        public List<LeaveRequestData> SearchRequestList(LeaveRequestData leaveRequestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int);
                    arParms[0].Value = leaveRequestData.LeaveID;

                    arParms[1] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[1].Value = leaveRequestData.Datefrom;

                    arParms[2] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[2].Value = leaveRequestData.DateTo;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = leaveRequestData.IsActive;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = leaveRequestData.CurrentIndex;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = leaveRequestData.PageSize;

                    arParms[6] = new SqlParameter("@RequestStatus", SqlDbType.Int);
                    arParms[6].Value = leaveRequestData.RequestStatus;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_SearchLeaveRequestList", arParms);
                    List<LeaveRequestData> lstresult = ORHelper<LeaveRequestData>.FromDataReaderToList(sqlReader);
                    result = lstresult;
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> GetleavedetailbyLRNo(LeaveRequestData leaveRequestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@LeaveRequestNo", SqlDbType.VarChar);
                    arParms[0].Value = leaveRequestData.LeaveRequestNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_Leave_DetailsByLRNo", arParms);
                    List<LeaveRequestData> lstresult = ORHelper<LeaveRequestData>.FromDataReaderToList(sqlReader);
                    result = lstresult;
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteLeaveRequestDetailsByLRNo(LeaveRequestData requestData)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@LRN", SqlDbType.VarChar);
                arParms[0].Value = requestData.LeaveRequestNo;

                arParms[1] = new SqlParameter("@DeleteRemark", SqlDbType.VarChar);
                arParms[1].Value = requestData.DeleteRemark;

                arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[2].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_DeleteLeaveRequestDetailsByLRNo", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[2].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> GetChildLeaveRequest(LeaveRequestData requestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LRno", SqlDbType.VarChar);
                arParms[0].Value = requestData.LeaveRequestNo;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetChildGridRequestList", arParms);
                List<LeaveRequestData> lstresult = ORHelper<LeaveRequestData>.FromDataReaderToList(sqlReader);
                result = lstresult;
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteChildGridRequestList(LeaveRequestData requestData)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@LRno", SqlDbType.VarChar);
                arParms[0].Value = requestData.LeaveRequestNo;

                arParms[1] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[1].Value = requestData.ID;

                arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[2].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_DeleteChildGridRequestList", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[2].Value);
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
