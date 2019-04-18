using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FM.Data.Models
{
    public class Team
    {
        
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string Owner { get; set; }

        public decimal Budget { get; set; }
        public int Points { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConcede { get; set; }
        public int GoalDifference { get; set; }

        public int? LeagueId { get; set; }
        public League League { get; set; }
        
        public Manager Manager { get; set; }
        public ICollection<Player> Player { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }
        
    }
}
