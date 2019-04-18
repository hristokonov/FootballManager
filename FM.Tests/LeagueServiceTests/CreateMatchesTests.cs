using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Match = FM.Data.Models.Match;

namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
    public class CreateMatchesTests
    {
        // TODO
        [TestMethod]
        public void CreateMatches_IfLeagueHasMatches_ReturnCollectionOfMatches()
        {
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();
            var match = new Mock<Match>();
            var options = TestUtils.GetOptions(nameof(CreateMatches_IfLeagueHasMatches_ReturnCollectionOfMatches));
            var league = new League() { Name = "l" };
            var matchesMock = new List<Match>() { match.Object };
            handler.Setup(h => h.CreateMatches(league)).Returns(matchesMock);
            using (var arrangeContext= new FMDbContext(options))
            {
                arrangeContext.Leagues.Add(league);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);
                var matches = sut.CreateMatches("l");
                Assert.AreEqual(0, matches.Count());
            }
        }
    }
}
