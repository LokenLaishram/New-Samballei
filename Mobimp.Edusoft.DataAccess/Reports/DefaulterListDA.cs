using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Reports;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.DataAccess.Reports
{
    public class DefaulterListDA
    {
        public List<DefaulterListData> CreateDefaulterlist(DefaulterListData objdefaulter)
        {
            List<DefaulterListData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objdefaulter.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objdefaulter.StudentName;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objdefaulter.AcademicSessionID;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[3].Value = objdefaulter.SexID;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objdefaulter.ClassID;

                    arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[5].Value = objdefaulter.SectionID;

                    arParms[6] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[6].Value = objdefaulter.FeeTypeID;

                    arParms[7] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[7].Value = objdefaulter.MonthID;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[8].Value = objdefaulter.IsActive;

                    arParms[9] = new SqlParameter("@UserLoginID", SqlDbType.Int);
                    arParms[9].Value = objdefaulter.UserId;

                    arParms[10] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[10].Value = objdefaulter.AddedBy;

                    arParms[11] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[11].Value = objdefaulter.ActionTypes;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_CreateFeeDefaulterList", arParms);
                    List<DefaulterListData> lstFeeDetails = ORHelper<DefaulterListData>.FromDataReaderToList(sqlReader);
                    result = lstFeeDetails;
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
        public List<DefaulterListData> Getdefaulterlist(DefaulterListData objdefaulter)
        {
            List<DefaulterListData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objdefaulter.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objdefaulter.StudentName;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objdefaulter.AcademicSessionID;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[3].Value = objdefaulter.SexID;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objdefaulter.ClassID;

                    arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[5].Value = objdefaulter.SectionID;

                    arParms[6] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
                    arParms[6].Value = objdefaulter.FeeTypeID;

                    arParms[7] = new SqlParameter("@MonthID", SqlDbType.Int);
                    arParms[7].Value = objdefaulter.MonthID;

                    arParms[8] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[8].Value = objdefaulter.Datefrom;

                    arParms[9] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[9].Value = objdefaulter.Dateto;

                    arParms[10] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[10].Value = objdefaulter.AddedBy;

                    arParms[11] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[11].Value = objdefaulter.ActionTypes;

                    arParms[12] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[12].Value = objdefaulter.IsActive;

                    arParms[13] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[13].Value = objdefaulter.StudentCategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetFeeDefaulterList", arParms);
                    List<DefaulterListData> lstFeeDetails = ORHelper<DefaulterListData>.FromDataReaderToList(sqlReader);
                    result = lstFeeDetails;
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
