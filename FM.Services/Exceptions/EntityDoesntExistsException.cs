using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Exceptions
{
    public class EntityDoesntExistsException : Exception
    {
        public EntityDoesntExistsException(string message) : base(message)
        {

        }
    }
}
