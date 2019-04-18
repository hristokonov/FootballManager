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
    public class RetrieveTeam_Should
    {
        [TestMethod]
        public void ReturnsTeam()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnsTeam));
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var country = "Bulgaria";
            var owner = "Hristo Konov";
            var manager = new Manager()
            {
                FirstName = "Hristo",
                LastName = "Konov",
                Nationality = "Bulgarian",
                TeamId = 1
            };
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team()
                {
                    Name = teamName,
                    City = teamCity,
                    Country = country,
                    Owner = owner,
                    Id=1
                });
                arrangeContext.Managers.Add(manager);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                var sut = new TeamService(arrangeContext, playerService.Object);
                var team = sut.RetrieveTeam(teamName, teamCity);
                
                Assert.AreEqual(team.Name,teamName);
                Assert.AreEqual(team.City,teamCity);
                Assert.AreEqual(team.Country,country);
                Assert.AreEqual(team.Owner,owner);
                Assert.AreEqual(1,arrangeContext.Teams.Count());
                Assert.AreEqual(team.Manager.FirstName,manager.FirstName);
                Assert.AreEqual(team.Manager.LastName,manager.LastName);
            }
        }
        [TestMethod]
        public void ReturnsNoTeam()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnsNoTeam));
            var teamName = "Cunami";
            var teamCity = "Sofia";
           
            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                var sut = new TeamService(arrangeContext, playerService.Object);
                var team = sut.RetrieveTeam(teamName, teamCity);

                Assert.IsNull(team);
              
            }
        }
    }
}
