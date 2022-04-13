using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
/****************************************************
  Description of the class	    : DataAccessException
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.Common.ExceptionHandler
{
    [Serializable]
    public class DataAccessException : ApplicationException
    {
        // Default constructor 
        public DataAccessException()
            : base()
        {

        }
        //New 

        // Constructor with message 
        public DataAccessException(string message)
            : base(message)
        {
        }

       // Constructor with message, inner Exception 
        public DataAccessException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        // Protected constructor to de-serialize data 
        protected DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
