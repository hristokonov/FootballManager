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


namespace FM.Tests.LeagueServiceTests
{
    [TestClass]
    public class ShowRable_Should
    {
       // [TestMethod]
        //public void ReturnsTeams()
        //{
        //    //Arrange
        //    var service = new Mock<TeamService>();
        //    var teamService = new Mock<ITeamService>();
        //    var handler = new Mock<IMatchHandler>();
        //    var options = TestUtils.GetOptions(nameof(ReturnsTeams));
        //    var leagueName = "Test";
        //    var team = new Mock<Team>();
        //    team.Object.Name = "Cunami";
        //    var league = new League()
        //    {
        //        Name = leagueName,
        //        Id = 1,
        //        Teams= new List<Team>() { team.Object }

        //    };
        //    teamService.Setup(p => p.RetrieveLeagueTeams(league)).Returns(new List<Team>() { team.Object });

        //    using (var arrangeContext = new FMDbContext(options))
        //    {
        //        arrangeContext.Leagues.Add(league);
        //        arrangeContext.SaveChanges();
        //    }
        //    //Act,Assert
        //    using (var assertContext = new FMDbContext(options))
        //    {
        //        var sut = new LeagueService(assertContext, teamService.Object, handler.Object);
        //        var leagues = sut.ShowTable(leagueName);
        //        Assert.AreEqual(1, leagues.Count());
        //    }
        //}
    }
}
