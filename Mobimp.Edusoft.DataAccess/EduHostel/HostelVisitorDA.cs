using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using System.Data;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Campusoft.Data.EduHostel;

namespace Mobimp.Campusoft.DataAccess.EduHostel
{
    public class HostelVisitorDA
    {
        public int UpdateHostelVisitor(HostelVisitorData objreg)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.ID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objreg.StudentID;

                    arParms[2] = new SqlParameter("@RegistrationNo", SqlDbType.BigInt);
                    arParms[2].Value = objreg.RegistrationNo;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objreg.ClassID;

                    arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[4].Value = objreg.ActionType;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objreg.AcademicSessionID;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objreg.AddedBy;

                    arParms[8] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[8].Value = objreg.IsActive;
                
                    arParms[9] = new SqlParameter("@VisitDate", SqlDbType.Date);
                    arParms[9].Value = objreg.VisitDate;

                    arParms[10] = new SqlParameter("@VisitPurpose", SqlDbType.VarChar);
                    arParms[10].Value = objreg.VisitPurpose;

                    arParms[11] = new SqlParameter("@VisitName", SqlDbType.VarChar);
                    arParms[11].Value = objreg.VisitorName;

                    arParms[12] = new SqlParameter("@VisitTime", SqlDbType.VarChar);
                    arParms[12].Value = objreg.VisitTime;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Fee_UpdateHostelVisitor", arParms);
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
        public List<HostelVisitorData> SearchHostelVisitor(HostelVisitorData objreg)
        {
            List<HostelVisitorData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objreg.StudentID;

                    arParms[1] = new SqlParameter("@RegistrationNo", SqlDbType.BigInt);
                    arParms[1].Value = objreg.RegistrationNo;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objreg.AcademicSessionID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objreg.IsActive;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objreg.ClassID;

                    arParms[5] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[5].Value = objreg.SectionID;

                    arParms[6] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[6].Value = objreg.RollNo;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objreg.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objreg.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SearchHostelVisitor", arParms);
                    List<HostelVisitorData> lstHostelRegistration = ORHelper<HostelVisitorData>.FromDataReaderToList(sqlReader);
                    result = lstHostelRegistration;
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
