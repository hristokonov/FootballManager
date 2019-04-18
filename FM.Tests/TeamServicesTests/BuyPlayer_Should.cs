using FM.Data.Context;
using FM.Data.Models;
using FM.Services;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Tests.TeamServices
{
   [TestClass]
   public class BuyPlayer_Should
    {
        [TestMethod]
        public void Throws_PlayerAlreadyRetired()
        {
            //Arrange
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var firstName = "Hristo";
            var lastName = "Konov";
            var playerService = new Mock<IPlayerService>();
            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.FirstName = firstName;
            player.Object.LastName = lastName;
            player.Object.IsDeleted = true;
            var options = TestUtils.GetOptions(nameof(Throws_PlayerAlreadyRetired));
            playerService.Setup(p => p.RetrievePlayer(firstName, lastName)).Returns(player.Object);//new List<Match>(){match.Object} 
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity });
                
                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
                var ex = Assert.ThrowsException<EntityDoesntExistsException>(() => sut.BuyPlayer(teamName, teamCity, firstName, lastName));
                Assert.AreEqual(ex.Message,"Player already retired");
            }
        }
        [TestMethod]
        public void Throws_PlayerAlreadyHasTeam()
        {
            //Arrange
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var firstName = "Hristo";
            var lastName = "Konov";
            var playerService = new Mock<IPlayerService>();

            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.FirstName = firstName;
            player.Object.LastName = lastName;
            player.Object.IsDeleted = false;
            player.Object.TeamId = 1;
            var options = TestUtils.GetOptions(nameof(Throws_PlayerAlreadyHasTeam));
            playerService.Setup(p => p.RetrievePlayer(firstName, lastName)).Returns(player.Object);
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity });

                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
                var ex = Assert.ThrowsException<EntityAlreadyExistsException>(() => sut.BuyPlayer(teamName, teamCity, firstName, lastName));
                Assert.AreEqual(ex.Message,"Player already has a team");
            }
        }
        [TestMethod]
        public void Throws_TeamDoesntHaveMoneyToBuyPlayer()
        {
            //Arrange
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var firstName = "Hristo";
            var lastName = "Konov";
            var playerService = new Mock<IPlayerService>();

            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.FirstName = firstName;
            player.Object.LastName = lastName;
            player.Object.IsDeleted = false;
            player.Object.TeamId = null;
            player.Object.Price = 20;
            var options = TestUtils.GetOptions(nameof(Throws_TeamDoesntHaveMoneyToBuyPlayer));
            playerService.Setup(p => p.RetrievePlayer(firstName, lastName)).Returns(player.Object);
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity ,Budget=0});

                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var assertContext = new FMDbContext(options))
            {
                var sut = new TeamService(assertContext, playerService.Object);
                var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.BuyPlayer(teamName, teamCity, firstName, lastName));
                Assert.AreEqual(ex.ParamName,$"Team doesn't have enogh money to buy {firstName} {lastName}");

            }
        }
        [TestMethod]
        public void PlayerChangesTeamID()
        {
            //Arrange
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var firstName = "Hristo";
            var lastName = "Konov";
            var playerService = new Mock<IPlayerService>();

            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.FirstName = firstName;
            player.Object.LastName = lastName;
            player.Object.IsDeleted = false;
            player.Object.TeamId = null;
            player.Object.Price = 20;
            var options = TestUtils.GetOptions(nameof(PlayerChangesTeamID));
            playerService.Setup(p => p.RetrievePlayer(firstName, lastName)).Returns(player.Object);
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity,Budget=50, Id=1 });

                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                var sut = new TeamService(arrangeContext, playerService.Object);
                sut.BuyPlayer(teamName, teamCity, firstName, lastName);
               
                Assert.AreEqual(1,player.Object.TeamId);

            }
        }
        [TestMethod]
        public void TeamBudgetChanged()
        {
            //Arrange
            var teamName = "Cunami";
            var teamCity = "Sofia";
            var firstName = "Hristo";
            var lastName = "Konov";
            var playerService = new Mock<IPlayerService>();

            var player = new Mock<Player>();
            player.SetupAllProperties();
            player.Object.FirstName = firstName;
            player.Object.LastName = lastName;
            player.Object.IsDeleted = false;
            player.Object.TeamId = null;
            player.Object.Price = 20;
            var options = TestUtils.GetOptions(nameof(TeamBudgetChanged));
            playerService.Setup(p => p.RetrievePlayer(firstName, lastName)).Returns(player.Object);
            using (var arrangeContext = new FMDbContext(options))
            {
                arrangeContext.Teams.Add(new Team() { Name = teamName, City = teamCity, Budget = 50, Id = 1 });

                arrangeContext.SaveChanges();
            }
            //Act,Assert
            using (var arrangeContext = new FMDbContext(options))
            {
                var sut = new TeamService(arrangeContext, playerService.Object);
                var team=sut.BuyPlayer(teamName, teamCity, firstName, lastName);
               
                Assert.AreEqual(30,team.Budget);
                Assert.IsInstanceOfType(team,typeof(Team) );
                Assert.AreEqual(teamName,team.Name);
                Assert.AreEqual(teamCity,team.City);
                Assert.AreEqual(1,arrangeContext.Teams.Count());
            }
        }
    }
}
