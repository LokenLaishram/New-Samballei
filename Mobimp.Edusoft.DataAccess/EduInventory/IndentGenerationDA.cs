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
    public class IndentGenerationDA
    {
        public List<IndentGenerationData> GetAutoAllVendorNameByVendorType(IndentGenerationData objint)
        {

            List<IndentGenerationData> result = null;
           
            return result;
        }
        public List<IndentGenerationData> SaveIndentGeneration(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@VendorName", SqlDbType.VarChar);
                    arParms[3].Value = objdata.VendorName;

                    arParms[4] = new SqlParameter("@GdTotalIndentQty", SqlDbType.Int);
                    arParms[4].Value = objdata.GdTotalIndentQty;

                    arParms[5] = new SqlParameter("@GdTotalPrice", SqlDbType.Money);
                    arParms[5].Value = objdata.GdTotalPrice;

                    arParms[6] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[6].Value = objdata.Remark;

                    arParms[7] = new SqlParameter("@Discount", SqlDbType.Money);
                    arParms[7].Value = objdata.Discount;

                    arParms[8] = new SqlParameter("@DiscountValue", SqlDbType.Money);
                    arParms[8].Value = objdata.DiscountValue;

                    arParms[9] = new SqlParameter("@FormPrice", SqlDbType.Money);
                    arParms[9].Value = objdata.FormPrice;

                    arParms[10] = new SqlParameter("@Payable", SqlDbType.Money);
                    arParms[10].Value = objdata.Payable;

                    arParms[11] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[11].Value = objdata.EmployeeID;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objdata.AcademicSessionID;

                    arParms[13] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[13].Value = objdata.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_saveindentgendetail", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public List<IndentGenerationData> GetVendorDetailsByID(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorID;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_getvendordetailsbyid", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public List<IndentGenerationData> GetAutoItembySubGroupid(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ItemName", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ItemName;

                    arParms[1] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[1].Value = objdata.SubGroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_indent_GetAutoItembySubGroupid", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public List<IndentGenerationData> GetItemDetailsByID(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@StockNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.StockNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_indent_getitemdetailsbyid", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public List<IndentGenerationData> GetItemDetailsBySubGroup(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[0].Value = objdata.GroupID;

                    arParms[1] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[1].Value = objdata.SubGroupID;

                    arParms[2] = new SqlParameter("@BatchYearID", SqlDbType.Int);
                    arParms[2].Value = objdata.BatchYearID;

                    arParms[3] = new SqlParameter("@YearName", SqlDbType.VarChar);
                    arParms[3].Value = objdata.YearName;

                    arParms[4] = new SqlParameter("@StockNo", SqlDbType.VarChar);
                    arParms[4].Value = objdata.StockNo;

                    arParms[5] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[5].Value = objdata.ItemID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_getitemdetailsbysubgroup", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        //--Tab2--/
        public List<IndentGenerationData> SearchIndentDetailsList(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@IsApproved", SqlDbType.Int);
                    arParms[0].Value = objdata.IsApproved;

                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;

                    arParms[2] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[2].Value = objdata.VendorID;

                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objdata.Dateto;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objdata.CurrentIndex;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objdata.PageSize;

                    arParms[8] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[8].Value = objdata.IndentNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_searchindentgenlist", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public List<IndentGenerationData> SearchChildIndentDetails(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.IndentNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_searchchildindentgendetail", arParms);
                    List<IndentGenerationData> lstDetails = ORHelper<IndentGenerationData>.FromDataReaderToList(sqlReader);
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
        public int DeleteIndentGenbyIndentNo(IndentGenerationData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@IndentNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.IndentNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_indent_deleteindentgenbyindentno", arParms);
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
