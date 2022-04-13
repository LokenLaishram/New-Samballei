using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.Payroll;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;

namespace Mobimp.Campusoft.DataAccess.HRAndPayroll.Payroll
{
    public class DailyProxyManagerDA
    {
        public List<DailyProxyManagerData> GetEmployeeName(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.EmployeeName;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoEmployeeName", arParms);
                    List<DailyProxyManagerData> lstEmployee = ORHelper<DailyProxyManagerData>.FromDataReaderToList(sqlReader);
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

        public List<DailyProxyManagerData> GetEmployeeDetailsByID(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];
                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.EmployeeID;

                    arParms[1] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[1].Value = ObjData.YearID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetEmployeeDetailsByID", arParms);
                    List<DailyProxyManagerData> lstEmployee = ORHelper<DailyProxyManagerData>.FromDataReaderToList(sqlReader);
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

        public int UpdateDailyProxyDetails(DailyProxyManagerData ObjData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[19];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = ObjData.YearID;

                    arParms[1] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[1].Value = ObjData.Year;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = ObjData.EmployeeID;

                    arParms[3] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[3].Value = ObjData.EmployeeName;

                    arParms[4] = new SqlParameter("@ProxyCharge", SqlDbType.Money);
                    arParms[4].Value = ObjData.ProxyCharge;

                    arParms[5] = new SqlParameter("@Date", SqlDbType.DateTime);
                    arParms[5].Value = ObjData.Date;

                    arParms[6] = new SqlParameter("@ProxyForID", SqlDbType.BigInt);
                    arParms[6].Value = ObjData.ProxyForID;

                    arParms[7] = new SqlParameter("@ProxyForName", SqlDbType.VarChar);
                    arParms[7].Value = ObjData.ProxyForName;

                    arParms[8] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[8].Value = ObjData.ClassID;

                    arParms[9] = new SqlParameter("@ClassName", SqlDbType.VarChar);
                    arParms[9].Value = ObjData.ClassName;

                    arParms[10] = new SqlParameter("@Reason", SqlDbType.VarChar);
                    arParms[10].Value = ObjData.Reason;

                    arParms[11] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[11].Value = ObjData.UserId;

                    arParms[12] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[12].Value = ObjData.AddedBy;

                    arParms[13] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[13].Value = ObjData.CompanyID;

                    arParms[14] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[14].Value = ObjData.AcademicSessionID;

                    arParms[15] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[15].Value = ObjData.IsActive;

                    arParms[16] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[16].Value = ObjData.ActionType;

                    arParms[17] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[17].Direction = ParameterDirection.Output;

                    arParms[18] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[18].Value = ObjData.ID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hr_Payroll_UpdateDailyProxyDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[15].Value);
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

        public List<DailyProxyManagerData> GetDailyProxyDetails(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];                    

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = ObjData.YearID;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[1].Value = ObjData.EmployeeID;

                    arParms[2] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[2].Value = ObjData.DateFrom;

                    arParms[3] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[3].Value = ObjData.DateTo;

                    arParms[4] = new SqlParameter("@ProxyForID", SqlDbType.BigInt);
                    arParms[4].Value = ObjData.ProxyForID;

                    arParms[5] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[5].Value = ObjData.ClassID;

                    arParms[6] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[6].Value = ObjData.IsActive;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = ObjData.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = ObjData.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetDailyProxyDetails", arParms);
                    List<DailyProxyManagerData> lstDailyProxy = ORHelper<DailyProxyManagerData>.FromDataReaderToList(sqlReader);
                    result = lstDailyProxy;
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

        public List<DailyProxyManagerData> GetDailyProxyByID(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.ID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetDailyProxyByID", arParms);
                    List<DailyProxyManagerData> lstDailyProxy = ORHelper<DailyProxyManagerData>.FromDataReaderToList(sqlReader);
                    result = lstDailyProxy;
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

        public int DeleteDailyProxyByID(DailyProxyManagerData ObjData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.ID;

                    arParms[1] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[1].Value = ObjData.UserId;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = ObjData.AddedBy;

                    arParms[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[3].Value = ObjData.CompanyID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = ObjData.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hr_Payroll_DeleteDailyProxyByID", arParms);
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

    }
}
