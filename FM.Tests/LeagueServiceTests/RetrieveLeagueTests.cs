using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
    public class RetrieveLeagueTests
    {
        [TestMethod]
        public void RetrieveLeague_WhenExecuted_ReturnLeague()
        {
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();
             var options = TestUtils.GetOptions(nameof(RetrieveLeague_WhenExecuted_ReturnLeague));
            using (var arrangeContext = new FMDbContext(options))
            {
                var league = new League() { Name = "League" };
                arrangeContext.Leagues.Add(league);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);
                var ex = sut.RetrieveLeague("League");
                Assert.IsInstanceOfType(ex, typeof(League));
            }
        }

        [TestMethod]
        public void RetrieveLeague_WhenExecuted_FirstOrDefaultReturnNull()
        {
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();
            using (var arrangeContext = new FMDbContext(TestUtils.GetOptions(nameof(RetrieveLeague_WhenExecuted_FirstOrDefaultReturnNull))))
            {
                arrangeContext.Leagues.Add(new League() { Name = "League" });
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new FMDbContext(TestUtils.GetOptions(nameof(RetrieveLeague_WhenExecuted_FirstOrDefaultReturnNull))))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);
                var res = sut.RetrieveLeague("L");
                Assert.IsNull(res);
            }
        }
    }
}
