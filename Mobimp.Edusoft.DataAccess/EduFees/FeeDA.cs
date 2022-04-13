using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduFees;
using System.Data;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduFees
{
    public class FeeDA
    {        
        public List<FeeData> GetAutoStudentDetails(FeeData objitemName)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentDetail", SqlDbType.VarChar);
                    arParms[0].Value = objitemName.StudentDetail;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.VarChar);
                    arParms[1].Value = objitemName.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_autocompleteStudentDetails", arParms);
                    List<FeeData> lstStudentDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
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
        public List<FeeData> GetAutoStudentName(FeeData objitemName)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentDetail", SqlDbType.VarChar);
                    arParms[0].Value = objitemName.StudentDetail;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.VarChar);
                    arParms[1].Value = objitemName.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_autocompleteStudentName", arParms);
                    List<FeeData> lstStudentDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
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
        public List<FeeData> GetStudentDetailByID(FeeData objitem)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objitem.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objitem.StudentID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_GetStudentDetailByid", arParms);
                    List<FeeData> lstStudentDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
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
        public List<FeeData> SearchDueFeeDetailsList(FeeData objDuelist)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objDuelist.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objDuelist.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objDuelist.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objDuelist.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objDuelist.RollNo;

                    arParms[5] = new SqlParameter("@FeetypeID", SqlDbType.Int);
                    arParms[5].Value = objDuelist.FeetypeID;

                    arParms[6] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[6].Value = objDuelist.Rootno;

                    arParms[7] = new SqlParameter("@VehicleID", SqlDbType.Int);
                    arParms[7].Value = objDuelist.VehicleID;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objDuelist.PageSize;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objDuelist.CurrentIndex;

                    arParms[10] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[10].Value = objDuelist.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchDueFeeDetailsList", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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
        public List<FeeData> GetStudentID(FeeData objempt)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.AdmissionNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_autocompleteStdID", arParms);
                    List<FeeData> lstEmployeeDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
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


        //Student Fee Status
        public List<FeeData> SearchStudentFeeStatusList(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objFee.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objFee.RollNo;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objFee.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objFee.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objFee.IsActive;

                    arParms[8] = new SqlParameter("@FeeStatus", SqlDbType.Int);
                    arParms[8].Value = objFee.FeeStatus;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchStudentFeeStatusList", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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

        //Student Fee Status Details
        public List<FeeData> SearchFeeStatusDetails(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objFee.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objFee.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchStudentFeeStatusDetails", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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

        //Fee  Payment
        public List<FeeData> SearchFeePaymentDetails(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@FeetypeID", SqlDbType.Int);
                    arParms[3].Value = objFee.FeetypeID;

                    arParms[4] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[4].Value = objFee.PaymentTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchFeePaymentDetails", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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
        public int UpdateStudentPaymentDetails(FeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objfees.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objfees.ClassID;

                    arParms[3] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.StudentTypeID;

                    arParms[4] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[4].Value = objfees.PaymentModeID;

                    arParms[5] = new SqlParameter("@PaymentTypeID", SqlDbType.Int);
                    arParms[5].Value = objfees.PaymentTypeID;

                    arParms[6] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[6].Value = objfees.FeeTypeID;

                    arParms[7] = new SqlParameter("@TotalNetAmount", SqlDbType.Money);
                    arParms[7].Value = objfees.TotalNetAmount;

                    arParms[8] = new SqlParameter("@Discount", SqlDbType.Money);
                    arParms[8].Value = objfees.Discount;

                    arParms[9] = new SqlParameter("@Paid", SqlDbType.Money);
                    arParms[9].Value = objfees.Paid;

                    arParms[10] = new SqlParameter("@Due", SqlDbType.Money);
                    arParms[10].Value = objfees.Due;

                    arParms[11] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[11].Value = objfees.Remarks;

                    arParms[12] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[12].Value = objfees.AddedBy;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    arParms[14] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[14].Value = objfees.xmlstudentpaymentlist;

                    arParms[15] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[15].Value = objfees.UserId;

                    arParms[16] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[16].Value = objfees.CompanyID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateStudentPaymentdetails", arParms);
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
        // Fee Payment List
        public List<FeeData> SearchFeePaymentlist(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objFee.SectionID;

                    arParms[4] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[4].Value = objFee.StudentTypeID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objFee.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objFee.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objFee.IsActive;

                    arParms[8] = new SqlParameter("@FeeStatus", SqlDbType.Int);
                    arParms[8].Value = objFee.FeeStatus;

                    arParms[9] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[9].Value = objFee.FeeTypeID;

                    arParms[10] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[10].Value = objFee.Datefrom;

                    arParms[11] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[11].Value = objFee.Dateto;

                    arParms[12] = new SqlParameter("@UserID", SqlDbType.Int);
                    arParms[12].Value = objFee.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchFeePaymentList", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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
        public List<FeeData> SearchChildDetailByNo(FeeData objitemData)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.BigInt);
                    arParms[0].Value = objitemData.BillNo;
                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objitemData.StudentID;
                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objitemData.FeeTypeID;
                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objitemData.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_SubDetailByBillNo", arParms);
                    List<FeeData> lstChildDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstChildDetails;
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
        public int DeleteSchoolFeesByID(FeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.Int);
                    arParms[0].Value = objfees.BillNo;
                    arParms[1] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[1].Value = objfees.Remarks;
                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objfees.FeeTypeID;
                    arParms[3] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[3].Value = objfees.StudentID;
                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objfees.AcademicSessionID;
                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;
                    arParms[6] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[6].Value = objfees.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteStudentFeeByBillNo", arParms);
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


        //Due List
        public List<FeeData> SearchFeeDuelist(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objFee.SectionID;

                    arParms[4] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[4].Value = objFee.StudentTypeID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objFee.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objFee.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objFee.IsActive;

                    arParms[8] = new SqlParameter("@FeeStatus", SqlDbType.Int);
                    arParms[8].Value = objFee.FeeStatus;

                    arParms[9] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[9].Value = objFee.FeeTypeID;

                    arParms[10] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[10].Value = objFee.Datefrom;

                    arParms[11] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[11].Value = objFee.Dateto;

                    arParms[12] = new SqlParameter("@UserID", SqlDbType.Int);
                    arParms[12].Value = objFee.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchDueList", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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
        public int UpdateStudentDuePaymentDetails(FeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[1].Value = objfees.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objfees.ClassID;

                    arParms[3] = new SqlParameter("@PaymentModeID", SqlDbType.Int);
                    arParms[3].Value = objfees.PaymentModeID;

                    arParms[4] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[4].Value = objfees.FeeTypeID;

                    arParms[5] = new SqlParameter("@TotalNetAmount", SqlDbType.Money);
                    arParms[5].Value = objfees.TotalNetAmount;

                    arParms[6] = new SqlParameter("@TotalDiscount", SqlDbType.Money);
                    arParms[6].Value = objfees.TotalDiscount;

                    arParms[7] = new SqlParameter("@TotalPaidAmount", SqlDbType.Money);
                    arParms[7].Value = objfees.TotalPaidAmount;

                    arParms[8] = new SqlParameter("@TotalDue", SqlDbType.Money);
                    arParms[8].Value = objfees.TotalDue;

                    arParms[9] = new SqlParameter("@TotalPaid", SqlDbType.Money);
                    arParms[9].Value = objfees.TotalPaid;

                    arParms[10] = new SqlParameter("@DueAmount", SqlDbType.Money);
                    arParms[10].Value = objfees.DueAmount;

                    arParms[11] = new SqlParameter("@SettleWithDiscount", SqlDbType.Int);
                    arParms[11].Value = objfees.SettleWithDiscount;

                    arParms[12] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[12].Value = objfees.AddedBy;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    arParms[14] = new SqlParameter("@BillNo", SqlDbType.Int);
                    arParms[14].Value = objfees.BillNo;

                    arParms[15] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[15].Value = objfees.UserId;

                    arParms[16] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[16].Value = objfees.CompanyID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateStudentDuePaymentdetails", arParms);
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
        public List<FeeData> SearchFeeDuePaymentlist(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objFee.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objFee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objFee.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objFee.SectionID;

                    arParms[4] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[4].Value = objFee.StudentTypeID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objFee.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objFee.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objFee.IsActive;

                    arParms[8] = new SqlParameter("@FeeStatus", SqlDbType.Int);
                    arParms[8].Value = objFee.FeeStatus;

                    arParms[9] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[9].Value = objFee.FeeTypeID;

                    arParms[10] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[10].Value = objFee.Datefrom;

                    arParms[11] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[11].Value = objFee.Dateto;

                    arParms[12] = new SqlParameter("@UserID", SqlDbType.Int);
                    arParms[12].Value = objFee.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_SearchDuePyamentList", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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

        //Yearly Income
        public List<FeeData> SearchYearlyWiseIncome(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objFee.xmlacademicsessionlist;

                    arParms[1] = new SqlParameter("@XMLData2", SqlDbType.Xml);
                    arParms[1].Value = objFee.xmlfeetypelist;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_YearlyIncomeRPT", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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

        //Monthly Income
        public List<FeeData> SearchMonthlyWiseIncome(FeeData objFee)
        {
            List<FeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objFee.AcademicSessionID;

                    arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[1].Value = objFee.xmlfeetypelist;

                    arParms[2] = new SqlParameter("@XMLData2", SqlDbType.Xml);
                    arParms[2].Value = objFee.xmlmonthlist;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_MonthlyIncomeRPT", arParms);
                    List<FeeData> lstDueDetails = ORHelper<FeeData>.FromDataReaderToList(sqlReader);
                    result = lstDueDetails;
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
