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
  Description of the class	    : LogManager
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.Common.Logging
{
    public class LogSource
    {
        public string Message = "";
        public EnumLogCategory LogCategory;
        public EnumPriority Priority;
        public EnumLogEvenType EventType;
        public string Title = "";
        public object Sender = null;
        public string ClassName = "";


        public LogSource(object sender, string message, EnumLogCategory logCategory, EnumPriority priority, EnumLogEvenType eventType)
        {
            this.Sender = sender;
            this.Message = message;
            this.LogCategory = logCategory;
            this.Priority = priority;
            this.EventType = eventType;

        }

        public LogSource(string className, string message, EnumLogCategory logCategory, EnumPriority priority, EnumLogEvenType eventType)
        {
            this.ClassName = className;
            this.Message = message;
            this.LogCategory = logCategory;
            this.Priority = priority;
            this.EventType = eventType;

        }

    }
    public enum EnumPriority
    {
        High = 0,
        Low = 1,
    }
    public enum EnumLogCategory
    {
        UIEvents = 0,
        ServiceAgentEvents = 1,
        BusinessProcessEvents = 2,
        DataAccessEvents = 3,
        ServiceEvents = 4,
        Debug = 5,
        Troubleshooting = 6,
    }
    public enum EnumLogEvenType
    {
        Error = 0,
        Warning = 1,
        Information = 2,

    }
}
