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
    public class AddTeamToLeagueTest
    {     
        //[TestMethod]
        //public void AddTeamToLeague_IfTeamLeagueIdEqualsToLeagueId_ReturnLeagueId()
        //{
        //    var teamService = new Mock<ITeamService>();
        //    var handler = new Mock<IMatchHandler>();
            
        //    var options = TestUtils.GetOptions(nameof(AddTeamToLeague_IfTeamLeagueIdEqualsToLeagueId_ReturnLeagueId));

        //    var team = new Mock<Team>();
        //    team.SetupAllProperties();
        //    team.Object.City = "c";
        //    team.Object.LeagueId = 1;
        //    team.Object.Name = "tn";

        //    teamService.Setup(t => t.RetrieveTeam(team.Object.Name, team.Object.City)).Returns(team.Object);
 
        //     var league = new League()
        //    {
        //        Id = 1,
        //        Name = "ln"
        //    };
        //    using (var context = new FMDbContext(options))
        //    {
        //        //context.Teams.Add(new Team() { Name = "t1", City = "tc", Budget = 50, Id = 1 });
        //        context.Leagues.Add(league);
        //        context.SaveChanges();
        //    }
        //    using (var context = new FMDbContext(options))
        //    {
        //        var sut = new LeagueService(context, teamService.Object, handler.Object);
        //        var res = sut.AddTeamToLeague("a", "c", "l");
        //        Assert.AreEqual(res.Id, team.Object.LeagueId);
        //    }
        //}
        
    }
}
