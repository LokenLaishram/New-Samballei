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
    public class SalaryStructureDA
    {
  
        public List<SalaryStructureData> GetSalaryStructure(SalaryStructureData objData)
        {
            List<SalaryStructureData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = objData.YearID;

                    arParms[1] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[1].Value = objData.Year;
                                        
                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objData.AddedBy;

                    arParms[3] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[3].Value = objData.UserId;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objData.CompanyID;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objData.AcademicSessionID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objData.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objData.CurrentIndex;

                    arParms[8] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[8].Value = objData.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_SalaryStructure", arParms);
                    List<SalaryStructureData> lstSalaryDetails = ORHelper<SalaryStructureData>.FromDataReaderToList(sqlReader);
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

        public int UpdateSalaryStructure(SalaryStructureData objData)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_UpdateSalaryStructure", arParms);
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
