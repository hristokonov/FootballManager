using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
   public class ShowAllLeaguesTest
    {
        [TestMethod]
        public void ReturnsLeagues()
        {
            //Arrange

            var service = new Mock<TeamService>();
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();
            var options = TestUtils.GetOptions(nameof(ReturnsLeagues));
            using (var arrangeContext = new FMDbContext(options))
            {
                var league = new League()
                {
                    Name = "Test",
                    Id = 1
                };
                arrangeContext.Leagues.Add(league);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object,handler.Object);
                var leagues = sut.ShowAllLeagues().ToList();
                Assert.AreEqual(leagues.Count(),1);
                Assert.AreEqual(leagues[0].Name, "Test");
            }
        }
    }
}
