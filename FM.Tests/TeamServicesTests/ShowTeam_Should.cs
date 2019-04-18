using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Tests.TeamServices
{
    [TestClass]
    public class ShowTeam_Should
    {
        [TestMethod]
        public void ReturnTeam()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnTeam));
            var teamName = "Cunami";
            var teamCity = "Sofia";
            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity });
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
               var team= sut.ShowTeam(teamName, teamCity);
                Assert.AreEqual(team.Name,teamName);
                Assert.AreEqual(team.City,teamCity);

            }
        }
    }
}
