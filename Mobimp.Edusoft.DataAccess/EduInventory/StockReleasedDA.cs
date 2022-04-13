using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduInventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mobimp.Edusoft.DataAccess.EduInventory
{
    public class StockReleasedDA
    {
        public List<IndentSaleData> SearchPaidIndentDetailsList(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objdata.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@ReleasedStatusID", SqlDbType.Int);
                    arParms[8].Value = objdata.ReleasedStatusID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_release_searchapprovedindentlist", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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

        public List<IndentSaleData> GetItemDetailsByBillNo(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BillNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_released_getapproveditemdetailsbybillno", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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

        //---TAB2-SAVE STOCK RELEASED RECORD---//
        public List<IndentSaleData> SaveStockReleasedDetails(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@VendorName", SqlDbType.VarChar);
                    arParms[3].Value = objdata.VendorName;

                    arParms[4] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[4].Value = objdata.IndentNo;

                    arParms[5] = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    arParms[5].Value = objdata.BillNo;

                    arParms[6] = new SqlParameter("@GdTotalApprovedQty", SqlDbType.Int);
                    arParms[6].Value = objdata.GdTotalApprovedQty;

                    arParms[7] = new SqlParameter("@GdTotalReleasedQty", SqlDbType.Int);
                    arParms[7].Value = objdata.GdTotalReleasedQty;

                    arParms[8] = new SqlParameter("@GdTotalReleasedNow", SqlDbType.Int);
                    arParms[8].Value = objdata.GdTotalReleasedNow;

                    arParms[9] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[9].Value = objdata.Remark;

                    arParms[10] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[10].Value = objdata.CompanyID;

                    arParms[11] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[11].Value = objdata.EmployeeID;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objdata.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_released_savestockreleaseddetails", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        //--- TAB 3 ---//
        public List<IndentSaleData> SearchStockReleasedDetailsList(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@ReleasedNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ReleasedNo;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objdata.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@IsReleasedClosed", SqlDbType.Money);
                    arParms[8].Value = objdata.IsReleasedClosed;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[9].Value = objdata.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_released_searchreleaseddetails", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        public List<IndentSaleData> SearchChildStockReleasedDetails(IndentSaleData objdata)
        {
            List<IndentSaleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ReleasedNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ReleasedNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_released_searchchildreleaseddetails", arParms);
                    List<IndentSaleData> lstDetails = ORHelper<IndentSaleData>.FromDataReaderToList(sqlReader);
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
        public int DeleteStockReleasedByRNo(IndentSaleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ReleasedNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ReleasedNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_released_deletereleaseddetailsbyrno", arParms);
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
