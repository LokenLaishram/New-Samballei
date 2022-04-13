using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.WebPortal;


namespace Mobimp.Edusoft.DataAccess.WebPortal
{
    public class DataSincDA
    {
        public string GetAllData(DataSincData objdatasinc)      
        {
            string result = "";
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objdatasinc.ClassID;                  

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objdatasinc.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objdatasinc.RollNo;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdatasinc.ExamID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objdatasinc.AcademicSessionID;

                    arParms[5] = new SqlParameter("@jsonOutput", SqlDbType.NVarChar,5000000);
                    arParms[5].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_get_WebPortal_AllData", arParms);
                    if (result_ > 0 || result_ == -1)
                       result = Convert.ToString(arParms[5].Value);
                  //  result = Convert.ToInt32(arParms[2].Value);
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
        public List<DataSincData> list(DataSincData objdatasinc)
        {
            List<DataSincData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];
                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objdatasinc.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objdatasinc.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objdatasinc.RollNo;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdatasinc.ExamID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objdatasinc.AcademicSessionID;

                    arParms[5] = new SqlParameter("@jsonOutput", SqlDbType.NVarChar, 500);
                    arParms[5].Direction = ParameterDirection.Output;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_get_WebPortal_Exam_StudentList", arParms);
                    List<DataSincData> list = ORHelper<DataSincData>.FromDataReaderToList(sqlReader);
                    result = list;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                throw ex;
            }
            return result;
        }


    }

}
