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
    public class FeeCollectionDA
    {
        //////////////////////////SCHOOLFEESCOLLECTION////////////////////////////
        public List<FeeCollectionData> GetClasswiseFeesDetail(FeeCollectionData objitem)
        {
            List<FeeCollectionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objitem.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objitem.StudentID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objitem.FeeTypeID;

                    arParms[3] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[3].Value = objitem.StudentTypeID;

                    arParms[4] = new SqlParameter("@AdmissionType", SqlDbType.Int);
                    arParms[4].Value = objitem.AdmissionType;

                    arParms[5] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[5].Value = objitem.ClassID;

                    arParms[6] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[6].Value = objitem.RollNo;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_GetClasswiseFeeDetail", arParms);
                    List<FeeCollectionData> lstStudentDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
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
        public List<FeepaymentData> Getfeepaymentdetails_newregister_student(FeepaymentData objDA)
        {
            List<FeepaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objDA.StudentID;

                    arParms[1] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[1].Value = objDA.FeeTypeID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objDA.AcademicSessionID;

                    arParms[3] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[3].Value = objDA.StudentTypeID;

                    arParms[4] = new SqlParameter("@OptionalsubjectID", SqlDbType.Int);
                    arParms[4].Value = objDA.OptionalsubjectID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_Get_New_registered_Student_Paymentdetails", arParms);
                    List<FeepaymentData> listdetails = ORHelper<FeepaymentData>.FromDataReaderToList(sqlReader);
                    result = listdetails;
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
        public List<FeepaymentData> Payfee_newstudents(FeepaymentData objDA)
        {
            List<FeepaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objDA.XMLData;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objDA.StudentID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objDA.FeeTypeID;

                    arParms[3] = new SqlParameter("@TotalAmount", SqlDbType.Money);
                    arParms[3].Value = objDA.TotalAmount;

                    arParms[4] = new SqlParameter("@TotalFineAmount", SqlDbType.Money);
                    arParms[4].Value = objDA.FineAmount;

                    arParms[5] = new SqlParameter("@TotalDiscountAmount", SqlDbType.Money);
                    arParms[5].Value = objDA.ExemptionAmount;

                    arParms[6] = new SqlParameter("@TotalPaidAmount", SqlDbType.Money);
                    arParms[6].Value = objDA.TotalPaidAmount;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objDA.AcademicSessionID;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objDA.CompanyID;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    arParms[10] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[10].Value = objDA.PaymentType;

                    arParms[11] = new SqlParameter("@Addedby", SqlDbType.Int);
                    arParms[11].Value = objDA.EmployeeID;

                    arParms[12] = new SqlParameter("@Paymentreceipt", SqlDbType.Image);
                    arParms[12].Value = objDA.Paymentreceipt;

                    arParms[13] = new SqlParameter("@Billdate", SqlDbType.DateTime);
                    arParms[13].Value = objDA.Billdate;

                    arParms[14] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[14].Value = objDA.StudentTypeID;

                    arParms[15] = new SqlParameter("@OptionalsubjectID", SqlDbType.Int);
                    arParms[15].Value = objDA.OptionalsubjectID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_Make_Payment_New_registerd_Students", arParms);
                    List<FeepaymentData> listdetails = ORHelper<FeepaymentData>.FromDataReaderToList(sqlReader);
                    result = listdetails;

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
        public List<FeeCollectionData> GetClasswiseDueFeesDetail(FeeCollectionData objitem)
        {
            List<FeeCollectionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objitem.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objitem.StudentID;

                    arParms[2] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[2].Value = objitem.StudentTypeID;

                    arParms[3] = new SqlParameter("@AdmissionType", SqlDbType.Int);
                    arParms[3].Value = objitem.AdmissionType;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objitem.ClassID;

                    arParms[5] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[5].Value = objitem.RollNo;

                    arParms[6] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[6].Value = objitem.FeeTypeID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_GetClasswiseDueFeeDetail", arParms);
                    List<FeeCollectionData> lstStudentDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
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
        public int UpdateStudentFeeDetails(FeeCollectionData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[35];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@AdmissionID", SqlDbType.Int);
                    arParms[2].Value = objfees.AdmissionID;

                    arParms[3] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[3].Value = objfees.StudentID;

                    arParms[4] = new SqlParameter("@StudentTypeID", SqlDbType.VarChar);
                    arParms[4].Value = objfees.StudentTypeID;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objfees.StudentCategoryID;

                    arParms[6] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[6].Value = objfees.AdmissioNo;

                    arParms[7] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[7].Value = objfees.ClassID;

                    arParms[8] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[8].Value = objfees.RollNo;

                    arParms[9] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[9].Value = objfees.PayModeID;

                    arParms[10] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[10].Value = objfees.PaymentType;

                    arParms[11] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[11].Value = objfees.FeeTypeID;

                    arParms[12] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[12].Value = objfees.BankName;

                    arParms[13] = new SqlParameter("@ChalanNo", SqlDbType.VarChar);
                    arParms[13].Value = objfees.ChalanNo;

                    arParms[14] = new SqlParameter("@FeeAmount", SqlDbType.Money);
                    arParms[14].Value = objfees.FeeAmount;

                    arParms[15] = new SqlParameter("@ExemptedAmount", SqlDbType.Money);
                    arParms[15].Value = objfees.ExemptedAmount;

                    arParms[16] = new SqlParameter("@FineAmount", SqlDbType.Money);
                    arParms[16].Value = objfees.FineAmount;

                    arParms[17] = new SqlParameter("@TotalFeeAmount", SqlDbType.Money);
                    arParms[17].Value = objfees.TotalAmount;

                    arParms[18] = new SqlParameter("@TotalSumFeeAmount", SqlDbType.Money);
                    arParms[18].Value = objfees.TotalSumFeeAmount;

                    arParms[19] = new SqlParameter("@GrandTotalFeeAmount", SqlDbType.Decimal);
                    arParms[19].Value = objfees.GrandTotalFeeAmount;

                    arParms[20] = new SqlParameter("@TotalexemptAmount", SqlDbType.Decimal);
                    arParms[20].Value = objfees.TotalexemptAmount;

                    arParms[21] = new SqlParameter("@TotalFineAmount", SqlDbType.Int);
                    arParms[21].Value = objfees.TotalFineAmount;

                    arParms[22] = new SqlParameter("@TotalNetAmount", SqlDbType.Int);
                    arParms[22].Value = objfees.TotalNetAmount;

                    arParms[23] = new SqlParameter("@TotalDiscountAmount", SqlDbType.Int);
                    arParms[23].Value = objfees.TotalDiscountAmount;

                    arParms[24] = new SqlParameter("@TotalPayableAmount", SqlDbType.Int);
                    arParms[24].Value = objfees.TotalPayableAmount;

                    arParms[25] = new SqlParameter("@PaidAmount", SqlDbType.Int);
                    arParms[25].Value = objfees.PaidAmount;

                    arParms[26] = new SqlParameter("@TotalDueAmount", SqlDbType.Int);
                    arParms[26].Value = objfees.TotalDueAmount;

                    arParms[27] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[27].Value = objfees.Remarks;

                    arParms[28] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[28].Value = objfees.UserId;

                    arParms[29] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[29].Value = objfees.CompanyID;

                    arParms[30] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[30].Value = objfees.AddedBy;

                    arParms[31] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[31].Value = objfees.ActionTypes;

                    arParms[32] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[32].Value = objfees.IsActive;

                    arParms[33] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[33].Value = objfees.xmlmonthlyfeepaidstatuslist;

                    arParms[34] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[34].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateStudentfeedetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[34].Value);
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
        public int UpdateStudentDueFeeDetails(FeeCollectionData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[24];


                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@AdmissionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AdmissionID;

                    arParms[2] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[2].Value = objfees.StudentID;

                    arParms[3] = new SqlParameter("@StudentTypeID", SqlDbType.VarChar);
                    arParms[3].Value = objfees.StudentTypeID;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objfees.ClassID;

                    arParms[5] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[5].Value = objfees.PayModeID;

                    arParms[6] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[6].Value = objfees.PaymentType;

                    arParms[7] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[7].Value = objfees.BankName;

                    arParms[8] = new SqlParameter("@ChalanNo", SqlDbType.VarChar);
                    arParms[8].Value = objfees.ChalanNo;

                    arParms[9] = new SqlParameter("@TotalSumDueFeeAmount", SqlDbType.Money);
                    arParms[9].Value = objfees.TotalSumDueFeeAmount;

                    arParms[10] = new SqlParameter("@GrandTotalDueFeeAmount", SqlDbType.Decimal);
                    arParms[10].Value = objfees.GrandTotalDueFeeAmount;

                    arParms[11] = new SqlParameter("@TotalDueDiscountAmount", SqlDbType.Int);
                    arParms[11].Value = objfees.TotalDueDiscountAmount;

                    arParms[12] = new SqlParameter("@TotalDuePayableAmount", SqlDbType.Int);
                    arParms[12].Value = objfees.TotalDuePayableAmount;

                    arParms[13] = new SqlParameter("@DuePaidAmount", SqlDbType.Int);
                    arParms[13].Value = objfees.DuePaidAmount;

                    arParms[14] = new SqlParameter("@TotalDueAmount", SqlDbType.Int);
                    arParms[14].Value = objfees.TotalDueAmount;

                    arParms[15] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[15].Value = objfees.Remarks;

                    arParms[16] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[16].Value = objfees.UserId;

                    arParms[17] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[17].Value = objfees.CompanyID;

                    arParms[18] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[18].Value = objfees.AddedBy;

                    arParms[19] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[19].Value = objfees.ActionTypes;

                    arParms[20] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[20].Value = objfees.IsActive;

                    arParms[22] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[22].Value = objfees.xmlmonthlyduefeepaidstatuslist;

                    arParms[23] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[23].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateStudentDuefeedetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[23].Value);
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
        public List<FeeCollectionData> SearchSchoolFeeDetailsList(FeeCollectionData objfees)
        {
            List<FeeCollectionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[22];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objfees.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objfees.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objfees.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objfees.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objfees.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objfees.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objfees.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objfees.ActionTypes;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objfees.IsActive;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objfees.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objfees.SectionID;

                    arParms[12] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[12].Value = objfees.StreamID;

                    arParms[13] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[13].Value = objfees.FeeTypeID;

                    arParms[14] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[14].Value = objfees.Datefrom;

                    arParms[15] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[15].Value = objfees.Dateto;

                    arParms[16] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[16].Value = objfees.PayModeID;

                    arParms[17] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[17].Value = objfees.PaymentType;

                    arParms[18] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[18].Value = objfees.StudentCategoryID;

                    arParms[19] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[19].Value = objfees.UserId;

                    arParms[20] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[20].Value = objfees.RouteID;

                    arParms[21] = new SqlParameter("@VihicleID", SqlDbType.Int);
                    arParms[21].Value = objfees.VihicleID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchSchoolFeeDetailsList", arParms);
                    List<FeeCollectionData> lstFeeDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
                    result = lstFeeDetails;
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
        public List<FeeCollectionData> SearchChildDetailByNo(FeeCollectionData objitemData)
        {
            List<FeeCollectionData> result = null;
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
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fees_ChildDetailByBillNo", arParms);
                    List<FeeCollectionData> lstChildDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
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
        public int DeleteSchoolFeesByID(FeeCollectionData objfees)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteSchoolFeeDetails", arParms);
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
        //////////////////////////tap5//////////////////////////////
        public List<FeeCollectionData> SearchDuecollectionListtap5(FeeCollectionData objfees)
        {
            List<FeeCollectionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[20];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objfees.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objfees.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objfees.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objfees.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objfees.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objfees.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objfees.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objfees.ActionTypes;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objfees.IsActive;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objfees.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objfees.SectionID;

                    arParms[12] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[12].Value = objfees.StreamID;

                    arParms[13] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[13].Value = objfees.FeeTypeID;

                    arParms[14] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[14].Value = objfees.Datefrom;

                    arParms[15] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[15].Value = objfees.Dateto;

                    arParms[16] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[16].Value = objfees.PayModeID;

                    arParms[17] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[17].Value = objfees.PaymentType;

                    arParms[18] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[18].Value = objfees.StudentCategoryID;

                    arParms[19] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[19].Value = objfees.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_tap5fee_SearchDuecollectedList", arParms);
                    List<FeeCollectionData> lstFeeDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
                    result = lstFeeDetails;
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
        public int DeleteSchoolFeesByIDtap5(FeeCollectionData objfees)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_tap5Fee_DeleteCollectedDueFee", arParms);
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
        public List<FeeCollectionData> SearchChildDetailByNotap5(FeeCollectionData objitemData)
        {
            List<FeeCollectionData> result = null;
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
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_tap5Fee_ChildDetailByBillNo", arParms);
                    List<FeeCollectionData> lstChildDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
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
        public List<FeeCollectionData> GetStudentFeeListoexcel(FeeCollectionData objstd)
        {
            List<FeeCollectionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.StudentName;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objstd.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objstd.Dateto;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objstd.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objstd.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objstd.ActionType;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objstd.IsActiveALL;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objstd.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objstd.SectionID;

                    arParms[12] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[12].Value = objstd.FeeTypeID;

                    arParms[13] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[13].Value = objstd.StudentCategoryID;

                    arParms[14] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[14].Value = objstd.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetstudentFeeListtoexcel", arParms);
                    List<FeeCollectionData> lstStudentDetails = ORHelper<FeeCollectionData>.FromDataReaderToList(sqlReader);
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
        public List<FeepaymentData> Getfeepaymentdetails(FeepaymentData objDA)
        {
            List<FeepaymentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objDA.StudentID;

                    arParms[1] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[1].Value = objDA.FeeTypeID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objDA.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_Get_OnlinePaymentdetails", arParms);
                    List<FeepaymentData> listdetails = ORHelper<FeepaymentData>.FromDataReaderToList(sqlReader);
                    result = listdetails;
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
        public int Payfee(FeepaymentData objDA)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objDA.XMLData;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objDA.StudentID;

                    arParms[2] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[2].Value = objDA.FeeTypeID;

                    arParms[3] = new SqlParameter("@TotalAmount", SqlDbType.Money);
                    arParms[3].Value = objDA.TotalAmount;

                    arParms[4] = new SqlParameter("@TotalFineAmount", SqlDbType.Money);
                    arParms[4].Value = objDA.FineAmount;

                    arParms[5] = new SqlParameter("@TotalDiscountAmount", SqlDbType.Money);
                    arParms[5].Value = objDA.DiscountAmount;

                    arParms[6] = new SqlParameter("@TotalPaidAmount", SqlDbType.Money);
                    arParms[6].Value = objDA.TotalPaidAmount;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objDA.AcademicSessionID;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objDA.CompanyID;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    arParms[10] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[10].Value = objDA.PaymentType;

                    arParms[11] = new SqlParameter("@Addedby", SqlDbType.Int);
                    arParms[11].Value = objDA.EmployeeID;

                    arParms[12] = new SqlParameter("@Paymentreceipt", SqlDbType.Image);
                    arParms[12].Value = objDA.Paymentreceipt;

                    arParms[13] = new SqlParameter("@Billdate", SqlDbType.DateTime);
                    arParms[13].Value = objDA.Billdate;

                    arParms[14] = new SqlParameter("@PaymentID", SqlDbType.VarChar);
                    arParms[14].Value = objDA.PaymentID;

                    arParms[15] = new SqlParameter("@OrderID", SqlDbType.VarChar);
                    arParms[15].Value = objDA.OrderID;

                    arParms[16] = new SqlParameter("@TotalExemptedAmount", SqlDbType.Money);
                    arParms[16].Value = objDA.ExemptionAmount;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_MakeOnlinepayment", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[9].Value);
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
        public List<FeeStatusData> Getfeepamentlist(FeeStatusData objDA)
        {
            List<FeeStatusData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objDA.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objDA.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objDA.RollNo;

                    arParms[3] = new SqlParameter("@CollectedBy", SqlDbType.Int);
                    arParms[3].Value = objDA.EmployeeID;

                    arParms[4] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[4].Value = objDA.Datefrom;

                    arParms[5] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[5].Value = objDA.Dateto;

                    arParms[6] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[6].Value = objDA.FeeTypeID;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objDA.AcademicSessionID;

                    arParms[8] = new SqlParameter("@Status", SqlDbType.Bit);
                    arParms[8].Value = objDA.IsActive;

                    arParms[9] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[9].Value = objDA.PageSize;

                    arParms[10] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[10].Value = objDA.CurrentIndex;

                    arParms[11] = new SqlParameter("@PaymentMode", SqlDbType.Int);
                    arParms[11].Value = objDA.PaymentMode;

                    arParms[12] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[12].Value = objDA.AdmissionTypeID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_Getfeestatus", arParms);
                    List<FeeStatusData> listdetails = ORHelper<FeeStatusData>.FromDataReaderToList(sqlReader);
                    result = listdetails;
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
        public List<FeeStatusData> Getdefaulterlist(FeeStatusData objDA)
        {
            List<FeeStatusData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objDA.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objDA.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objDA.RollNo;

                    arParms[3] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[3].Value = objDA.FeeTypeID;

                    arParms[4] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[4].Value = objDA.MonthID;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objDA.AcademicSessionID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objDA.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objDA.CurrentIndex;

                    arParms[8] = new SqlParameter("@Paystatus", SqlDbType.Int);
                    arParms[8].Value = objDA.Paystatus;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DefaulterList", arParms);
                    List<FeeStatusData> listdetails = ORHelper<FeeStatusData>.FromDataReaderToList(sqlReader);
                    result = listdetails;
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
        public int DeleteBill(FeeStatusData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[2].Value = objfees.AcademicSessionID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[4].Value = objfees.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteFeedeatilByID", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[3].Value);
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
    }
}
