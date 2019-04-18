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
using Match = FM.Data.Models.Match;

namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
    public class ShowMatchesTests
    {
        [TestMethod]
        public void ShowMatches_IfLeagueDoesntExists_ThrowEntityDoesntExistsException()
        {
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();

            var options = TestUtils.GetOptions(nameof(ShowMatches_IfLeagueDoesntExists_ThrowEntityDoesntExistsException));
            using (var context = new FMDbContext(options))
            {
                var league = new League();
                league.Name = "Primera";
                context.Leagues.Add(league);
                context.SaveChanges();
            }

            using (var context = new FMDbContext(options))
            {
                var sut = new LeagueService(context, teamService.Object, handler.Object);

                Assert.ThrowsException<EntityDoesntExistsException>(() => sut.ShowAllMatches("Premier"));
            }
        }

    }
}
