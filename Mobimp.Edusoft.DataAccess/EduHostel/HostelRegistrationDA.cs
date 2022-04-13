using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.DataAccess.EduHostel
{
    public class HostelRegistrationDA
    {
        //public List<StudentData> GetHostelstudentDetailByID(StudentData objstd)
        //{
        //    List<StudentData> result = null;
        //    try
        //    {
        //        {
        //            SqlParameter[] arParms = new SqlParameter[2];

        //            arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
        //            arParms[0].Value = objstd.StudentID;

        //            arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
        //            arParms[1].Value = objstd.AcademicSessionID;

        //            SqlDataReader sqlReader = null;
        //            sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetBroaderstudentDetailByid", arParms);
        //            List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
        //            result = lstStudentDetails;
        //        }
        //    }
        //    catch (Exception ex) //Exception of the business layer(itself)//unhandle
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new DataAccessException("5000001", ex);
        //    }
        //    return result;
        //}
        public List<HostelRegistrationData> GetHostelstudentDetailByID(HostelRegistrationData objstd)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_GetBroaderstudentDetailByid", arParms);
                    List<HostelRegistrationData> lstStudentDetails = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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
        public List<HostelRegistrationData> GetStudentID(HostelRegistrationData objempt)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.AdmissionNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_autocompleteStdID", arParms);
                    List<HostelRegistrationData> lstEmployeeDetails = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
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
        public List<HostelRegistrationData> GetstudentDetailByID(HostelRegistrationData objstd)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_GetStudentDetailByid", arParms);
                    List<HostelRegistrationData> lstStudentDetails = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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

        public int UpdateHostelRegistration(HostelRegistrationData objreg)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[19];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objreg.StudentID;

                    arParms[2] = new SqlParameter("@RegistrationNo", SqlDbType.BigInt);
                    arParms[2].Value = objreg.RegistrationNo;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objreg.ClassID;

                    arParms[4] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[4].Value = objreg.StreamID;

                    arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[5].Value = objreg.SectionID;

                    arParms[6] = new SqlParameter("@BlockID", SqlDbType.Int);
                    arParms[6].Value = objreg.BlockID;

                    arParms[7] = new SqlParameter("@WardenID", SqlDbType.BigInt);
                    arParms[7].Value = objreg.WardenID;

                    arParms[8] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[8].Value = objreg.UserId;

                    arParms[9] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[9].Value = objreg.CompanyID;

                    arParms[10] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[10].Value = objreg.ActionType;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objreg.AcademicSessionID;

                    arParms[13] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[13].Value = objreg.AddedBy;

                    arParms[14] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[14].Value = objreg.IsActive;

                    arParms[15] = new SqlParameter("@DryID", SqlDbType.Int);
                    arParms[15].Value = objreg.DryID;

                    arParms[16] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[16].Value = objreg.MonthID;

                    arParms[17] = new SqlParameter("@EntranceDate", SqlDbType.DateTime);
                    arParms[17].Value = objreg.EntranceDate;

                    arParms[18] = new SqlParameter("@HstudentTypeID", SqlDbType.Int);
                    arParms[18].Value = objreg.HstudentTypeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_UpdateHostelRegistration", arParms);
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
        public List<HostelRegistrationData> SearchHostelRegistration(HostelRegistrationData objreg)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.StudentID;

                    arParms[1] = new SqlParameter("@RegistrationNo", SqlDbType.BigInt);
                    arParms[1].Value = objreg.RegistrationNo;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objreg.AcademicSessionID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objreg.IsActive;

                    arParms[4] = new SqlParameter("@WardenID", SqlDbType.BigInt);
                    arParms[4].Value = objreg.WardenID;

                    arParms[5] = new SqlParameter("@BlockID", SqlDbType.Int);
                    arParms[5].Value = objreg.BlockID;

                    arParms[6] = new SqlParameter("@DepositStatus", SqlDbType.Int);
                    arParms[6].Value = objreg.DepositStatus;

                    arParms[7] = new SqlParameter("@DryID", SqlDbType.Int);
                    arParms[7].Value = objreg.DryID;

                    arParms[8] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[8].Value = objreg.MonthID;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objreg.CurrentIndex;

                    arParms[10] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[10].Value = objreg.PageSize;

                    arParms[11] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[11].Value = objreg.Sfirstname;

                    arParms[12] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[12].Value = objreg.ClassID;

                    arParms[13] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[13].Value = objreg.SectionID;

                    arParms[14] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[14].Value = objreg.Datefrom;

                    arParms[15] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[15].Value = objreg.Dateto;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_SearchHostelRegistration", arParms);
                    List<HostelRegistrationData> lstHostelRegistration = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
                    result = lstHostelRegistration;
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
        public List<HostelRegistrationData> GetHostelRegistrationByID(HostelRegistrationData objreg)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.IDS;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_EditHostelRegistration", arParms);
                    List<HostelRegistrationData> lstHostelRegistration = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
                    result = lstHostelRegistration;
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
        public int DeleteHostelRegistrationByID(HostelRegistrationData objreg)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;

                    arParms[1] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[1].Value = objreg.Remarks;

                    arParms[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[2].Value = objreg.UserId;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@RemarkID", SqlDbType.Int);
                    arParms[4].Value = objreg.RemarkID;

                    arParms[5] = new SqlParameter("@WithdrawlDate", SqlDbType.DateTime);
                    arParms[5].Value = objreg.WithdrawlDate;

                    arParms[6] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[6].Value = objreg.StudentID;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objreg.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_DeleteHostelRegistration", arParms);
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
        
        public List<HostelRegistrationData> SearchHostelStudentDetails(HostelRegistrationData objtran)
        {
            List<HostelRegistrationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objtran.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objtran.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchHostelStudentProfile", arParms);
                    List<HostelRegistrationData> lstTranStudentDetails = ORHelper<HostelRegistrationData>.FromDataReaderToList(sqlReader);
                    result = lstTranStudentDetails;
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
