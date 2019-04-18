using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Exceptions
{
    public class MatchPlayedException :Exception
    {
        public MatchPlayedException(string message):base(message)
        {

        }
    }
}
