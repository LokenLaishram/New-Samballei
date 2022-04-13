using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;

/****************************************************
  Description of the class	    : ErrorLog
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.Common.Logging
{
    public class ErorrLog
    {
        public int ErrorLineNumber
        {
            get;
            set;
        }

        public int ErrorSeverityNumber
        {
            get;
            set;
        }

        public int ErrorStateStatus
        {
            get;
            set;
        }

        public string ErrorMessageDetails
        {
            get;
            set;
        }

        public string ProcedureName
        {
            get;
            set;
        }

        public EnumErrorLogSourceTier LogSourceTier
        {
            get;
            set;
        }

        public ErorrLog(EnumErrorLogSourceTier LogSourceTier, int ErrorLineNumber, int ErrorSeverityNumber, int ErrorStateStatus, string ProcedureName, string ErrorMessageDetails)
        {
            this.ErrorLineNumber = ErrorLineNumber;
            this.ErrorSeverityNumber = ErrorSeverityNumber;
            this.ErrorStateStatus = ErrorStateStatus;
            this.ErrorMessageDetails = ErrorMessageDetails;
            this.ProcedureName = ProcedureName;
            this.LogSourceTier = LogSourceTier;
        }

        public ErorrLog(EnumErrorLogSourceTier LogSourceTier, string ErrorMessageDetails)
        {
            this.ErrorMessageDetails = ErrorMessageDetails;
            this.LogSourceTier = LogSourceTier;
        }
    }
    public enum EnumErrorLogSourceTier
    {
        Web = 1,
        BO = 2,
        DA = 3,
        DB=4
    }
}
