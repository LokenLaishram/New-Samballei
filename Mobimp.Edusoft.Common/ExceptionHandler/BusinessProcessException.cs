using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
/****************************************************
  Description of the class	    : BusinessProcessException
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/

namespace Mobimp.Edusoft.Common.ExceptionHandler
{
    [Serializable]
    public class BusinessProcessException : ApplicationException
    {
        // Default constructor 
        public BusinessProcessException()
            : base()
        {

        }
        //New 

        // Constructor with message 
        public BusinessProcessException(string message)
            : base(message)
        {
        }


        // Constructor with message, inner Exception 
        public BusinessProcessException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        // Protected constructor to de-serialize data 
        protected BusinessProcessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
