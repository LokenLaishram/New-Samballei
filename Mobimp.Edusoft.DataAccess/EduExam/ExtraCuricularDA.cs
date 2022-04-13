using Mobimp.Campusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mobimp.Campusoft.DataAccess.EduExam
{
    public class ExtraCuricularDA
    {
        public int UpdateExtraCuricularGrade(ExamGradeData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@GradeID", SqlDbType.Int);
                    arParms[0].Value = objdata.GradeID;

                    arParms[1] = new SqlParameter("@Grade", SqlDbType.VarChar);
                    arParms[1].Value = objdata.Grade;

                    arParms[2] = new SqlParameter("@GradeValue", SqlDbType.Int);
                    arParms[2].Value = objdata.GradeValue;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = objdata.ActionType;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateExtraCuricularGrade", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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
        public List<ExamGradeData> GetExtraCuricularGradeList(ExamGradeData objdata)
        {
            List<ExamGradeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];


                    arParms[0] = new SqlParameter("@Grade", SqlDbType.VarChar);
                    arParms[0].Value = objdata.SubjectGrade;

                    arParms[1] = new SqlParameter("@GradeValue", SqlDbType.Int);
                    arParms[1].Value = objdata.GradeValue;

                    arParms[2] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[2].Value = objdata.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetExtraCuricularGradeList", arParms);
                    List<ExamGradeData> lstSubjectGrade = ORHelper<ExamGradeData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public List<ExamGradeData> GetExtraCuricularGradeByID(ExamGradeData objData)
        {
            List<ExamGradeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@GradeID", SqlDbType.Int);
                    arParms[0].Value = objData.GradeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetExtraCuricularGradeByID", arParms);
                    List<ExamGradeData> lstSubjectGrade = ORHelper<ExamGradeData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public int DeleteExtraCuricularGradeByID(ExamGradeData objDate)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@GradeID", SqlDbType.Int);
                    arParms[0].Value = objDate.GradeID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteSubjectGradeByID", arParms);
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
