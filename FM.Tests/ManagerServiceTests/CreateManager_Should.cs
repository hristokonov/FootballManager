using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Tests.ManagerServiceTests
{   [TestClass]
    public class CreateManager_Should
    {
        [TestMethod]
        public void ReturnManager()
        {
            //Arrange
            var teamService = new Mock<ITeamService>();
            var options = TestUtils.GetOptions(nameof(ReturnManager));
            var firstName = "Hristo";
            var lastName = "Konov";
            var nationality = "Bulgarian";
           
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new ManagerService(assertContext, teamService.Object);
                var manager= sut.CreateManager(firstName,lastName,nationality);

                Assert.AreEqual(manager.FirstName,firstName);
                Assert.AreEqual(manager.LastName,lastName);
                Assert.AreEqual(manager.Nationality,nationality);
                Assert.AreEqual(1,assertContext.Managers.Count());
            }
        }
        
    }
}
