using FM.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FM.Data.Context
{
   public class FMDbContext :DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public object Include { get; set; }

        public FMDbContext()
        {

        }
        public FMDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DbConfiguration.ConnectionString);
            }
           
        }
        private void LoadJson(ModelBuilder builder)
        {
            if (File.Exists(@"..\FM.Data\JsonFiles\Stadiums.json")
                && File.Exists(@"..\FM.Data\JsonFiles\Positions.json")
                 && File.Exists(@"..\FM.Data\JsonFiles\Leagues.json")
                  && File.Exists(@"..\FM.Data\JsonFiles\Teams.json")
                   && File.Exists(@"..\FM.Data\JsonFiles\Managers.json")
                    && File.Exists(@"..\FM.Data\JsonFiles\Players.json"))
            {
                var stadiums = JsonConvert.DeserializeObject<Stadium[]>
                    (File.ReadAllText(@"..\FM.Data\JsonFiles\Stadiums.json"));
                var positions = JsonConvert.DeserializeObject<Position[]>
                    (File.ReadAllText(@"..\FM.Data\JsonFiles\Positions.json"));
                var leagues = JsonConvert.DeserializeObject<League[]>
                    (File.ReadAllText(@"..\FM.Data\JsonFiles\Leagues.json"));
                var teams = JsonConvert.DeserializeObject<Team[]>
                    (File.ReadAllText(@"..\FM.Data\JsonFiles\Teams.json"));
                var managers = JsonConvert.DeserializeObject<Manager[]>
                   (File.ReadAllText(@"..\FM.Data\JsonFiles\Managers.json"));
                var players = JsonConvert.DeserializeObject<Player[]>
                   (File.ReadAllText(@"..\FM.Data\JsonFiles\Players.json"));

                builder.Entity<Stadium>().HasData(stadiums);
                builder.Entity<Position>().HasData(positions);
                builder.Entity<League>().HasData(leagues);
                builder.Entity<Team>().HasData(teams);
                builder.Entity<Manager>().HasData(managers);
                builder.Entity<Player>().HasData(players);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            LoadJson(builder);
        
            builder.Entity<Match>()
                        .HasOne(m => m.AwayTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

            builder.Entity<Match>()
                        .HasOne(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .HasForeignKey(m => m.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
          
            base.OnModelCreating(builder);
        }

    }
}
