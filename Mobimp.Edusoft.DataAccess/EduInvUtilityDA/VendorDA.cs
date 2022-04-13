using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduInvUtility;

namespace Mobimp.Edusoft.DataAccess.EduInvUtilityDA
{
    public class VendorDA
    {
        public int SaveVendor(VendorData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorTypeID;

                    arParms[1] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objdata.AcademicSessionID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[5].Value = objdata.EmployeeID;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objdata.ActionType;

                    arParms[7] = new SqlParameter("@VendorCode", SqlDbType.VarChar);
                    arParms[7].Value = objdata.VendorCode;

                    arParms[8] = new SqlParameter("@VendorName", SqlDbType.VarChar);
                    arParms[8].Value = objdata.VendorName;

                    arParms[9] = new SqlParameter("@GSTIN", SqlDbType.VarChar);
                    arParms[9].Value = objdata.GSTIN;

                    arParms[10] = new SqlParameter("@ContactPerson", SqlDbType.VarChar);
                    arParms[10].Value = objdata.ContactPerson;

                    arParms[11] = new SqlParameter("@PhoneNo", SqlDbType.VarChar);
                    arParms[11].Value = objdata.PhoneNo; ;

                    arParms[12] = new SqlParameter("@Address", SqlDbType.VarChar);
                    arParms[12].Value = objdata.Address;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_UpdateVendorMST", arParms);
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
        public List<VendorData> SearchVendor(VendorData objVendor)
        {
            List<VendorData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[0].Value = objVendor.VendorTypeID;

                    arParms[1] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[1].Value = objVendor.IsActive;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objVendor.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objVendor.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchVendorMST", arParms);
                    List<VendorData> lstDetails = ORHelper<VendorData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public List<VendorData> GetVendorbyID(VendorData objVendor)
        {
            List<VendorData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objVendor.VendorID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_EditVendorMST", arParms);
                    List<VendorData> lstDetails = ORHelper<VendorData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public int DeleteVendorID(VendorData objVendor)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objVendor.VendorID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objVendor.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objVendor.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_DeleteActivateVendorMST", arParms);
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
