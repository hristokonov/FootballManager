using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Tests.ManagerServiceTests
{
    [TestClass]
    public class RetrieveManager_Should
    {
        [TestMethod]
        public void ReturnsManager()
        {
            //Arrange
            var teamService = new Mock<ITeamService>();
            var options = TestUtils.GetOptions(nameof(ReturnsManager));
            var firstName = "Hristo";
            var lastName = "Konov";
            var nationality = "Bulgarian";


            using (var arrangeContext = new FMDbContext(options))
            {
                var manager = new Manager()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Nationality = nationality
                };
                arrangeContext.Managers.Add(manager);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new ManagerService(assertContext, teamService.Object);
                var manager = sut.RetrieveManager(firstName, lastName);

                Assert.AreEqual( manager.FirstName, firstName);
                Assert.AreEqual(manager.LastName,lastName);
                Assert.AreEqual(manager.Nationality,nationality);
                
            }
        }
    }
}
