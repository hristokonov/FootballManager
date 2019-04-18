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
   public class PlayerService : IPlayerService
    {
        private readonly FMDbContext context;

        public PlayerService(FMDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Player CreatePlayer(string firstName,string lastName,string nationality,int rating,int position)
        {
            var price = rating * 1000;
            var playerExist = this.RetrievePlayer(firstName, lastName);
            Validations.ValidateAlreadyExists(playerExist, "Player already exists");
            
            if (playerExist != null && playerExist.IsDeleted)
            {
                throw new EntityDoesntExistsException("Player retired");
            }
            var player = new Player()
            {
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality,
                Rating = rating,
                PositionId = position,
                Price = price
            };
       
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        public Player RetirePlayer(string firstName, string lastName)
        {
            var player = this.RetrievePlayer(firstName, lastName);
            Validations.ValidateDoesntExists(player, "Player doesn't exists");

            if (player.IsDeleted==true)
            {
                throw new EntityDoesntExistsException("Player already retired");
            }
            player.IsDeleted = true;
            player.TeamId = null;
            context.SaveChanges();
            return player;
        }

        public Player RetrievePlayer(string firstName, string lastName)
        {

            return  this.context.Players.Include(p=>p.Position)
                .FirstOrDefault(p => p.FirstName==firstName && p.LastName==lastName);
           
        }

        public IEnumerable<Player> ShowPlayers()
        {
            var list= context.Players.Include(p => p.Position)
                .Where(x=>x.IsDeleted==false)
                .OrderByDescending(p => p.Price)
                .ThenBy(p => p.PositionId)
                .ToList();
            return list;
        }

        public IEnumerable<Player> ShowPlayersWithoutTeam()
        {
            var list = context.Players.Include(p => p.Position)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Team == null)
                .OrderByDescending(p => p.Price)
                .ThenBy(p => p.PositionId)
                .ToList();
            return list;
        }

        public IEnumerable<Player> ShowTeamPlayers(string name, string city)
        {
            
            var list = context.Players.Include(t => t.Team)
                .Include(p=>p.Position)
                .Where(x => x.IsDeleted == false)
                .Where(p=>p.Team.Name==name && p.Team.City==city)
                .OrderBy(p => p.PositionId)
                .ToList();
            return list;
        }
        public IEnumerable<Player> RetrieveTeamPlayers(Team team)
        {
            var teamPlayers = context.Players
                 .Include(p => p.Team )
                 .Where(p=>p.Team==team)
                 .ToList();
            return teamPlayers;
        }
    }
}
