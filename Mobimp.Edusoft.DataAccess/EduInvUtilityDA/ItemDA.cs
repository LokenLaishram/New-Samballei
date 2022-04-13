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
using Mobimp.Edusoft.Data.EduInvUtility;

namespace Mobimp.Edusoft.DataAccess.EduInvUtilityDA
{
    public class ItemDA
    {
        public int SaveItemData(ItemData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objdata.Itemid;

                    arParms[1] = new SqlParameter("@Groupid", SqlDbType.VarChar);
                    arParms[1].Value = objdata.Groupid;

                    arParms[2] = new SqlParameter("@Subgroupid", SqlDbType.VarChar);
                    arParms[2].Value = objdata.Subgroupid;

                    arParms[3] = new SqlParameter("@Itemname", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Itemname;

                    arParms[4] = new SqlParameter("@UnitID", SqlDbType.Int);
                    arParms[4].Value = objdata.UnitID;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objdata.CompanyID;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objdata.ActionType;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objdata.AcademicSessionID;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[9].Value = objdata.IsActive;

                    arParms[10] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[10].Value = objdata.EmployeeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_UpdateItemMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[7].Value);
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
        public List<ItemData> SearchItem(ItemData objitem)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objitem.Itemid;

                    arParms[1] = new SqlParameter("@Itemname", SqlDbType.VarChar);
                    arParms[1].Value = objitem.Itemname;

                    arParms[2] = new SqlParameter("@Groupid", SqlDbType.Int);
                    arParms[2].Value = objitem.Groupid;

                    arParms[3] = new SqlParameter("@Subgroupid", SqlDbType.Int);
                    arParms[3].Value = objitem.Subgroupid;

                    arParms[4] = new SqlParameter("@UnitID", SqlDbType.Int);
                    arParms[4].Value = objitem.UnitID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objitem.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objitem.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objitem.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchItemMST", arParms);
                    List<ItemData> lstDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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
        public List<ItemPriceData> SearchItempricelist(ItemPriceData objitem)
        {
            List<ItemPriceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objitem.Itemid;

                    arParms[1] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[1].Value = objitem.YearID;

                    arParms[2] = new SqlParameter("@YearName", SqlDbType.VarChar);
                    arParms[2].Value = objitem.YearName;

                    arParms[3] = new SqlParameter("@Groupid", SqlDbType.Int);
                    arParms[3].Value = objitem.Groupid;

                    arParms[4] = new SqlParameter("@Subgroupid", SqlDbType.Int);
                    arParms[4].Value = objitem.Subgroupid;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objitem.IsActive;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objitem.AcademicSessionID;

                    arParms[7] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[7].Value = objitem.EmployeeID;

                    arParms[8] = new SqlParameter("@ItemPriceID", SqlDbType.Int);
                    arParms[8].Value = objitem.ItemPriceID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchItemPriceMST", arParms);
                    List<ItemPriceData> lstDetails = ORHelper<ItemPriceData>.FromDataReaderToList(sqlReader);
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
        public List<ItemData> GetItembyID(ItemData objdata)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objdata.Itemid;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_EditItemMST", arParms);
                    List<ItemData> lstDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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
        public int DeleteItembyID(ItemData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objdata.Itemid;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objdata.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_DeleteActivateItemMST", arParms);
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
        public int Updateitemprice(ItemPriceData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.AcademicSessionID;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[2].Value = objdata.EmployeeID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@Groupid", SqlDbType.Int);
                    arParms[4].Value = objdata.Groupid;

                    arParms[5] = new SqlParameter("@Subgroupid", SqlDbType.Int);
                    arParms[5].Value = objdata.Subgroupid;

                    arParms[6] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[6].Value = objdata.YearID;

                    arParms[7] = new SqlParameter("@YearName", SqlDbType.VarChar);
                    arParms[7].Value = objdata.YearName;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_UpdateItemPriceMST", arParms);
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
        public int Activate(ItemData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@Itemid", SqlDbType.Int);
                    arParms[0].Value = objgrp.Itemid;

                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objgrp.ActionType;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objgrp.Remark;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_DeleteActivateItemMST", arParms);
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
        public List<ItemPriceData> GetAutoItemDetails(ItemPriceData objdata)
        {
            List<ItemPriceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ItemDetails", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ItemDetails;
                    arParms[1] = new SqlParameter("@Subgroupid", SqlDbType.Int);
                    arParms[1].Value = objdata.Subgroupid;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_util_autocompleteItemDetail", arParms);
                    List<ItemPriceData> lstDetails = ORHelper<ItemPriceData>.FromDataReaderToList(sqlReader);
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
