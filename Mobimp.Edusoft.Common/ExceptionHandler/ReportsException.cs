using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
/****************************************************
  Description of the class	    : ReportsException.cs
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/

namespace Mobimp.Edusoft.Common.ExceptionHandler
{
    [Serializable]
    public class ReportsException : ApplicationException
    {
        // Default constructor 
        public ReportsException()
            : base()
        {

        }
        //New 

        // Constructor with message 
        public ReportsException(string message)
            : base(message)
        {
        }


        // Constructor with message, inner Exception 
        public ReportsException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        // Protected constructor to de-serialize data 
        protected ReportsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
