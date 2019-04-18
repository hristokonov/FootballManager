using FM.Data.Context;
using FM.Data.Models;
using FM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FM.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly FMDbContext context;
        private readonly ITeamService teamService;
        private readonly IMatchHandler matchHandler;

        public LeagueService(FMDbContext context, ITeamService teamService, IMatchHandler matchHandler)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.teamService = teamService;
            this.matchHandler = matchHandler;
        }

        public League CreateLeague(string name)
        {
            var leagueExist = this.RetrieveLeague(name);
            Validations.ValidateAlreadyExists(leagueExist, "League already exists");
           
            var league = new League()
            {
                Name = name,
            };

            context.Leagues.Add(league);
            context.SaveChanges();
            return league;
        }

        public League RetrieveLeague(string name)
        {
            var league= this.context.Leagues
                .Include(t => t.Matches)                   
                .FirstOrDefault(l => l.Name == name);
            return league;
        }
        public IEnumerable<Match> RetrieveLeagueMatches(League league)
        {
            var matches = this.context.Matches
                .Include(t => t.HomeTeam)
                .Include(t=>t.AwayTeam)
                .Where(m=>m.League==league)
                .ToList();
            return matches;
        }
        
        public IEnumerable<Match> CreateMatches(string name)
        {
            var league = this.RetrieveLeague(name);
            Validations.ValidateDoesntExists(league, "League doesn't exist");
            var matches = matchHandler.CreateMatches(league);
           
            return matches;
        }
       
        public League AddTeamToLeague(string name, string city, string league)
        {
            var team = teamService.RetrieveTeam(name, city);
            Validations.ValidateDoesntExists(team, "Team doesn't exist");

            var newLeague = this.RetrieveLeague(league);
            Validations.ValidateDoesntExists(newLeague, "League doesn't exist");

            team.LeagueId = newLeague.Id;
            this.ResetTeamData(team);
            context.SaveChanges();

            return newLeague;
        }
        public void ResetTeamData(Team team)
        {
            team.GoalsScored = 0;
            team.GoalsConcede = 0;
            team.GoalDifference = 0;
            team.Points = 0;
        }
        public IEnumerable<Match> ShowAllMatches(string name)
        {
            var league = this.RetrieveLeague(name);
            Validations.ValidateDoesntExists(league, "League doesn't exist");

            var matches = this.RetrieveLeagueMatches(league);
            Validations.ValidateCollectionZero(matches, "There are no matches in the league");
           
            return matches;
        }

        public IEnumerable<Team> ShowTable(string name)
        {
            var league = this.RetrieveLeague(name);
            Validations.ValidateDoesntExists(league, "League doesn't exist");

            var teams = teamService.RetrieveLeagueTeams(league);
            Validations.ValidateCollectionZero(teams, "There are no teams in the league");
            return teams;
        }

        public League ResetTeams(string name)
        {
            var league = this.RetrieveLeague(name);
            Validations.ValidateDoesntExists(league, "League doesn't exist");
            var teams=teamService.RetrieveLeagueTeams(league);
            Validations.ValidateCollectionZero(teams, "There are no teams in the league");
            
            foreach (var team in teams)
            {
                this.ResetTeamData(team);
                
            }
            context.SaveChanges();
            var matches = this.RetrieveLeagueMatches(league);
           
            return league;
        }

        public IEnumerable<League> ShowAllLeagues()
        {
            var list = context.Leagues
                 .ToList();
            return list;
        }
    }
}
