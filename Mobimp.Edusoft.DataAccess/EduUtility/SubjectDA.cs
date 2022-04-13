using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class SubjectDA
    {
        public int UpdateSubjectDetails(SubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[0].Value = objsubject.SubjectID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objsubject.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objsubject.Descriptions;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsubject.AcademicSessionID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objsubject.AddedBy;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[5].Value = objsubject.UserId;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objsubject.CompanyID;

                    arParms[7] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[7].Value = objsubject.ActionType;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objsubject.IsActive;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    arParms[10] = new SqlParameter("@SubjectCategoryID", SqlDbType.Int);
                    arParms[10].Value = objsubject.SubjectCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateSubjectDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[8].Value);
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
        public int UpdateSubjectList(SubjectData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.SubjectlistXML;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateSubjectdetailList", arParms);
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
        public List<SubjectData> SearchSubjectDetails(SubjectData objsubject)
        {
            List<SubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objsubject.Code;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objsubject.Descriptions;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objsubject.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objsubject.CurrentIndex; 
                    
                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[4].Value = objsubject.IsActive;

                    arParms[5] = new SqlParameter("@SubjectCategoryID", SqlDbType.Int);
                    arParms[5].Value = objsubject.SubjectCategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchSubjectDetailMST", arParms);
                    List<SubjectData> lstSubjectDetails = ORHelper<SubjectData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
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
        public List<SubjectData> GetClasswiseSubjectList(SubjectData objsubject)
        {
            List<SubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];
                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ClassID;
                    arParms[1] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[1].Value = objsubject.StreamID;
                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = objsubject.SubjectID;
                    arParms[3] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[3].Value = objsubject.ActionType;
                    arParms[4] = new SqlParameter("@ICompulsory", SqlDbType.Bit);
                    arParms[4].Value = objsubject.ICompulsory;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Stud_GetsubjectList", arParms);
                    List<SubjectData> lstSubjectDetails = ORHelper<SubjectData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
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
        public List<SubjectData> GetSubjectDetailsByID(SubjectData objsubject)
        {
            List<SubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[0].Value = objsubject.SubjectID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;
                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objsubject.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditSubjectDetailMST", arParms);
                    List<SubjectData> lstSubjectDetails = ORHelper<SubjectData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
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
        public int DeleteSubjectDetailsByID(SubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[0].Value = objsubject.SubjectID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsubject.AcademicSessionID;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteSubjectDetailMST", arParms);
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
        public int Activatesub(SubjectData objsub)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objsub.Xmlsublist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_ActivateSubbyID", arParms);
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
