using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Campusoft.DataAccess.EduHostel
{
    public class DepositFeeDA
    {
        public int UpdateServiceFeeDepositDetails(DepositFeeData objfee)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfee.ID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[1].Value = objfee.AdmissioNo;

                    arParms[2] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[2].Value = objfee.PayModeID;

                    arParms[3] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[3].Value = objfee.BankName;

                    arParms[4] = new SqlParameter("@ChalanNo", SqlDbType.VarChar);
                    arParms[4].Value = objfee.ChalanNo;

                    arParms[5] = new SqlParameter("@DepositAmount", SqlDbType.Money);
                    arParms[5].Value = objfee.DepositAmount;

                    arParms[6] = new SqlParameter("@DepositDate", SqlDbType.DateTime);
                    arParms[6].Value = objfee.DepositDate;

                    arParms[7] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[7].Value = objfee.UserId;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objfee.CompanyID;

                    arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[9].Value = objfee.AcademicSessionID;

                    arParms[10] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[10].Value = objfee.AddedBy;

                    arParms[11] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[11].Value = objfee.ActionTypes;

                    arParms[12] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[12].Value = objfee.IsActive;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_UpdateDepositFeedetails", arParms);
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
        public List<DepositFeeData> SearchDepositFeeDepositDetails(DepositFeeData objservfee)
        {
            List<DepositFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objservfee.AdmissioNo;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objservfee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[2].Value = objservfee.SexID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objservfee.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objservfee.SectionID;

                    arParms[5] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[5].Value = objservfee.Datefrom;

                    arParms[6] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[6].Value = objservfee.Dateto;

                    arParms[7] = new SqlParameter("@PayModeID", SqlDbType.Int);
                    arParms[7].Value = objservfee.PayModeID;

                    arParms[8] = new SqlParameter("@PaymentType", SqlDbType.Int);
                    arParms[8].Value = objservfee.PaymentType;

                    arParms[9] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[9].Value = objservfee.PageSize;

                    arParms[10] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[10].Value = objservfee.CurrentIndex;

                    arParms[11] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[11].Value = objservfee.ActionTypes;

                    arParms[12] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[12].Value = objservfee.IsActive;

                    arParms[13] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[13].Value = objservfee.UserId;

                    arParms[14] = new SqlParameter("@ReceiptNo", SqlDbType.VarChar);
                    arParms[14].Value = objservfee.ReceiptNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_SearchDepositFeeDetails ", arParms);
                    List<DepositFeeData> lstServFeeDetails = ORHelper<DepositFeeData>.FromDataReaderToList(sqlReader);
                    result = lstServFeeDetails;
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

        public int DeleteDepositFeesByID(DepositFeeData objdepositfee)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objdepositfee.ID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdepositfee.AcademicSessionID;

                    arParms[2] = new SqlParameter("@StudentsID", SqlDbType.Int);
                    arParms[2].Value = objdepositfee.StudentsID;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objdepositfee.Remarks;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[5].Value = objdepositfee.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_DeleteDepositFeeDetails", arParms);
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
    }
}
