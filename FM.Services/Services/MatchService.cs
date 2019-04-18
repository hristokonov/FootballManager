using FM.Data.Context;
using FM.Data.Models;
using FM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FM.Services
{
    public class MatchService : IMatchService
    {
        private readonly FMDbContext context;
        private readonly ITeamService teamService;
        private readonly ILeagueService leagueService;
        private readonly IMatchHandler matchHandler;

       

        public MatchService(FMDbContext context, ITeamService teamService, 
            ILeagueService leagueService, IMatchHandler matchHandler)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.teamService = teamService;
            this.leagueService = leagueService;
            this.matchHandler = matchHandler;
        }

        public Stadium CreateStadium(string name, string city, string country, int capacity)
        {
            var stadiumExists = this.RetrieveStadium(name, city);
            Validations.ValidateAlreadyExists(stadiumExists, "Stadium already exists");
            
            var stadium = new Stadium()
            {
                Name = name,
                City = city,
                Country = country,
                Capacity = capacity
            };

            context.Stadiums.Add(stadium);
            context.SaveChanges();
            return stadium;
        }

        public Stadium RetrieveStadium(string name, string city)
        {
            return this.context.Stadiums
                .FirstOrDefault(s => s.Name == name && s.City == city);
        }

        public IEnumerable<Match> PlayAllMatches(string name)
        {
            var league = leagueService.RetrieveLeague(name);
            Validations.ValidateDoesntExists(league, "League doesn't exist");
           
            var matches = leagueService.RetrieveLeagueMatches(league);
            Validations.ValidateCollectionZero(matches, "There are no matches in the league");
            foreach (var match in matches)
            {
                var result =matchHandler.PlayMatch(match);
            }
            context.SaveChanges();
            return matches;
        }

        public void DeleteAllMatches()
        {
            context.Matches.RemoveRange(context.Matches);
            var sql = "DBCC CHECKIDENT ('dbo.Matches', RESEED, 0);";
            context.Database.ExecuteSqlCommand(sql);
            context.SaveChanges();
                
        }
    }
}
