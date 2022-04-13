using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web;
/****************************************************
  Description of the class	    : DataAccessObjectBase
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.DataAccess
{
    public class DataAccessObjectBase
    {
        static IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        public DateTime SQL_DateTimeMininum = DateTime.Parse("01/01/1753", provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
        public DateTime SQL_DateTimeMaximum = DateTime.Parse("31/12/9999", provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

    }
}
