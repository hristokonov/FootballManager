using FM.Data.Context;
using FM.Data.Models;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Services
{
    public class TeamService : ITeamService
      
    {
        private readonly FMDbContext context;
        private readonly IPlayerService playerService;
        
        public TeamService(FMDbContext context, IPlayerService playerService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.playerService = playerService;
        }

        public Team BuyPlayer(string name, string city, string firstName, string lastName)
        {
            var team = this.RetrieveTeam(name, city);
            Validations.ValidateDoesntExists(team, "Team doesn't exists");

            var player = playerService.RetrievePlayer(firstName, lastName);
            Validations.ValidateDoesntExists(player, "Player doesn't exists");
           
            if (player.IsDeleted)
            {
                throw new EntityDoesntExistsException("Player already retired");
            }
            if (player.TeamId!=null)
            {
                throw new EntityAlreadyExistsException("Player already has a team");
            }
            if (player.Price>team.Budget)
            {
                throw new ArgumentOutOfRangeException($"Team doesn't have enogh money to buy {player.FirstName} {player.LastName}");
            }

            player.TeamId = team.Id;
            team.Budget -= player.Price;
            context.SaveChanges();
            return team;
        }

        public Team CreateTeam(string name, string city, string country, string owner)
        {
            var budget = 10000000;
            var teamExist = this.RetrieveTeam(name, city);
           
            Validations.ValidateAlreadyExists(teamExist, "Team already exists");
           
            var team = new Team()
            {
                Name=name,
                City=city,
                Country=country,
                Budget=budget,
                Owner=owner
            };

            context.Teams.Add(team);
            context.SaveChanges();
            return team;
        }
        
        public Team RetrieveTeam(string name, string city)
        {
            var team = this.context.Teams.Include(t => t.Manager)
                .FirstOrDefault(t => t.Name == name && t.City == city);
            return team;
        }
       
        public int RetrieveTeamRatings(Team team)
        {
            var teamPlayers = playerService.RetrieveTeamPlayers(team);
            int rating = 0;
            foreach (var players in teamPlayers)
            {
                rating += players.Rating;
            }
            return rating;
        }
        public List<Team> RetrieveLeagueTeams(League league)
        {
            var teams =context.Teams.Include(t=>t.Manager)
                .Where(t=>t.League==league).ToList();
            
            return teams;
        }

        public Team ShowTeam(string name, string city)
        {
            var team = this.RetrieveTeam(name, city);
            Validations.ValidateDoesntExists(team, "Team doesn't exists");

            return team;
        }

    }
}
