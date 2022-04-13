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
    public class ManualAttendanceDA
    {
        public List<ManualAttendanceData> GetAttendanceDetails(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = objData.YearID;

                    arParms[1] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[1].Value = objData.Year;

                    arParms[2] = new SqlParameter("@Date", SqlDbType.DateTime);
                    arParms[2].Value = objData.Date;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objData.AddedBy;

                    arParms[4] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[4].Value = objData.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objData.CompanyID;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objData.AcademicSessionID;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objData.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objData.CurrentIndex;

                    arParms[9] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[9].Value = objData.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetAttendanceDetails", arParms);
                    List<ManualAttendanceData> lstAttendanceDetails = ORHelper<ManualAttendanceData>.FromDataReaderToList(sqlReader);
                    result = lstAttendanceDetails;
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

        public int UpdateAttendanceDetails(ManualAttendanceData objData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_UpdateAttendanceDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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

        //-------------------------------------END MANUAL ATTENDANCE----------------------------------

        //-------------------------------------START ATTENDANCE DASHBOARD---------------------------------

        public List<ManualAttendanceData> GetAttendanceDashboard(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;
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

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objData.AcademicSessionID;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objData.PageSize;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetAttendanceDashboard", arParms);
                    List<ManualAttendanceData> lstAttendanceDashboard = ORHelper<ManualAttendanceData>.FromDataReaderToList(sqlReader);
                    result = lstAttendanceDashboard;
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

        //-------------------------------------END ATTENDANCE DASHBOARD---------------------------------


        //-------------------------------------START ADMIN ATTENDANCE DASHBOARD---------------------------------

        public List<ManualAttendanceData> GetEmployeeName(ManualAttendanceData ObjData)
        {
            List<ManualAttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.EmployeeName;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoEmployeeName", arParms);
                    List<ManualAttendanceData> lstEmployee = ORHelper<ManualAttendanceData>.FromDataReaderToList(sqlReader);
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

        public List<ManualAttendanceData> GetPreviewAttendanceDashboard(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = objData.YearID;

                    arParms[1] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[1].Value = objData.MonthID;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = objData.EmployeeID;                               

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objData.AcademicSessionID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objData.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Preview_attendance_dashboard", arParms);
                    List<ManualAttendanceData> lstAttendanceDetails = ORHelper<ManualAttendanceData>.FromDataReaderToList(sqlReader);
                    result = lstAttendanceDetails;
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

        public int UpdateAttendance(ManualAttendanceData objData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = objData.YearID;

                    arParms[1] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[1].Value = objData.MonthID;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = objData.EmployeeID;

                    arParms[3] = new SqlParameter("@DateDay", SqlDbType.Int);
                    arParms[3].Value = objData.DateDay;

                    arParms[4] = new SqlParameter("@AttendanceStatusID", SqlDbType.Int);
                    arParms[4].Value = objData.AttendanceStatusID;

                    arParms[5] = new SqlParameter("@AttendanceStatus", SqlDbType.VarChar);
                    arParms[5].Value = objData.AttendanceStatus;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objData.AddedBy;

                    arParms[7] = new SqlParameter("@UserLoginID", SqlDbType.Int);
                    arParms[7].Value = objData.UserId;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_UpdateAttendance", arParms);
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
    }
}
