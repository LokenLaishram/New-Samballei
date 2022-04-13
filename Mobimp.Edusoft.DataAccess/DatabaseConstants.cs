using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobimp.Edusoft.DataAccess
{

    internal static class CommonConstants
    {
        internal static class Parameters
        {
            public const string CurrentIndex = "@CurrentIndex";
            public const string PageSize = "@PageSize";

            public const string FinancialYearID = "@FinancialYearID";
            public const string CompanyID = "@CompanyID";

            public const string IsActive = "@IsActive";
            public const string AddedBy = "@AddedBy ";
            public const string AddedDTM = "@AddedDTM";
            public const string LastModBy = "@LastModBy";
            public const string LastModDTM = "@LastModDTM";
            public const string ActionType = "@ActionType";
            public const string IsExist = "@IsExist";
        }
    }
    #region Lookups Constants of database
    internal static class LookupConstants
    {
        internal static class StoreProcedures
        {
            public const string GetMasterLookup = "usp_GetMasterLookup";
            public const string SaveLookupMaster = "usp_SaveLookupMST";
            public const string UpdateLookupMaster = "usp_UpdateLookupMST";
            public const string GetPagedMasterLookup = "usp_GetPagedMasterLookup";
            public const string GetLookupItemByID = "usp_GetLookupItemByID";
        }

        internal static class Parameters
        {
            public const string LookupsName = "@LookupsName";
            public const string ItemId = "@ItemId";
            public const string ItemId1 = "@ItemId1";
            public const string ItemCode = "@ItemCode";
            public const string ItemName = "@ItemName";
            public const string ShortDescription = "@ShortDescription";
            public const string LongDescription = "@LongDescription";
        }
    }
    #endregion

}
