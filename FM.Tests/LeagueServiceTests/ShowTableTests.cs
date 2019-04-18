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
    public class ShowTableTests
    {
        
        //// TODO
        //[TestMethod]
        //public void ShowTable_IfLeagueDoNotContainsTeams_ThrowZeroCollectionException()
        //{
        //    var teamService = new Mock<ITeamService>();
        //    var handler = new Mock<IMatchHandler>();
        //    var league = new League()
        //    {
        //     Name = "a",
        //    Id = 1
        //   };
        //    var team = new Mock<Team>();
        //    team.Object.Name = "Cunami";
        //    team.Object.LeagueId = 1;
        //    var teams = new List<Team>() { team.Object };
        //    var options = TestUtils.GetOptions(nameof(ShowTable_IfLeagueDoNotContainsTeams_ThrowZeroCollectionException));
        //    teamService.Setup(t => t.RetrieveLeagueTeams(league))
        //        .Returns(teams);
        //    using (var context = new FMDbContext(options))
        //    {
               
        //        //var team = new Team();
        //        //team.Name = "tn";
        //        //team.LeagueId = 1;

        //        context.Leagues.Add(league);
        //        context.SaveChanges();
        //    }

        //    using (var context = new FMDbContext(options))
        //    {

        //        var sut = new LeagueService(context, teamService.Object, handler.Object);
        //        var res = sut.ShowTable("a").ToList();

        //        Assert.AreEqual(1, res.Count());
        //        //Assert.ThrowsException<EntityDoesntExistsException>(() => res.Count() == 0);
        //    }
        //}
    }
}
