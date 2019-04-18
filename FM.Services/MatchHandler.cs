using FM.Data.Context;
using FM.Data.Models;
using FM.Services.Exceptions;
using FM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.Services
{
   public class MatchHandler : IMatchHandler
    {
        private readonly FMDbContext context;
        private readonly ITeamService teamService;

       
        public MatchHandler(FMDbContext context, ITeamService teamService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.teamService = teamService;
        }

        public Match PlayMatch(Match match) 
        {

            if (match.IsMatchPlayed)
            {
                throw new MatchPlayedException("Match already played");
            }
            Random rnd = new Random();
            var ratingHomeTeam = teamService.RetrieveTeamRatings(match.HomeTeam);
            var ratingAwayTeam = teamService.RetrieveTeamRatings(match.AwayTeam);
            if (ratingHomeTeam > ratingAwayTeam)
            {
                match.HomeTeamGoals = rnd.Next(2, 4);
                match.AwayTeamGoals = rnd.Next(0, 3);
            }
            else if (ratingHomeTeam == ratingAwayTeam)
            {
                match.HomeTeamGoals = rnd.Next(0, 3);
                match.AwayTeamGoals = rnd.Next(0, 3);
            }
            else if (ratingHomeTeam < ratingAwayTeam)
            {
                match.HomeTeamGoals = rnd.Next(0, 3);
                match.AwayTeamGoals = rnd.Next(2, 4);
            }
            if (match.HomeTeamGoals > match.AwayTeamGoals)
            {
                match.HomeTeam.Points += 3;
            }
            else if (match.HomeTeamGoals < match.AwayTeamGoals)
            {
                match.AwayTeam.Points += 3;
            }
            else if (match.HomeTeamGoals == match.AwayTeamGoals)
            {
                match.AwayTeam.Points += 1;
                match.HomeTeam.Points += 1;
            }
            match.HomeTeam.GoalsScored += match.HomeTeamGoals;
            match.HomeTeam.GoalsConcede += match.AwayTeamGoals;
            match.HomeTeam.GoalDifference = match.HomeTeam.GoalsScored - match.HomeTeam.GoalsConcede;

            match.AwayTeam.GoalsScored += match.AwayTeamGoals;
            match.AwayTeam.GoalsConcede += match.HomeTeamGoals;
            match.AwayTeam.GoalDifference = match.AwayTeam.GoalsScored - match.AwayTeam.GoalsConcede;
            match.IsMatchPlayed = true;
            return match;
        }
        public IEnumerable<Match> CreateMatches(League league)
        {
            Random rnd = new Random();
            var matches = new List<Match>();
            var teams = teamService.RetrieveLeagueTeams(league).ToArray();
            Validations.ValidateCollectionZero(teams, "There are no teams in the league");
            if (teams.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException("There are odd teams in the league");
            }
            Team[,] matrix = new Team[teams.Length / 2, 2];
            var i = 0;
            for (int j = 0; j < 2; j++)
            {
                for (int t = 0; t < teams.Length / 2; t++)
                {
                    matrix[t, j] = teams[i];
                    i++;
                }
            }
            int index = 0;
            var statiums = context.Stadiums.ToArray();
            DateTime date1 = new DateTime(2019, 3, 1);
            for (int z = 0; z < teams.Length - 1; z++)
            {
                for (int j = 0; j < teams.Length / 2; j++)
                {
                    var match = new Match
                    {
                        HomeTeam = matrix[j, 0],
                        AwayTeam = matrix[j, 1],
                        Stadium = statiums[index],
                        League = league,
                        Date = date1

                    };
                    index++;
                    date1 = date1.AddDays(1);
                    matches.Add(match);
                    context.Matches.Add(match);

                }
                index = 0;
                RotateMatrix(matrix.GetLength(0), matrix.GetLength(1), matrix);
            }
            context.SaveChanges();
            var newMatches = new List<Match>();
            foreach (var match in matches)
            {
                var newMatch = new Match
                {
                    HomeTeam = match.AwayTeam,
                    AwayTeam = match.HomeTeam,
                    Stadium = match.Stadium,
                    League = league,
                    Date = match.Date.AddDays(teams.Length + 1)
                };
                newMatches.Add(newMatch);
                context.Matches.Add(newMatch);
                context.SaveChanges();
            }
            matches.AddRange(newMatches);
            return matches;
        }
        private static void RotateMatrix(int m, int n, Team[,] mat)
        {
            int row = 0, col = 0;
            Team prev, curr;
            while (row < m && col < n)
            {
                if (row + 1 == m || col + 1 == n)
                {
                    break;
                }
                prev = mat[row + 1, col];
                for (int i = col; i < n; i++)
                {
                    curr = mat[row, i];
                    mat[row, i] = prev;
                    prev = curr;
                }
                row++;
                for (int i = row; i < m; i++)
                {
                    curr = mat[i, n - 1];
                    mat[i, n - 1] = prev;
                    prev = curr;
                }
                n--;
                if (row < m)
                {
                    for (int i = n - 1; i >= col; i--)
                    {
                        curr = mat[m - 1, i];
                        mat[m - 1, i] = prev;
                        prev = curr;
                    }
                }
                m--;
                if (col < n)
                {
                    for (int i = m - 1; i >= row; i--)
                    {
                        curr = mat[i, col];
                        mat[i, col] = prev;
                        prev = curr;
                    }
                }
                col++;
            }
            var temp = mat[0, 0];
            mat[0, 0] = mat[0, 1];
            mat[0, 1] = temp;
        }
    }
}
