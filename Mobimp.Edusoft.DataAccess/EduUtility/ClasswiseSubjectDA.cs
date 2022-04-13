using Mobimp.Campusoft.Data.EduUtility;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.DataAccess.EduUtility
{
    public class ClasswiseSubjectDA
    {
        public int UpdateSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objsubject.ClassID;

                    arParms[3] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[3].Value = objsubject.StreamID;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objsubject.IsActive;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objsubject.AcademicSessionID;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objsubject.AddedBy;

                    arParms[7] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[7].Value = objsubject.UserId;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objsubject.CompanyID;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objsubject.ActionType;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;                  

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateClasswiseSubjectMST", arParms);
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
        public int AddSubSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objsubject.ClassID;

                    arParms[3] = new SqlParameter("@SubjectName", SqlDbType.VarChar);
                    arParms[3].Value = objsubject.Descriptions;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objsubject.IsActive;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objsubject.AcademicSessionID;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objsubject.AddedBy;

                    arParms[7] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[7].Value = objsubject.UserId;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objsubject.CompanyID;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objsubject.ActionType;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_AddClasswiseSubSubjectMST", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[10].Value);
                    }
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
        public int UpdateSubSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objsubject.ClassID;

                    arParms[3] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[3].Value = objsubject.StreamID;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objsubject.IsActive;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objsubject.AcademicSessionID;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objsubject.AddedBy;

                    arParms[7] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[7].Value = objsubject.UserId;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objsubject.CompanyID;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objsubject.ActionType;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    arParms[11] = new SqlParameter("@SubSubjectID", SqlDbType.Int);
                    arParms[11].Value = objsubject.SubSubjectID;

                    arParms[12] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[12].Value = objsubject.ExamID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateClasswiseSubSubjectMST", arParms);
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
        public int UpdateSubjectList(ClasswiseSubjectData objstd)
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
        public int UpdateSubSubjectList(ClasswiseSubjectData objstd)
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

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateSubSubjectdetailList", arParms);
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
        public List<ClasswiseSubjectData> SearchClasswiseSubjectDetails(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objsubject.Code;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objsubject.ClassID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objsubject.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objsubject.CurrentIndex;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objsubject.ActionType;

                    arParms[6] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[6].Value = objsubject.StreamID;

                    arParms[7] = new SqlParameter("@ICompulsory", SqlDbType.Bit);
                    arParms[7].Value = objsubject.ICompulsory;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objsubject.AcademicSessionID;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[9].Value = objsubject.IsActive;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchClasswiseSubjectDetailMST", arParms);
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public List<ClasswiseSubjectData> GetclasswiseSubsubjectlist(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[0].Value = objsubject.SubjectID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objsubject.ClassID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objsubject.AcademicSessionID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[3].Value = objsubject.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchClasswiseSubSubjectDetailMST", arParms);
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public List<ClasswiseSubjectData> SearchClasswiseSubSubjectDetails(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objsubject.Code;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objsubject.ClassID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objsubject.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objsubject.CurrentIndex;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objsubject.ActionType;

                    arParms[6] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[6].Value = objsubject.StreamID;

                    arParms[7] = new SqlParameter("@ICompulsory", SqlDbType.Bit);
                    arParms[7].Value = objsubject.ICompulsory;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objsubject.AcademicSessionID;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[9].Value = objsubject.IsActive;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchClasswiseSubSubjectDetailMST", arParms);
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public List<ClasswiseSubjectData> GetClasswiseSubjectList(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
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
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public List<ClasswiseSubjectData> GetClasswiseSubjectDetailsByID(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objsubject.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditClasswiseSubjectDetailMST", arParms);
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public List<ClasswiseSubjectData> GetsubsubjectbyID(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objsubject.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_Get_SubsubjectbyID", arParms);
                    List<ClasswiseSubjectData> lstSubjectDetails = ORHelper<ClasswiseSubjectData>.FromDataReaderToList(sqlReader);
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
        public int DeleteClasswiseSubjectDetailsByID(ClasswiseSubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsubject.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteClasswiseSubjectDetailMST", arParms);

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
        public int DeleteSubsubjectByID(ClasswiseSubjectData objsubject)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objsubject.ID;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objsubject.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsubject.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteSubsubjectbyID", arParms);

                    if (result_ > 0 || result_ == -1)
                    { 
                        result = Convert.ToInt32(arParms[2].Value);
                    }
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
        public int Activatesub(ClasswiseSubjectData objsub)
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
