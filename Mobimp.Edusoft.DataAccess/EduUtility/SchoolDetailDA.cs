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
    public class SchoolDetailDA
    {
        public int UpdateSchoolDetails(SchoolDetailData objSchool)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[19];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objSchool.ID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objSchool.Code;

                    arParms[2] = new SqlParameter("@SchoolName", SqlDbType.VarChar);
                    arParms[2].Value = objSchool.SchoolName;

                    arParms[3] = new SqlParameter("@SchoolAddress", SqlDbType.VarChar);
                    arParms[3].Value = objSchool.SchoolAddress;

                    arParms[4] = new SqlParameter("@RecognitionNo", SqlDbType.VarChar);
                    arParms[4].Value = objSchool.RecognitionNo;

                    arParms[5] = new SqlParameter("@Website", SqlDbType.VarChar);
                    arParms[5].Value = objSchool.Website;

                    arParms[6] = new SqlParameter("@CountryID", SqlDbType.Int);
                    arParms[6].Value = objSchool.CountryID;

                    arParms[7] = new SqlParameter("@StateID", SqlDbType.Int);
                    arParms[7].Value = objSchool.StateID;

                    arParms[8] = new SqlParameter("@DistrictID", SqlDbType.Int);
                    arParms[8].Value = objSchool.DistrictID;

                    arParms[9] = new SqlParameter("@PinNo", SqlDbType.Int);
                    arParms[9].Value = objSchool.PinNo;

                    arParms[10] = new SqlParameter("@PhoneNo", SqlDbType.VarChar);
                    arParms[10].Value = objSchool.PhoneNo;

                    arParms[11] = new SqlParameter("@LogoLocation", SqlDbType.VarChar);
                    arParms[11].Value = objSchool.LogoLocation;

                    arParms[12] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                    arParms[12].Value = objSchool.MobileNo;

                    arParms[13] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[13].Value = objSchool.AddedBy;

                    arParms[14] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[14].Value = objSchool.UserId;

                    arParms[15] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[15].Value = objSchool.ActionType;

                    arParms[16] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[16].Direction = ParameterDirection.Output;

                    arParms[17] = new SqlParameter("@EmailID", SqlDbType.VarChar);
                    arParms[17].Value = objSchool.EmailID;

                    arParms[18] = new SqlParameter("@LogoLocationimage", SqlDbType.Image);
                    arParms[18].Value = objSchool.LogoLocationimage;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateSchoolDetailMST", arParms);
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
        public List<SchoolDetailData> SearchSchoolDetails(SchoolDetailData objSchool)
        {
            List<SchoolDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objSchool.Code;

                    arParms[1] = new SqlParameter("@SchoolName", SqlDbType.VarChar);
                    arParms[1].Value = objSchool.SchoolName;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objSchool.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objSchool.CurrentIndex;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = objSchool.ActionType;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhSchoolDetailMST", arParms);
                    List<SchoolDetailData> lstSchoolDetails = ORHelper<SchoolDetailData>.FromDataReaderToList(sqlReader);
                    result = lstSchoolDetails;
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
        public List<SchoolDetailData> GetSchoolDetailsByID(SchoolDetailData objSchool)
        {
            List<SchoolDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objSchool.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objSchool.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditSchoolDetailMST", arParms);
                    List<SchoolDetailData> lstSchoolDetails = ORHelper<SchoolDetailData>.FromDataReaderToList(sqlReader);
                    result = lstSchoolDetails;
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
        public int DeleteSchoolDetailsByID(SchoolDetailData objSchool)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objSchool.ID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objSchool.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteSchoolDetailMST", arParms);
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
