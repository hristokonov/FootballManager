using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Exceptions
{
   public class ZeroCollectionException :Exception
    {
        public ZeroCollectionException(string message) : base(message)
        {

        }
    }
}
