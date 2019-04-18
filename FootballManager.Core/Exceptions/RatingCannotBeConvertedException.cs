using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core.Exceptions
{
     public class RatingCannotBeConvertedException : Exception
    {
        public RatingCannotBeConvertedException(string message) : base(message)
        {
                
        }
    }
}
