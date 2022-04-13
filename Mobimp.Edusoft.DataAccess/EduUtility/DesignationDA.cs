using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
   public class DesignationDA
    {
        public int UpdateDesignationDetails(DesignationData Objdesignation)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@DesignationID", SqlDbType.Int);
                    arParms[0].Value = Objdesignation.DesignationID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = Objdesignation.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = Objdesignation.Descriptions;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = Objdesignation.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[4].Value = Objdesignation.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = Objdesignation.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = Objdesignation.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateDesignationDetailMST", arParms);
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
        public List<DesignationData> SearchDesignationDetails(DesignationData Objdesignation)
        {
            List<DesignationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = Objdesignation.Code;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = Objdesignation.Descriptions;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = Objdesignation.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = Objdesignation.CurrentIndex;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = Objdesignation.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhDesignationDetailMST", arParms);
                    List<DesignationData> lstDesignationDetails = ORHelper<DesignationData>.FromDataReaderToList(sqlReader);
                    result = lstDesignationDetails;
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
        public List<DesignationData> GetDesignationDetailsByID(DesignationData Objdesignation)
        {
            List<DesignationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@DesignationID", SqlDbType.Int);
                    arParms[0].Value = Objdesignation.DesignationID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = Objdesignation.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditDesignationDetailMST", arParms);
                    List<DesignationData> lstDesignationDetails = ORHelper<DesignationData>.FromDataReaderToList(sqlReader);
                    result = lstDesignationDetails;
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
        public int DeleteDesignationDetailsByID(DesignationData Objdesignation)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@DesignationID", SqlDbType.Int);
                    arParms[0].Value = Objdesignation.DesignationID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = Objdesignation.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteDesignationDetailMST", arParms);
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
