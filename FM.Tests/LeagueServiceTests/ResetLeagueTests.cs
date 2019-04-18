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
    public class ResetLeagueTests
    {
       //// TODO
       //[TestMethod]
       // public void ResetLeague_IfMatchDoNotExists_ThrowZeroCollectionException()
       // {
       //     var teamService = new Mock<ITeamService>();
       //     var handler = new Mock<IMatchHandler>();

       //     var options = TestUtils.GetOptions(nameof(ResetLeague_IfMatchDoNotExists_ThrowZeroCollectionException));

       //     using (var context = new FMDbContext(options))
       //     {
       //         var league = new League();
       //         league.Id = 1;
       //         league.Name = "a";

       //         context.Leagues.Add(league);
       //         context.SaveChanges();
       //     }
       //     using (var context = new FMDbContext(options))
       //     {
       //         var sut = new LeagueService(context, teamService.Object, handler.Object);

       //         var res = sut.ResetTeams("а");
       //     }
       // }
    }
}
