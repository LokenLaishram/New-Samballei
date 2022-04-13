using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.DataAccess.EduAdmin
{
    public class CommonDataDA
    {
        public bool SaveLogo(CommonData objCommonData)
        {
            bool result = false;
            try
            {
                //foreach (CommonData objCommonData in lstCommonData)
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objCommonData.ID;

                    arParms[1] = new SqlParameter("@LogoLocation", SqlDbType.VarChar);
                    arParms[1].Value = objCommonData.LogoLocation;

                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objCommonData.ActionType;

                    arParms[3] = new SqlParameter("@SchoolName", SqlDbType.NVarChar);
                    arParms[3].Value = objCommonData.SchoolName;

                    //arParms[4] = new SqlParameter("@ModuleName", SqlDbType.NVarChar);
                    //arParms[4].Value = objCommonData.ModuleName;

                    int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateSchoolLogo", arParms);
                    if (records == -1 || records > 0)
                        result = true;
                }

            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }

        public List<CommonData> GetLogo(CommonData objCommonData)
        {
            List<CommonData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[0].Value = objCommonData.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateSchoolDetails", arParms);
                    List<CommonData> listservice = ORHelper<CommonData>.FromDataReaderToList(sqlReader);
                    result = listservice;
                }
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public bool DeleteLogo(CommonData objCommonData)
        {
            bool result = false;

            try
            {

                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objCommonData.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objCommonData.ActionType;


                    int records = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_EDU_UpdateSchoolLogo", arParms);
                    if (records == -1 || records > 0)
                        result = true;
                }

            }

            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }

            return result;
        }

    }
}
