using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/****************************************************
  Description of the class	    : BaseData
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/

namespace Mobimp.Edusoft.DataAccess
{
    #region Detail section
    [Serializable]
    public class BaseData
    {
        public short FinancialYearID { get; set; }
        public short CompanyID { get; set; }
        public bool IsActive { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDTM { get; set; }
        public string LastModBy { get; set; }
        public DateTime LastModDTM { get; set; }
        public int CurrentIndex { get; set; }
        public int PageSize { get; set; }
        public int MaximumRows { get; set; }
        public string XMLData { get; set; }
        public int LocationID { get; set; }

    }
    #endregion
}
