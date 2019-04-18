using FM.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Services
{
    public static class Validations
    {
        public static void ValidateAlreadyExists(object obj,string message)
        {
            if (obj != null)
            {
                throw new EntityAlreadyExistsException(message);
            }

        }
        public static void ValidateDoesntExists(object obj, string message)
        {
            if (obj==null)
            {
                throw new EntityDoesntExistsException(message);
            }
        }
        public static void ValidateCollectionZero(IEnumerable<object> list, string message)
        {
            if (list.Count()==0)
            {
                throw new ZeroCollectionException(message);
            }
        }
    }
}
