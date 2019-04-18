using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FM.Tests.ManagerServiceTests
{
    [TestClass]
    public class HireManager_Should
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
            var team = new Mock<Team>();
            team.Object.Name = "Cunami";
            team.Object.City = "Sofia";
            team.Object.Id = 1;
            teamService.Setup(t => t.RetrieveTeam("Cunami", "Sofia")).Returns(team.Object);
            using (var arrangeContext = new FMDbContext(options))
            {
                var manager = new Manager()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Nationality = nationality,
                    TeamId=null
                };
                arrangeContext.Managers.Add(manager);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new ManagerService(assertContext, teamService.Object);
                var manager = sut.HireManager(firstName, lastName,"Cunami","Sofia");

                Assert.AreEqual( manager.FirstName,firstName);
                Assert.AreEqual(manager.LastName,lastName );
                Assert.AreEqual(manager.Id,1);

            }
        }
    }
}
