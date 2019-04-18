using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Tests.ValidationsTests
{
    [TestClass]
   public class ValidateDoesntExists
    {
        [TestMethod]
        public void ObjectDoesntExist()
        {
            var ex = Assert.ThrowsException<EntityDoesntExistsException>(()
                => Validations.ValidateDoesntExists(null, "Object doesnt exist"));
            Assert.AreEqual(ex.Message, "Object doesnt exist");
        }
    }
}
