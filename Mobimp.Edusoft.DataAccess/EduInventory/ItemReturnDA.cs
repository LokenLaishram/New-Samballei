using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduInventory;

namespace Mobimp.Edusoft.DataAccess.EduInventory
{
    public class ItemReturnDA
    {       
        public List<ItemReturnData> GetItemDetailsByIssueNo(ItemReturnData objdata)
        {
            List<ItemReturnData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.IssueNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_itemreturn_getitemdetailsbyissueno", arParms);
                    List<ItemReturnData> lstDetails = ORHelper<ItemReturnData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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

        public List<ItemReturnData> SaveReturnItemList(ItemReturnData objdata)
        {
            List<ItemReturnData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[1].Value = objdata.IssueNo;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[2].Value = objdata.EmployeeID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objdata.AcademicSessionID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objdata.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_itemreturn_saveitemreturnlist", arParms);
                    List<ItemReturnData> lstDetails = ORHelper<ItemReturnData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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


        public List<ItemReturnData> GetItemReturnList(ItemReturnData objdata)
        {
            List<ItemReturnData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorTypeID;

                    arParms[1] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorID;

                    arParms[2] = new SqlParameter("@ReturnNo", SqlDbType.VarChar);
                    arParms[2].Value = objdata.ReturnNo;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objdata.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objdata.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_itemreturn_searchreturnitemdetails", arParms);
                    List<ItemReturnData> lstDetails = ORHelper<ItemReturnData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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

