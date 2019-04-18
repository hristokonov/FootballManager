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
   public class RetrieveTeamRatings_Shoud
    {
        [TestMethod]
        public void ReturnsTeamRating()
        {
            //Arrange
            var playerService = new Mock<IPlayerService>();
            var options = TestUtils.GetOptions(nameof(ReturnsTeamRating));
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var country = "Bulgaria";
            var owner = "Hristo Konov";
            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.Rating = 100;
            var team = new Team()
            {
                Name = teamName,
                City = teamCity,
                Country = country,
                Owner = owner
            };
            playerService.Setup(p => p.RetrieveTeamPlayers(team))
                .Returns(new List<Player>() { player.Object });
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(team);
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
                var rating = sut.RetrieveTeamRatings(team);
                Assert.AreEqual(rating,100);
            }
        }


    }
}
