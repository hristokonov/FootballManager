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
    public class ValidateCollectionZero
    {
        [TestMethod]
     public void CollectionIsZero()
        {
            var teams = new List<Team>();
            var ex = Assert.ThrowsException<ZeroCollectionException>(()
              => Validations.ValidateCollectionZero(teams, "Collection count is zero"));
            Assert.AreEqual(ex.Message, "Collection count is zero");
        }
    }
}
