using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduEmployee;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduEmployee
{
    public class EmployeeDA
    {
        public int UpdateEmployeeDetails(EmployeeData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[52];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@EmployeeTypeID", SqlDbType.Int);
                    arParms[1].Value = objempt.EmployeeTypeID;

                    arParms[2] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[2].Value = objempt.EmpName;

                    arParms[3] = new SqlParameter("@SalutationID", SqlDbType.Int);
                    arParms[3].Value = objempt.SalutationID;

                    arParms[4] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[4].Value = objempt.SexID;

                    arParms[5] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[5].Value = objempt.ReligionID;

                    arParms[6] = new SqlParameter("@DesignationID", SqlDbType.Int);
                    arParms[6].Value = objempt.DesignationID;

                    arParms[7] = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    arParms[7].Value = objempt.DepartmentID;

                    arParms[8] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[8].Value = objempt.DOB;

                    arParms[10] = new SqlParameter("@EmaildID", SqlDbType.VarChar);
                    arParms[10].Value = objempt.EmaildID;

                    arParms[11] = new SqlParameter("@PhoneNo", SqlDbType.VarChar);
                    arParms[11].Value = objempt.PhoneNo;

                    arParms[12] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                    arParms[12].Value = objempt.MobileNo;

                    arParms[13] = new SqlParameter("@DigitalSignatureLocation", SqlDbType.VarChar);
                    arParms[13].Value = objempt.DigitalSignatureLocation;

                    arParms[14] = new SqlParameter("@EmployeePhotoLocation", SqlDbType.VarChar);
                    arParms[14].Value = objempt.EmployeePhotoLocation;

                    arParms[15] = new SqlParameter("@CurrentAddress", SqlDbType.VarChar);
                    arParms[15].Value = objempt.CurrentAddress;

                    arParms[16] = new SqlParameter("@CurrentCountryID", SqlDbType.Int);
                    arParms[16].Value = objempt.CurrentCountryID;

                    arParms[17] = new SqlParameter("@CurrentStateID", SqlDbType.Int);
                    arParms[17].Value = objempt.CurrentStateID;

                    arParms[18] = new SqlParameter("@CurrentDistrictID", SqlDbType.Int);
                    arParms[18].Value = objempt.CurrentDistrictID;

                    arParms[19] = new SqlParameter("@CurrentPIN", SqlDbType.Int);
                    arParms[19].Value = objempt.CurrentPIN;

                    arParms[20] = new SqlParameter("@CurrentLandMark", SqlDbType.VarChar);
                    arParms[20].Value = objempt.CurrentLandMark;

                    arParms[21] = new SqlParameter("@PermAddress", SqlDbType.VarChar);
                    arParms[21].Value = objempt.PermAddress;

                    arParms[22] = new SqlParameter("@PermCountryID", SqlDbType.Int);
                    arParms[22].Value = objempt.PermCountryID;

                    arParms[23] = new SqlParameter("@PermStateID", SqlDbType.Int);
                    arParms[23].Value = objempt.PermStateID;

                    arParms[24] = new SqlParameter("@PermDistrictID", SqlDbType.Int);
                    arParms[24].Value = objempt.PermDistrictID;

                    arParms[25] = new SqlParameter("@PermPIN", SqlDbType.Int);
                    arParms[25].Value = objempt.PermPIN;

                    arParms[26] = new SqlParameter("@PermLandMark", SqlDbType.VarChar);
                    arParms[26].Value = objempt.PermLandMark;

                    arParms[27] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[27].Value = objempt.CompanyID;

                    arParms[28] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[28].Value = objempt.AcademicSessionID;

                    arParms[29] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[29].Value = objempt.AddedBy;

                    arParms[30] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[30].Value = objempt.UserId;

                    arParms[31] = new SqlParameter("@MaritalStatusID", SqlDbType.Int);
                    arParms[31].Value = objempt.MaritalStatusID;

                    arParms[32] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[32].Value = objempt.ActionType;

                    arParms[33] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[33].Direction = ParameterDirection.Output;

                    arParms[34] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[34].Value = objempt.CastID;

                    arParms[35] = new SqlParameter("@Qualification", SqlDbType.VarChar);
                    arParms[35].Value = objempt.Qualification;

                    arParms[36] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[36].Value = objempt.EmployeeNo;

                    arParms[37] = new SqlParameter("@BloodGroupID", SqlDbType.Int);
                    arParms[37].Value = objempt.BloodGroupID;

                    arParms[38] = new SqlParameter("@Experience", SqlDbType.VarChar);
                    arParms[38].Value = objempt.Experience;

                    arParms[39] = new SqlParameter("@IDmarks", SqlDbType.VarChar);
                    arParms[39].Value = objempt.IDmarks;

                    arParms[40] = new SqlParameter("@DigitalSignatureImage", SqlDbType.Image);
                    arParms[40].Value = objempt.DigitalSignatureImage;

                    arParms[41] = new SqlParameter("@DOJ", SqlDbType.DateTime);
                    arParms[41].Value = objempt.DOJ;

                    arParms[42] = new SqlParameter("@EmployeeCatgeroyID", SqlDbType.Int);
                    arParms[42].Value = objempt.EmployeeCatgeroyID;

                    arParms[43] = new SqlParameter("@StaffTypeID", SqlDbType.Int);
                    arParms[43].Value = objempt.StaffTypeID;

                    arParms[44] = new SqlParameter("@Istransfer", SqlDbType.Bit);
                    arParms[44].Value = objempt.Istransfer;

                    arParms[45] = new SqlParameter("@EmployeePhotoImage", SqlDbType.Image);
                    arParms[45].Value = objempt.EmployeePhotoImage;

                    arParms[46] = new SqlParameter("@ProfessionalQualification", SqlDbType.VarChar);
                    arParms[46].Value = objempt.ProfessionalQualification;

                    arParms[47] = new SqlParameter("@University", SqlDbType.VarChar);
                    arParms[47].Value = objempt.University;

                    arParms[48] = new SqlParameter("@EPF", SqlDbType.VarChar);
                    arParms[48].Value = objempt.EPF;

                    arParms[49] = new SqlParameter("@IFSC", SqlDbType.VarChar);
                    arParms[49].Value = objempt.IFSC;

                    arParms[50] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[50].Value = objempt.BankName;

                    arParms[51] = new SqlParameter("@AC", SqlDbType.VarChar);
                    arParms[51].Value = objempt.AC;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_UpdateEmployeeDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[33].Value);
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
        public int UpdateEmployeeAttenedance(EmployeeAttendanceData objEmp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objEmp.XmlEmployeeAttendancelist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateCorrectEmployeeAttendance", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
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
        public int UpLoadEmployeePhoto(EmployeeData objEmp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objEmp.EmployeeID;

                    arParms[1] = new SqlParameter("@EmployeePhotoLocation", SqlDbType.VarChar);
                    arParms[1].Value = objEmp.EmployeePhotoLocation;

                    arParms[2] = new SqlParameter("@EmployeePhotoImage", SqlDbType.Image);
                    arParms[2].Value = objEmp.EmployeePhotoImage;

                    arParms[3] = new SqlParameter("@DigitalSignatureLocation", SqlDbType.VarChar);
                    arParms[3].Value = objEmp.DigitalSignatureLocation;

                    arParms[4] = new SqlParameter("@DigitalSignatureImage", SqlDbType.Image);
                    arParms[4].Value = objEmp.DigitalSignatureImage;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateEmployeePhotos", arParms);
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
        public int UpdateEmployeeLeaveDetails(EmployeeLeaveData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@LeaveID", SqlDbType.Int);
                    arParms[1].Value = objempt.LeaveID;

                    arParms[2] = new SqlParameter("@NosDays", SqlDbType.Int);
                    arParms[2].Value = objempt.NosDays;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objempt.Remarks;

                    arParms[4] = new SqlParameter("@LeaveDocumentpath", SqlDbType.VarChar);
                    arParms[4].Value = objempt.LeaveDocumentpath;

                    arParms[5] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[5].Value = objempt.DateFrom;

                    arParms[6] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[6].Value = objempt.DateTo;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objempt.AcademicSessionID;

                    arParms[8] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[8].Value = objempt.AddedBy;

                    arParms[9] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[9].Value = objempt.UserId;

                    arParms[10] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[10].Value = objempt.ActionType;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    arParms[12] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[12].Value = objempt.IsActive;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_UpdateEmployeeLeaveDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[11].Value);
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
        public int UpdateEmployeeSalaryDetails(EmployeeSalary objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@SalaryID", SqlDbType.Int);
                    arParms[1].Value = objempt.SalaryID;

                    arParms[2] = new SqlParameter("@SalaryAmount", SqlDbType.Money);
                    arParms[2].Value = objempt.SalaryAmount;

                    arParms[3] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                    arParms[3].Value = objempt.IsDeleted;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objempt.AcademicSessionID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objempt.AddedBy;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[6].Value = objempt.UserId;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objempt.ActionType;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    arParms[9] = new SqlParameter("@Increament", SqlDbType.Money);
                    arParms[9].Value = objempt.Increament;

                    arParms[10] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[10].Value = objempt.EmployeeNo;

                    arParms[11] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[11].Value = objempt.EmpName;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_UpdateEmployeeSalaryDetails", arParms);
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
        public List<EmployeeData> SearchEmployeeDetails(EmployeeData objempt)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[1].Value = objempt.EmpName;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objempt.AcademicSessionID;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.VarChar);
                    arParms[3].Value = objempt.SexID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objempt.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objempt.CurrentIndex;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objempt.ActionType;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[7].Value = objempt.IsActiveALL;

                    arParms[8] = new SqlParameter("@EmployeeCatgeroyID", SqlDbType.Int);
                    arParms[8].Value = objempt.EmployeeCatgeroyID;

                    arParms[9] = new SqlParameter("@StaffTypeID", SqlDbType.Int);
                    arParms[9].Value = objempt.StaffTypeID;

                    arParms[10] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[10].Value = objempt.EmployeeNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_SeacrhEmployeeDetailMST", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeData> SearchEmployeePhoto(EmployeeData objempt)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@Status", SqlDbType.Bit);
                    arParms[1].Value = objempt.IsActive;

                    arParms[2] = new SqlParameter("@EmployeeCatgeroyID", SqlDbType.Int);
                    arParms[2].Value = objempt.EmployeeCatgeroyID;

                    arParms[3] = new SqlParameter("@StaffTypeID", SqlDbType.Int);
                    arParms[3].Value = objempt.StaffTypeID;

                    arParms[4] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[4].Value = objempt.EmployeeNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_SeacrhEmployeePhoto", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeLeaveData> SearchEmployeeLeaveDetails(EmployeeLeaveData objempt)
        {
            List<EmployeeLeaveData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[1].Value = objempt.DateFrom;

                    arParms[2] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[2].Value = objempt.DateTo;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objempt.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchEmployeeLeaveDetails", arParms);
                    List<EmployeeLeaveData> lstEmployeeLeaveDetails = ORHelper<EmployeeLeaveData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeLeaveDetails;
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
        public List<EmployeeSalary> GetSalaryDetails(EmployeeSalary objempt)
        {
            List<EmployeeSalary> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                    arParms[1].Value = objempt.IsDeleted;

                    arParms[2] = new SqlParameter("@EmployeeCategory", SqlDbType.Int);
                    arParms[2].Value = objempt.EmployeeCategory;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_GetEmployeeSalaryDetails", arParms);
                    List<EmployeeSalary> lstEmployeeLeaveDetails = ORHelper<EmployeeSalary>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeLeaveDetails;
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
        public List<Logintrackdata> TrackLogin(Logintrackdata objempt)
        {
            List<Logintrackdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[1].Value = objempt.EmpName;

                    arParms[2] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[2].Value = objempt.DateFrom;

                    arParms[3] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[3].Value = objempt.DateTo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_LoginTrack", arParms);
                    List<Logintrackdata> lstEmployeeLeaveDetails = ORHelper<Logintrackdata>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeLeaveDetails;
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
        public List<EmployeeAttendanceData> GetEmployeeRegister(EmployeeAttendanceData objempt)
        {
            List<EmployeeAttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[1].Value = objempt.EmpName;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objempt.AcademicSessionID;

                    arParms[4] = new SqlParameter("@UserLoginID", SqlDbType.Int);
                    arParms[4].Value = objempt.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_CreateEmployeeAttenedanceRegister", arParms);
                    List<EmployeeAttendanceData> lstEmployeeDetails = ORHelper<EmployeeAttendanceData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeSalary> GenerateEmployeesalary(EmployeeSalary objempt)
        {
            List<EmployeeSalary> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[1].Value = objempt.MonthID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objempt.AcademicSessionID;

                    arParms[4] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                    arParms[4].Value = objempt.UserId;

                    arParms[5] = new SqlParameter("@SalaryStatus", SqlDbType.Int);
                    arParms[5].Value = objempt.SalaryStatus;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objempt.AddedBy;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objempt.IsActive;

                    arParms[8] = new SqlParameter("@EmployeeCategory", SqlDbType.Int);
                    arParms[8].Value = objempt.EmployeeCategory;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_SalaryGenerator", arParms);
                    List<EmployeeSalary> lstEmployeeDetails = ORHelper<EmployeeSalary>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeAttendanceData> GetEmpattendance(EmployeeAttendanceData objempt)
        {
            List<EmployeeAttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[1].Value = objempt.EmpName;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objempt.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[4].Value = objempt.Datefrom;

                    arParms[5] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[5].Value = objempt.Dateto;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_GetEmployeeAttendancelist", arParms);
                    List<EmployeeAttendanceData> lstEmployeeDetails = ORHelper<EmployeeAttendanceData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeData> GetEmpnames(EmployeeData objempt)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmpName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_autocompleteEmpnames", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeData> GetEmpNo(EmployeeData objempt)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetEmpNo", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeData> GetEmployeeDetailsByID(EmployeeData objempt)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[1].Value = objempt.EmployeeID;

                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objempt.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_EditEmployeeDetail", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<userdetails> GetEmployeeDetailsLoginDetails(userdetails objempt)
        {
            List<userdetails> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@LoginID", SqlDbType.Int);
                    arParms[0].Value = objempt.UserId;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetEmployeesDetails", arParms);
                    List<userdetails> lstEmployeeDetails = ORHelper<userdetails>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeLeaveData> GetEmployeeLeaveDetailsByID(EmployeeLeaveData objempt)
        {
            List<EmployeeLeaveData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@LeaveID", SqlDbType.Int);
                    arParms[0].Value = objempt.LeaveID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_EditEmployeeLeaveDetailByID", arParms);
                    List<EmployeeLeaveData> lstEmployeeDetails = ORHelper<EmployeeLeaveData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeSalary> GetEmployeeSalaryDetailsByID(EmployeeSalary objempt)
        {
            List<EmployeeSalary> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@SalaryID", SqlDbType.Int);
                    arParms[0].Value = objempt.SalaryID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_EditEmployeeSalaryDetailByID", arParms);
                    List<EmployeeSalary> lstEmployeeDetails = ORHelper<EmployeeSalary>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeSalary> GetEmployeeSalaryDetails(EmployeeSalary objempt)
        {
            List<EmployeeSalary> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmpName;

                    arParms[1] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[1].Value = objempt.EmployeeNo;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objempt.AcademicSessionID;

                    arParms[3] = new SqlParameter("@EmployeeCategory", SqlDbType.Int);
                    arParms[3].Value = objempt.EmployeeCategory;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_SearchEmployeeSalaryDetails", arParms);
                    List<EmployeeSalary> lstEmployeeDetails = ORHelper<EmployeeSalary>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public int DeleteEmployeeDetailsByID(EmployeeData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objempt.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objempt.Remarks;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[4].Value = objempt.UserId;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objempt.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_DeleteEmployeeDetailByID", arParms);
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
        public int DeleteEmployeeLeaveDetailsByID(EmployeeLeaveData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@LeaveID", SqlDbType.Int);
                    arParms[0].Value = objempt.LeaveID;
                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_DeleteEmployeeLeaveDetailByID", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
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
        public int UpdateLogin(EmployeeAttendanceData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;
                    arParms[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                    arParms[1].Value = objempt.UserPassword;
                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objempt.ActionType;
                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objempt.Remarks;
                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Edu_EmployeeAttendnaceDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
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
        public int UpdateEmployeeSalary(EmployeeSalary objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.EmployeeNo;

                    arParms[1] = new SqlParameter("@SalaryGeneratorID", SqlDbType.Int);
                    arParms[1].Value = objempt.SalaryGeneratorID;

                    arParms[2] = new SqlParameter("@Bonus", SqlDbType.Decimal);
                    arParms[2].Value = objempt.Bonus;

                    arParms[3] = new SqlParameter("@Incentives", SqlDbType.Decimal);
                    arParms[3].Value = objempt.Incentives;

                    arParms[4] = new SqlParameter("@Allowance", SqlDbType.Decimal);
                    arParms[4].Value = objempt.Allowance ;

                    arParms[5] = new SqlParameter("@Surplus", SqlDbType.Decimal);
                    arParms[5].Value = objempt.Surplus;

                    arParms[6] = new SqlParameter("@Proxy", SqlDbType.Decimal);
                    arParms[6].Value = objempt.Proxy;

                    arParms[7] = new SqlParameter("@Subduction", SqlDbType.Decimal);
                    arParms[7].Value = objempt.Subduction;

                    arParms[8] = new SqlParameter("@SalaryAmount", SqlDbType.Decimal);
                    arParms[8].Value = objempt.SalaryAmount;

                    arParms[9] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[9].Value = objempt.UserId;

                    arParms[10] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[10].Value = objempt.AddedBy;

                    arParms[11] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[11].Value = objempt.AcademicSessionID;

                    arParms[12] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[12].Value = objempt.MonthID;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateEmployeeMonthlySalary", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[13].Value);
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
        public int DeletSalaryDetailsByID(EmployeeSalary objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                
                    arParms[0] = new SqlParameter("@SalaryGeneratorID", SqlDbType.Int);
                    arParms[0].Value = objempt.SalaryGeneratorID;

                    arParms[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[1].Value = objempt.UserId;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objempt.AddedBy;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteEmployeeMonthlySalary", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[3].Value);
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
        public int UpdateLogout(EmployeeAttendanceData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objempt.EmployeeID;
                    arParms[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                    arParms[1].Value = objempt.UserPassword;
                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objempt.ActionType;
                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objempt.Remarks;
                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Edu_EmployeeAttendnaceDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
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
        public int UpdateLeaveStatus(EmployeeLeaveData objempt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@LeaveID", SqlDbType.Int);
                    arParms[0].Value = objempt.LeaveID;
                    arParms[1] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[1].Value = objempt.DateFrom;
                    arParms[2] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[2].Value = objempt.DateTo;
                    arParms[3] = new SqlParameter("@ApprovedDays", SqlDbType.Int);
                    arParms[3].Value = objempt.ApprovedDays;
                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;
                    arParms[5] = new SqlParameter("@AprroveBy", SqlDbType.VarChar);
                    arParms[5].Value = objempt.AprroveBy;
                    arParms[6] = new SqlParameter("@LeaveStatus", SqlDbType.Int);
                    arParms[6].Value = objempt.LeaveStatus;
                    arParms[7] = new SqlParameter("@RejRemarks", SqlDbType.VarChar);
                    arParms[7].Value = objempt.RejRemarks;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Edu_UpdateEmployeeLeaveStatus", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
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
        /////////Employee list exporting/////////////////////
        public List<EmployeeData> GetEmployeeListoexcel(EmployeeData objEmp)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@EmployeeNo", SqlDbType.Int);
                    arParms[0].Value = objEmp.EmployeeNo;

                    arParms[1] = new SqlParameter("@Employeename", SqlDbType.VarChar);
                    arParms[1].Value = objEmp.EmpName;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objEmp.AcademicSessionID;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[3].Value = objEmp.SexID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objEmp.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objEmp.CurrentIndex;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objEmp.ActionType;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[7].Value = objEmp.IsActiveALL;

                    arParms[8] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[8].Value = objEmp.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetEmpListtoexcel", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<EmployeeData> GetEmployeePasswordList(EmployeeData objEmp)
        {
            List<EmployeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[0].Value = objEmp.AddedBy;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objEmp.AcademicSessionID;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objEmp.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objEmp.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_GetTeacherPasswordList", arParms);
                    List<EmployeeData> lstEmployeeDetails = ORHelper<EmployeeData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public int UpdateEmployeePassword(EmployeeData objEmp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objEmp.XmlEmployeeList;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_UpdateEmployeePassword", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
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
