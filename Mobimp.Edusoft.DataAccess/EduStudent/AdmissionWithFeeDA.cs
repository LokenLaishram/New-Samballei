using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduStudent
{
    public class AdmissionWithFeeDA
    {
        public List<AdmissionWithFeeData> GetAvailableStudentID(AdmissionWithFeeData objitem)
        {
            List<AdmissionWithFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objitem.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_GetAvailableStudentID", arParms);
                    List<AdmissionWithFeeData> lstStudentDetails = ORHelper<AdmissionWithFeeData>.FromDataReaderToList(sqlReader);
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
        public int UpdateStudentDetails(AdmissionWithFeeData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[1].Value = objstd.StudentTypeID;

                    arParms[2] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[2].Value = objstd.StudentName;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[3].Value = objstd.SexID;

                    arParms[4] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[4].Value = objstd.DOB;

                    arParms[5] = new SqlParameter("@GmobileNo", SqlDbType.VarChar);
                    arParms[5].Value = objstd.GmobileNo;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    arParms[7] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[7].Value = objstd.ClassID;

                    arParms[8] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[8].Value = objstd.SectionID;

                    arParms[9] = new SqlParameter("@cAddress", SqlDbType.VarChar);
                    arParms[9].Value = objstd.cAddress;

                    arParms[10] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[10].Value = objstd.RollNo;

                    arParms[11] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[11].Value = objstd.UserId;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objstd.AcademicSessionID;

                    arParms[13] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[13].Value = objstd.IsNew;

                    arParms[14] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[14].Value = objstd.AddedBy;

                    arParms[15] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime);
                    arParms[15].Value = objstd.AdmissionDate;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateAdmissionWithFee", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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

        /////////////Fees Part
        public List<AdmFeeData> getfeedetailsBystudenttypeID(AdmFeeData objfees)
        {
            List<AdmFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objfees.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[2].Value = objfees.StudentTypeID;

                    arParms[3] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[3].Value = objfees.AdmissionTypeID;

                    //arParms[3] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    //arParms[3].Value = objfees.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_GetfeesAmountClasswise", arParms);
                    List<AdmFeeData> csubjectlist = ORHelper<AdmFeeData>.FromDataReaderToList(sqlReader);
                    result = csubjectlist;
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
        public int UpdateAdmissionFeeDetails(AdmFeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objfees.StudentID;

                    arParms[1] = new SqlParameter("@FeeAmount", SqlDbType.Money);
                    arParms[1].Value = objfees.FeeAmount;

                    arParms[2] = new SqlParameter("@ExemptedAmount", SqlDbType.Money);
                    arParms[2].Value = objfees.ExemptedAmount;

                    arParms[3] = new SqlParameter("@TotalFeeAmount", SqlDbType.Money);
                    arParms[3].Value = objfees.TotalFeeAmount;

                    arParms[4] = new SqlParameter("@DiscountAmount", SqlDbType.Money);
                    arParms[4].Value = objfees.DiscountAmount;

                    arParms[5] = new SqlParameter("@FineAmount", SqlDbType.Money);
                    arParms[5].Value = objfees.FineAmount;

                    arParms[6] = new SqlParameter("@PaidAmount", SqlDbType.Money);
                    arParms[6].Value = objfees.PaidAmount;

                    arParms[7] = new SqlParameter("@DueAmount", SqlDbType.Money);
                    arParms[7].Value = objfees.DueAmount;

                    arParms[8] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[8].Value = objfees.Remark;

                    arParms[9] = new SqlParameter("@StudentTypeID", SqlDbType.VarChar);
                    arParms[9].Value = objfees.StudentTypeID;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objfees.ClassID;

                    arParms[11] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[11].Value = objfees.AcademicSessionID;

                    arParms[12] = new SqlParameter("@AdmissionTypeID", SqlDbType.Int);
                    arParms[12].Value = objfees.AdmissionTypeID;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    arParms[14] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[14].Value = objfees.UserId;

                    arParms[15] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[15].Value = objfees.AddedBy;

                    arParms[16] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime);
                    arParms[16].Value = objfees.AdmissionDate;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Adm_UpdateAdmissionWithFee", arParms);
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

    }
}
