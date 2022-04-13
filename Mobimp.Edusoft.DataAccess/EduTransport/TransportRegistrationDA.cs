using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Data.SqlClient;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.DataAccess.EduTransport
{
    public class TransportRegistrationDA
    {
        public int UpdateTransportRegistration(TransportData objreg)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[18];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objreg.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objreg.ClassID;

                    arParms[3] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[3].Value = objreg.StreamID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objreg.SectionID;

                    arParms[5] = new SqlParameter("@TransportRegistrationNo", SqlDbType.BigInt);
                    arParms[5].Value = objreg.TransportRegistrationNo;

                    arParms[6] = new SqlParameter("@TransportStudentTypeID", SqlDbType.Int);
                    arParms[6].Value = objreg.TransportStudentTypeID;

                    arParms[7] = new SqlParameter("@RootID", SqlDbType.Int);
                    arParms[7].Value = objreg.RootID;

                    arParms[8] = new SqlParameter("@DestinationID", SqlDbType.Int);
                    arParms[8].Value = objreg.DestinationID;

                    arParms[9] = new SqlParameter("@Monthlist", SqlDbType.VarChar);
                    arParms[9].Value = objreg.Monthlist;

                    arParms[10] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                    arParms[10].Value = objreg.StartDate;

                    arParms[11] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[11].Value = objreg.CompanyID;

                    arParms[12] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[12].Value = objreg.ActionType;

                    arParms[13] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[13].Value = objreg.AcademicSessionID;

                    arParms[14] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[14].Value = objreg.AddedBy;

                    arParms[15] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[15].Value = objreg.IsActive;

                    arParms[16] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[16].Value = objreg.UserId;

                    arParms[17] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[17].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateTransportRegistration", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[17].Value);
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
        public List<TransportData> SearchTransportRegistration(TransportData objreg)
        {
            List<TransportData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.StudentID;

                    arParms[1] = new SqlParameter("@RootID", SqlDbType.BigInt);
                    arParms[1].Value = objreg.RootID;

                    arParms[2] = new SqlParameter("@DestinationID", SqlDbType.Int);
                    arParms[2].Value = objreg.DestinationID;

                    arParms[3] = new SqlParameter("@VihicleID", SqlDbType.Int);
                    arParms[3].Value = objreg.VihicleID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objreg.AcademicSessionID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objreg.IsActive;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objreg.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objreg.PageSize;

                    arParms[8] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[8].Value = objreg.ClassID;

                    arParms[9] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[9].Value = objreg.SectionID;

                    arParms[10] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[10].Value = objreg.Datefrom;

                    arParms[11] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[11].Value = objreg.Dateto;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SearchTransportRegistration", arParms);
                    List<TransportData> lstTransportRegistration = ORHelper<TransportData>.FromDataReaderToList(sqlReader);
                    result = lstTransportRegistration;
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
        public List<TransportData> SearchMonthlyTransportFee(TransportData objmntly)
        {
            List<TransportData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@SectionID", SqlDbType.BigInt);
                    arParms[0].Value = objmntly.SectionID;

                    arParms[1] = new SqlParameter("@TransportStudentTypeID", SqlDbType.Int);
                    arParms[1].Value = objmntly.TransportStudentTypeID;

                    arParms[2] = new SqlParameter("@RootID", SqlDbType.BigInt);
                    arParms[2].Value = objmntly.RootID;

                    arParms[3] = new SqlParameter("@SubRootID", SqlDbType.Int);
                    arParms[3].Value = objmntly.SubRootID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objmntly.AcademicSessionID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objmntly.IsActive;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objmntly.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objmntly.PageSize;

                    arParms[8] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[8].Value = objmntly.ClassID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SearchMonthlyTransportFee", arParms);
                    List<TransportData> lstTransportRegistration = ORHelper<TransportData>.FromDataReaderToList(sqlReader);
                    result = lstTransportRegistration;
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
        public List<TransportData> GetTransportRegistrationByID(TransportData objreg)
        {
            List<TransportData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EditTransportRegistration", arParms);
                    List<TransportData> lstTransportRegistration = ORHelper<TransportData>.FromDataReaderToList(sqlReader);
                    result = lstTransportRegistration;
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
        public int DeleteTransportRegistrationByID(TransportData objreg)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;

                    arParms[1] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[1].Value = objreg.Remarks;

                    arParms[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[2].Value = objreg.UserId;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;
     
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteTransportRegistration", arParms);
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
        ////////////////
        public List<StudentData> GetTransportstudentDetailByID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetTransportstudentDetailByid", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public int SaveActivationDate(TransportData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@ActivateDate", SqlDbType.DateTime);
                    arParms[3].Value = objstd.ActivateDate;

                    arParms[4] = new SqlParameter("@Activate", SqlDbType.Int);
                    arParms[4].Value = objstd.Activate;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Transport_InsertActivationDate", arParms);
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
        public int UpdateMonthlyTransportFee(TransportData ObjData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = ObjData.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = ObjData.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[3].Value = ObjData.EmployeeID;

                    arParms[4] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[4].Value = ObjData.XMLData;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Transport_UpdateMonthlyTransportFee", arParms);
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
        public List<TransportData> SearchTransportMonthlyFeeSetting(TransportData objdata)
        {
            List<TransportData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objdata.AcademicSessionID;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SearchTransportMonthlyFeeSetting", arParms);
                    List<TransportData> lstTransportMonthlyFeeSetting = ORHelper<TransportData>.FromDataReaderToList(sqlReader);
                    result = lstTransportMonthlyFeeSetting;
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
        public int UpdateTransportMonthlyFeeSetting(TransportData ObjData)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = ObjData.XMLData;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = ObjData.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[3].Value = ObjData.EmployeeID;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Transport_UpdateTransporMonthlyFeeSetting", arParms);
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
        public List<TransportData> SearchTransportStudentDetails(TransportData objtran)
        {
            List<TransportData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objtran.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objtran.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchTransportStudentProfile", arParms);
                    List<TransportData> lstTranStudentDetails = ORHelper<TransportData>.FromDataReaderToList(sqlReader);
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
