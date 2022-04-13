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
    public class SalaryGeneratorDA
    {
        public List<SalaryGeneratorData> GetEmployeeName(SalaryGeneratorData ObjData)
        {
            List<SalaryGeneratorData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.EmployeeName;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoEmployeeName", arParms);
                    List<SalaryGeneratorData> lstEmployee = ORHelper<SalaryGeneratorData>.FromDataReaderToList(sqlReader);
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

        public List<SalaryGeneratorData> GetSalaryGenerator(SalaryGeneratorData objData)
        {
            List<SalaryGeneratorData> result = null;
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
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_SalaryGenerator", arParms);
                    List<SalaryGeneratorData> lstSalaryDetails = ORHelper<SalaryGeneratorData>.FromDataReaderToList(sqlReader);
                    result = lstSalaryDetails;
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
