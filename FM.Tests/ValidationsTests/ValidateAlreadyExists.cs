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
   public class ValidateAlreadyExists
    {
        [TestMethod]
        public void ObjectAlreadyExist()
        {
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var country = "Bulgaria";
            var owner = "Hristo Konov";
            var team = new Team()
            {
                Name = teamName,
                City = teamCity,
                Country = country,
                Owner = owner

            };
           
            var ex = Assert.ThrowsException<EntityAlreadyExistsException>(() 
                =>  Validations.ValidateAlreadyExists(team, "Team already exist"));
                   Assert.AreEqual(ex.Message, "Team already exist");


        }
    }
}
