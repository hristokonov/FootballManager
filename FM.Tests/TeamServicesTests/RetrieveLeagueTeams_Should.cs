using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Tests.TeamServices
{
    [TestClass]
   public class RetrieveLeagueTeams_Should
    {
        [TestMethod]
        public void ReturnsTeams()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnsTeams));
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var country = "Bulgaria";
            var owner = "Hristo Konov";
            var league = new League()
            {
                Name = "Test",
                Id = 1
            };
            var team = new Team()
            {
                Name = teamName,
                City = teamCity,
                Country = country,
                Owner = owner,
                LeagueId = 1
                
            };
           
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Leagues.Add(league);
                arrangeContext.Teams.Add(team);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
                var teams = sut.RetrieveLeagueTeams(league);
                Assert.AreEqual(1, teams.Count);
                Assert.AreEqual(teamName,teams[0].Name );
                Assert.AreEqual(teamCity,teams[0].City);
                
            }
        }

    }
}
