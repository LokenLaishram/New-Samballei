using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.DataAccess.EduHostel
{
    public class AjustedDA
    {
        public List<AjustedData> GetstudentDetailByID(AjustedData objstd)
        {
            List<AjustedData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_GetAjustedstudentDetailByid", arParms);
                    List<AjustedData> lstStudentDetails = ORHelper<AjustedData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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
        public List<AjustedData> SearchAjustedtDetails(AjustedData objajustedlist)
        {
            List<AjustedData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[0].Value = objajustedlist.StudentName;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objajustedlist.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[2].Value = objajustedlist.Datefrom;

                    arParms[3] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[3].Value = objajustedlist.Dateto;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objajustedlist.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objajustedlist.CurrentIndex;

                    arParms[6] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[6].Value = objajustedlist.IsActiveALL;

                    arParms[7] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[7].Value = objajustedlist.UserId;

                    arParms[8] = new SqlParameter("@Duestatus", SqlDbType.VarChar);
                    arParms[8].Value = objajustedlist.Duestatus;



                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_SearchAjustedDetails ", arParms);
                    List<AjustedData> lstitemDetails = ORHelper<AjustedData>.FromDataReaderToList(sqlReader);
                    result = lstitemDetails;
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

        public int UpdateAjustedDetails(AjustedData objajutdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objajutdata.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[1].Value = objajutdata.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objajutdata.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objajutdata.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objajutdata.RollNo;

                    arParms[5] = new SqlParameter("@PaidAmount", SqlDbType.Money);
                    arParms[5].Value = objajutdata.PaidAmount;

                    arParms[6] = new SqlParameter("@PaidDate", SqlDbType.DateTime);
                    arParms[6].Value = objajutdata.PaidDate;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objajutdata.AddedBy;

                    arParms[8] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[8].Value = objajutdata.UserId;

                    arParms[9] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[9].Value = objajutdata.CompanyID;

                    arParms[10] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[10].Value = objajutdata.ActionType;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_UpdateAjustedAmount", arParms);
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

        public List<AjustedData> SearchFeeAjustedCollectoionDetails(AjustedData objfeeajustedlist)
        {
            List<AjustedData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objfeeajustedlist.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objfeeajustedlist.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objfeeajustedlist.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objfeeajustedlist.SectionID;

                    arParms[4] = new SqlParameter("@PaidRecieptNo", SqlDbType.VarChar);
                    arParms[4].Value = objfeeajustedlist.PaidRecieptNo;

                    arParms[5] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[5].Value = objfeeajustedlist.Datefrom;

                    arParms[6] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[6].Value = objfeeajustedlist.Dateto;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objfeeajustedlist.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objfeeajustedlist.CurrentIndex;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[9].Value = objfeeajustedlist.IsActive;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[10].Value = objfeeajustedlist.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_SearchFeeAjustedCollectionDetails ", arParms);
                    List<AjustedData> lstitemDetails = ORHelper<AjustedData>.FromDataReaderToList(sqlReader);
                    result = lstitemDetails;
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

        public int DeleteAjustedFeesByID(AjustedData objajustdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ACID", SqlDbType.Int);
                    arParms[0].Value = objajustdata.ACID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objajustdata.AcademicSessionID;

                    arParms[2] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[2].Value = objajustdata.StudentID;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objajustdata.Remarks;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[5].Value = objajustdata.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_DeleteAjustedFeeDetails", arParms);
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
    }
}
