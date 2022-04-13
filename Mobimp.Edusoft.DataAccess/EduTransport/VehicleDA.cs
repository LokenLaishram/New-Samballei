using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Data.EduTransport;

namespace Mobimp.Edusoft.DataAccess.EduTransport
{
    public class VehicleDA
    {
        public int UpdateVehicleDetails(VehicleData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;

                    arParms[1] = new SqlParameter("@TransportType", SqlDbType.Int);
                    arParms[1].Value = objfees.TransportType;

                    arParms[2] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[2].Value = objfees.VehicleNo;

                    arParms[3] = new SqlParameter("@DriverName", SqlDbType.VarChar);
                    arParms[3].Value = objfees.DriverName;

                    arParms[4] = new SqlParameter("@ContactNo", SqlDbType.VarChar);
                    arParms[4].Value = objfees.ContactNo;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objfees.AddedBy;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[6].Value = objfees.UserId;

                    arParms[7] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[7].Value = objfees.CompanyID;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objfees.ActionType;

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = objfees.AcademicSessionID;

                    arParms[11] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[11].Value = objfees.RouteID;

                    arParms[12] = new SqlParameter("@CareOf", SqlDbType.VarChar);
                    arParms[12].Value = objfees.CareOf;

                    arParms[13] = new SqlParameter("@Address", SqlDbType.VarChar);
                    arParms[13].Value = objfees.Address;

                    arParms[14] = new SqlParameter("@Licence", SqlDbType.VarChar);
                    arParms[14].Value = objfees.Licence;

                    arParms[15] = new SqlParameter("@Descriptions", SqlDbType.VarChar);
                    arParms[15].Value = objfees.Descriptions;

                    //arParms[15] = new SqlParameter("@Photo", SqlDbType.VarChar);
                    //arParms[15].Value = objfees.Photo;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateVehicleDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[9].Value);
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
        public List<VehicleData> GetVehicledetails(VehicleData objfees)
        {
            List<VehicleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[0].Value = objfees.VehicleNo;

                    arParms[1] = new SqlParameter("@TransportType", SqlDbType.Int);
                    arParms[1].Value = objfees.TransportType;

                    arParms[2] = new SqlParameter("@DriverName", SqlDbType.VarChar);
                    arParms[2].Value = objfees.DriverName;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.VarChar);
                    arParms[3].Value = objfees.AcademicSessionID;

                    arParms[4] = new SqlParameter("@ContactNo", SqlDbType.VarChar);
                    arParms[4].Value = objfees.ContactNo;

                    arParms[5] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[5].Value = objfees.RouteID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objfees.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objfees.CurrentIndex;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objfees.IsActive;
                    
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_GetVehicleDetails", arParms);
                    List<VehicleData> lstFeesDetails = ORHelper<VehicleData>.FromDataReaderToList(sqlReader);
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
        public List<VehicleData> GetVehicleDetailsByID(VehicleData objfees)
        {
            List<VehicleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objfees.ID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_GetVehicleDetailByID", arParms);
                    List<VehicleData> lstFeesDetails = ORHelper<VehicleData>.FromDataReaderToList(sqlReader);
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
        public int DeleteVehicleDetailsByID(VehicleData objfees)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_DeleteVehicleDetail", arParms);
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
        public int UpLoadDriverPhoto(VehicleData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@DriverID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.ID;

                    arParms[1] = new SqlParameter("@DriverPhoto", SqlDbType.Image);
                    arParms[1].Value = objstd.Driverphoto;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@IsPhotoUploaded", SqlDbType.BigInt);
                    arParms[3].Value = objstd.IsPhotoUploaded;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateDriverPhotos", arParms);
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
        public List<VehicleData> GetRouteDetails(VehicleData objfees)
        {
            List<VehicleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@RouteCode", SqlDbType.VarChar);
                    arParms[1].Value = objfees.RouteCode;

                    arParms[2] = new SqlParameter("@RouteName", SqlDbType.VarChar);
                    arParms[2].Value = objfees.RouteName;

                    arParms[3] = new SqlParameter("@Destination", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Destination;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objfees.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objfees.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTransportRouteDetails", arParms);
                    List<VehicleData> lstFeesDetails = ORHelper<VehicleData>.FromDataReaderToList(sqlReader);
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
        public int UpdateRouteDetails(VehicleData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfees.AcademicSessionID;

                    arParms[1] = new SqlParameter("@RouteCode", SqlDbType.VarChar);
                    arParms[1].Value = objfees.RouteCode;

                    arParms[2] = new SqlParameter("@RouteName", SqlDbType.VarChar);
                    arParms[2].Value = objfees.RouteName;

                    arParms[3] = new SqlParameter("@Destination", SqlDbType.VarChar);
                    arParms[3].Value = objfees.Destination;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objfees.ActionType;

                    arParms[6] = new SqlParameter("@UserLoginID", SqlDbType.Float);
                    arParms[6].Value = objfees.UserId;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objfees.AddedBy;

                    arParms[8] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[8].Value = objfees.RouteID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateRouteDetails", arParms);
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
        public List<VehicleData> GetTransportRouteDetailsByID(VehicleData objfees)
        {
            List<VehicleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[0].Value = objfees.RouteID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTransportRouteDetailsByID", arParms);
                    List<VehicleData> lstFeesDetails = ORHelper<VehicleData>.FromDataReaderToList(sqlReader);
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
        public int DeleteTransportRouteDetailsByID(VehicleData objfees)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@RouteID", SqlDbType.Int);
                    arParms[0].Value = objfees.RouteID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[2].Value = objfees.Remarks;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objfees.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteTransportRouteDetailsByID", arParms);
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
