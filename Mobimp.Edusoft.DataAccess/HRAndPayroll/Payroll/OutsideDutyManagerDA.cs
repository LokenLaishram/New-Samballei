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
    public class OutsideDutyManagerDA
    {
        public List<OutsideDutyManagerData> GetEmployeeName(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[0].Value = ObjData.EmployeeName;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_Get_AutoEmployeeName", arParms);
                    List<OutsideDutyManagerData> lstEmployee = ORHelper<OutsideDutyManagerData>.FromDataReaderToList(sqlReader);
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

        public List<OutsideDutyManagerData> GetEmployeeNameByID(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetEmployeeNameByID", arParms);
                    List<OutsideDutyManagerData> lstEmployee = ORHelper<OutsideDutyManagerData>.FromDataReaderToList(sqlReader);
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

        public int UpdateOutsideDutyDetails(OutsideDutyManagerData ObjData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = ObjData.YearID;

                    arParms[1] = new SqlParameter("@Year", SqlDbType.VarChar);
                    arParms[1].Value = ObjData.Year;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = ObjData.EmployeeID;

                    arParms[3] = new SqlParameter("@EmployeeName", SqlDbType.VarChar);
                    arParms[3].Value = ObjData.EmployeeName;

                    arParms[4] = new SqlParameter("@Date", SqlDbType.DateTime);
                    arParms[4].Value = ObjData.Date;

                    arParms[5] = new SqlParameter("@Reason", SqlDbType.VarChar);
                    arParms[5].Value = ObjData.Reason;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[6].Value = ObjData.UserId;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = ObjData.AddedBy;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = ObjData.CompanyID;

                    arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[9].Value = ObjData.AcademicSessionID;

                    arParms[10] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[10].Value = ObjData.IsActive;

                    arParms[11] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[11].Value = ObjData.ActionType;

                    arParms[12] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[12].Direction = ParameterDirection.Output;

                    arParms[13] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[13].Value = ObjData.ID;

                    arParms[14] = new SqlParameter("@ConvenienceFee", SqlDbType.Money);
                    arParms[14].Value = ObjData.ConvenienceFee;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hr_Payroll_UpdateOutsideDutyDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[12].Value);
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

        public List<OutsideDutyManagerData> GetOutsideDutyDetails(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[0].Value = ObjData.YearID;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[1].Value = ObjData.EmployeeID;

                    arParms[2] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[2].Value = ObjData.Datefrom;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = ObjData.IsActive;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = ObjData.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = ObjData.CurrentIndex;

                    arParms[6] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[6].Value = ObjData.Dateto;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetOutsideDutyDetails", arParms);
                    List<OutsideDutyManagerData> lstOutsideDuty = ORHelper<OutsideDutyManagerData>.FromDataReaderToList(sqlReader);
                    result = lstOutsideDuty;
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

        public List<OutsideDutyManagerData> GetOutsideDutyByID(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];
                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.ID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_GetOutsideDutyByID", arParms);
                    List<OutsideDutyManagerData> lstOutsideDuty = ORHelper<OutsideDutyManagerData>.FromDataReaderToList(sqlReader);
                    result = lstOutsideDuty;
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

        public int DeleteOutsideDutyByID(OutsideDutyManagerData ObjData)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hr_Payroll_DeleteOutsideDutyByID", arParms);
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

        public int UpdateOutsideDutyListDetails(OutsideDutyManagerData objData)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_HR_Payroll_UpdateOutsideDutyListDetails", arParms);
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
