using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduTransport;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common;



namespace Mobimp.Edusoft.DataAccess.EduTransport
{
    public class TransportfeeDA
    {
        public int UpdateTransportFeesDetails(TransportFeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@TransportID", SqlDbType.Int);
                    arParms[1].Value = objfees.TransportID;

                    arParms[2] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[2].Value = objfees.RouteID;

                    arParms[3] = new SqlParameter("@TransportType", SqlDbType.Int);
                    arParms[3].Value = objfees.TransportType;

                    arParms[4] = new SqlParameter("@TransportStudentType", SqlDbType.Int);
                    arParms[4].Value = objfees.TransportStudentTypeID;

                    arParms[5] = new SqlParameter("@Destination", SqlDbType.VarChar);
                    arParms[5].Value = objfees.Destination;

                    arParms[6] = new SqlParameter("@TransportFeeAmount", SqlDbType.Money);
                    arParms[6].Value = objfees.TransportFeeAmount;

                    arParms[7] = new SqlParameter("@TransportExemptedAmount", SqlDbType.Money);
                    arParms[7].Value = objfees.TransportExemptedAmount;

                    arParms[8] = new SqlParameter("@Fare", SqlDbType.Money);
                    arParms[8].Value = objfees.Fare;

                    arParms[9] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[9].Value = objfees.AddedBy;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[10].Value = objfees.UserId;

                    arParms[11] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[11].Value = objfees.CompanyID;

                    arParms[12] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[12].Value = objfees.ActionType;

                    arParms[13] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[13].Value = objfees.AcademicSessionID;

                    arParms[14] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[14].Direction = ParameterDirection.Output;

                    arParms[15] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[15].Value = objfees.VehicleNo;

                    arParms[16] = new SqlParameter("@VehicleID", SqlDbType.Int);
                    arParms[16].Value = objfees.VehicleID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateTransportFeeDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                    { 
                        result = Convert.ToInt32(arParms[14].Value);
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
        public int ActivateTransportFee(TransportFeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;
          
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objfees.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@IsActivate", SqlDbType.Int);
                    arParms[3].Value = objfees.IsActivate;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_ActivateTransportFeeDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[2].Value);
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
        public List<TransportFeeData> GetTransportFeesDetailsByID(TransportFeeData objfees)
        {
            List<TransportFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_GetTransportFeeDetailByID", arParms);
                    List<TransportFeeData> lstFeesDetails = ORHelper<TransportFeeData>.FromDataReaderToList(sqlReader);
                    result = lstFeesDetails;
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
        public int DeleteTransFeesDetailsByID(TransportFeeData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteTransportFeeDetail", arParms);
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
        public List<TransportFeeData> GetTransportfeedetails(TransportFeeData objfees)
        {
            List<TransportFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[0].Value = objfees.RouteID;

                    arParms[1] = new SqlParameter("@TransportType", SqlDbType.Int);
                    arParms[1].Value = objfees.TransportType;

                    arParms[2] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[2].Value = objfees.VehicleNo;

                    arParms[3] = new SqlParameter("@Destination", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Destination;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objfees.AcademicSessionID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objfees.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objfees.CurrentIndex;

                    arParms[7] = new SqlParameter("@VehicleID", SqlDbType.Int);
                    arParms[7].Value = objfees.VehicleID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_GetTranportfeedetails", arParms);
                    List<TransportFeeData> lstFeesDetails = ORHelper<TransportFeeData>.FromDataReaderToList(sqlReader);
                    result = lstFeesDetails;
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
        public List<TransportFeeData> GetDestinationByVehicleID(TransportFeeData objfees)
        {
            List<TransportFeeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[1].Value = objfees.RouteID;

                    arParms[2] = new SqlParameter("@VehicleID", SqlDbType.Int);
                    arParms[2].Value = objfees.VehicleID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetDestinationByVehicleID", arParms);
                    List<TransportFeeData> lstFeesDetails = ORHelper<TransportFeeData>.FromDataReaderToList(sqlReader);
                    result = lstFeesDetails;
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
