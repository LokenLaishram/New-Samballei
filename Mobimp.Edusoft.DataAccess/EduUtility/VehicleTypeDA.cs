using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;


namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class VehicleTypeDA
    {
        public int UpdateVehicleTypeDetails(VehicleTypeData objVehicleType)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objVehicleType.ID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objVehicleType.Code;

                    arParms[2] = new SqlParameter("@VehicleType", SqlDbType.VarChar);
                    arParms[2].Value = objVehicleType.VehicleType;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objVehicleType.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[4].Value = objVehicleType.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objVehicleType.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objVehicleType.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;
                    
                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objVehicleType.IsActive;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateVehicleTypeDetailMST", arParms);
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
        public List<VehicleTypeData> SearchVehicleTypeDetails(VehicleTypeData objVehicleType)
        {
            List<VehicleTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objVehicleType.Code;

                    arParms[1] = new SqlParameter("@VehicleType", SqlDbType.VarChar);
                    arParms[1].Value = objVehicleType.VehicleType;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objVehicleType.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objVehicleType.CurrentIndex;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objVehicleType.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhVehicleTypeDetailMST", arParms);
                    List<VehicleTypeData> lstRouteDetails = ORHelper<VehicleTypeData>.FromDataReaderToList(sqlReader);
                    result = lstRouteDetails;
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
        public List<VehicleTypeData> GetVehicleTypeDetailsByID(VehicleTypeData objVehicleType)
        {
            List<VehicleTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objVehicleType.RouteID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditVehicleTypeDetailMST", arParms);
                    List<VehicleTypeData> lstRouteDetails = ORHelper<VehicleTypeData>.FromDataReaderToList(sqlReader);
                    result = lstRouteDetails;
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
        public int ActivateRoute(VehicleTypeData objVehicleType)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objVehicleType.Xmlclasslist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_ActivateRoutebyID", arParms);
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
        public int DeleteVehicleTypeDetailsByID(VehicleTypeData objVehicleType)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objVehicleType.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objVehicleType.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteVehicleTypeDetailMST", arParms);
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

    }
}
