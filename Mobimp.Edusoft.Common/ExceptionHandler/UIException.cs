using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
/****************************************************
  Description of the class	    : UIException.cs
  Created Date					: 28-09-2014
  Developer						: Loken
  Modify Date					: 
  Modified By Developer			: 
  Comments						: ()
  ***************************************************/
namespace Mobimp.Edusoft.Common.ExceptionHandler
{
    [Serializable]
    public class UIException : ApplicationException
    {
        // Default constructor 
        public UIException()
            : base()
        {

        }
        //New 

        // Constructor with message 
        public UIException(string message)
            : base(message)
        {
        }


        // Constructor with message, inner Exception 
        public UIException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        // Protected constructor to de-serialize data 
        protected UIException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
