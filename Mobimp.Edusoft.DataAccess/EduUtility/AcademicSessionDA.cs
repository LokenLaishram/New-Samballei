using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class AcademicSessionDA
    {
        public int UpdateAcademicSession(AcademicSessionData objAcademic)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objAcademic.ID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objAcademic.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objAcademic.Descriptions;

                    arParms[3] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[3].Value = objAcademic.Status;

                    arParms[4] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[4].Value = objAcademic.DateFrom;

                    arParms[5] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[5].Value = objAcademic.DateTo;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objAcademic.AddedBy;

                    arParms[7] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[7].Value = objAcademic.UserId;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objAcademic.CompanyID;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objAcademic.ActionType;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_AcademicSessionDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[10].Value);
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
        public List<AcademicSessionData> SearchAcademicSessionDetails(AcademicSessionData objAcademic)
        {
            List<AcademicSessionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objAcademic.Code;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objAcademic.Descriptions;

                    arParms[2] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[2].Value = objAcademic.Status;

                    arParms[3] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[3].Value = objAcademic.DateFrom;

                    arParms[4] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[4].Value = objAcademic.DateTo;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objAcademic.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objAcademic.CurrentIndex;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objAcademic.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhAcademicSessionDetailMST", arParms);
                    List<AcademicSessionData> lstacademicDetails = ORHelper<AcademicSessionData>.FromDataReaderToList(sqlReader);
                    result = lstacademicDetails;
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
        public List<AcademicSessionData> GetAcademicSessionDetailsByID(AcademicSessionData objAcademic)
        {
            List<AcademicSessionData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objAcademic.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objAcademic.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditAcademicSessionDetailMST", arParms);
                    List<AcademicSessionData> lstacademicDetails = ORHelper<AcademicSessionData>.FromDataReaderToList(sqlReader);
                    result = lstacademicDetails;
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
        public int DeleteAcademicSessionDetailsByID(AcademicSessionData objAcademic)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objAcademic.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objAcademic.ActionType;

                    arParms[2] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[2].Value = objAcademic.Remarks;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteAcademicSessionDetailMST", arParms);
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
    }
}
