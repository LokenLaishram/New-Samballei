using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduEmployee;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduEmployee
{
    public class AssignSubjectDA
    {
        public int UpdateAssignDetails(AssignSubjectData objasign)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@AssignID", SqlDbType.Int);
                    arParms[0].Value = objasign.AssignID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objasign.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objasign.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = objasign.SubjectID;

                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[4].Value = objasign.EmployeeID;

                    arParms[5] = new SqlParameter("@IsActiveALL", SqlDbType.Int);
                    arParms[5].Value = objasign.IsActiveALL;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objasign.CompanyID;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[7].Value = objasign.AcademicSessionID;

                    arParms[8] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[8].Value = objasign.AddedBy;

                    arParms[9] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[9].Value = objasign.UserId;

                    arParms[10] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[10].Value = objasign.ActionType;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    arParms[12] = new SqlParameter("@StaffCategoryID", SqlDbType.Int);
                    arParms[12].Value = objasign.StaffCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_UpdateAssignDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[11].Value);
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
        public List<AssignSubjectData> SearchAssignDetails(AssignSubjectData objasign)
        {
            List<AssignSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[0].Value = objasign.EmployeeID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objasign.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objasign.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = objasign.SubjectID;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objasign.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objasign.CurrentIndex;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objasign.ActionType;

                    arParms[7] = new SqlParameter("@IsActiveALL", SqlDbType.VarChar);
                    arParms[7].Value = objasign.IsActiveALL;

                    arParms[8] = new SqlParameter("@StaffCategoryID", SqlDbType.Int);
                    arParms[8].Value = objasign.StaffCategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_AssignsubjectDetailMST", arParms);
                    List<AssignSubjectData> lstAssignDetails = ORHelper<AssignSubjectData>.FromDataReaderToList(sqlReader);
                    result = lstAssignDetails;
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
        public List<AssignSubjectData> GetEmpnames(AssignSubjectData objasign)
        {
            List<AssignSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    arParms[0].Value = objasign.EmpName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_autocompleteEmpnames", arParms);
                    List<AssignSubjectData> lstAssignDetails = ORHelper<AssignSubjectData>.FromDataReaderToList(sqlReader);
                    result = lstAssignDetails;
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
        public List<AssignSubjectData> GetAssignDetailsByID(AssignSubjectData objasign)
        {
            List<AssignSubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AssignID", SqlDbType.Int);
                    arParms[0].Value = objasign.AssignID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objasign.ActionType;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_EditAssignClassDetail", arParms);
                    List<AssignSubjectData> lstAssignDetails = ORHelper<AssignSubjectData>.FromDataReaderToList(sqlReader);
                    result = lstAssignDetails;
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
        public int DeleteAssignDetailsByID(AssignSubjectData objasign)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AssignID", SqlDbType.Int);
                    arParms[0].Value = objasign.AssignID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objasign.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_DeleteAssignClassDetailByID", arParms);
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
