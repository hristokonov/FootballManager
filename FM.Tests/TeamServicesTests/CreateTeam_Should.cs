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

namespace FM.Tests.TeamServices
{
    [TestClass]
   public class CreateTeam_Should
    {
       
        [TestMethod]
        public void ReturnAndCreateTeam()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnAndCreateTeam));
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var country = "Bulgaria";
            var owner = "Hristo Konov";

            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                var sut = new TeamService(arrangeContext, playerService.Object);
                var team = sut.CreateTeam(teamName, teamCity, country, owner);
              
                Assert.AreEqual(team.Name,teamName);
                Assert.AreEqual(team.City,teamCity);
                Assert.AreEqual(team.Country,country );
                Assert.AreEqual(team.Owner,owner);
                Assert.AreEqual(1,arrangeContext.Teams.Count());
            }
        }
    }
}
