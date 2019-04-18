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
    public class ResetTeamDataTest
    {
        [TestMethod]
        public void ResetTeamData_ResetGoalDifference_ReturnZero()
        {
            var team = new Mock<Team>();
            team.SetupAllProperties();
            team.Object.GoalDifference = 1;
            
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();

            var options = TestUtils.GetOptions(nameof(ResetTeamData_ResetGoalDifference_ReturnZero));

            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);

                sut.ResetTeamData(team.Object);

                Assert.AreEqual(team.Object.GoalDifference, 0);
            }
        }

        [TestMethod]
        public void ResetTeamData_ResetGoalsScored_ReturnZero()
        {
            var team = new Mock<Team>();
            team.SetupAllProperties();
            team.Object.GoalsScored = 1;
            
            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();

            var options = TestUtils.GetOptions(nameof(ResetTeamData_ResetGoalsScored_ReturnZero));

            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);

                sut.ResetTeamData(team.Object);

                Assert.AreEqual(team.Object.GoalsScored, 0);
            }
        }

        [TestMethod]
        public void ResetTeamData_ResetGoalsConcede_ReturnZero()
        {
            var team = new Mock<Team>();
            team.SetupAllProperties();
            
            team.Object.GoalsConcede = 1;

            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();

            var options = TestUtils.GetOptions(nameof(ResetTeamData_ResetGoalsConcede_ReturnZero));

            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);

                sut.ResetTeamData(team.Object);

                Assert.AreEqual(team.Object.GoalsConcede, 0);
            }
        }

        [TestMethod]
        public void ResetTeamData_ResetPoints_ReturnZero()
        {
            var team = new Mock<Team>();
            team.SetupAllProperties();
            team.Object.Points = 1;

            var teamService = new Mock<ITeamService>();
            var handler = new Mock<IMatchHandler>();

            var options = TestUtils.GetOptions(nameof(ResetTeamData_ResetPoints_ReturnZero));

            using (var assertContext = new FMDbContext(options))
            {
                var sut = new LeagueService(assertContext, teamService.Object, handler.Object);

                sut.ResetTeamData(team.Object);

                Assert.AreEqual(team.Object.Points, 0);
            }
        }
    }
}
