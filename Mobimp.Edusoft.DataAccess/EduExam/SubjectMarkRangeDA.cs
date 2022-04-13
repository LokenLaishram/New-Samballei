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

namespace Mobimp.Edusoft.DataAccess.EduExam
{
    public class SubjectMarkRangeDA
    {
        public List<Examdata> GetMarkList(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.RollNo;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.AcademicSessionID;

                    arParms[4] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.ExamID;

                    arParms[5] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.SubjectID;

                    arParms[6] = new SqlParameter("@From", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.From;

                    arParms[7] = new SqlParameter("@To", SqlDbType.Int);
                    arParms[7].Value = objexamsubject.To;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetSubjectMarkRange", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
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
    }
}
