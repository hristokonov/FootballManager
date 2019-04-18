using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
    public class CreateLeagueTests
    {
      

        [TestMethod]
        public void CreateLeague_IfLeagueIsReturned_ReturnLeague()
        {
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();
            using (var arrangeContext = new FMDbContext(TestUtils.GetOptions(nameof(CreateLeague_IfLeagueIsReturned_ReturnLeague))))
            {
                arrangeContext.Leagues.Add(new League() { Name = "League" });
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new FMDbContext(TestUtils.GetOptions(nameof(CreateLeague_IfLeagueIsReturned_ReturnLeague))))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);
                var ex = sut.CreateLeague("League1");
                var league = assertContext.Leagues.FirstOrDefault(l => l.Name == "League1");

                //Assert.IsInstanceOfType(ex, typeof(League));
                Assert.IsNotNull(league);
            }
        }
    }
}
