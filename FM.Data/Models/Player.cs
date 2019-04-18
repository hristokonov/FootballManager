using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FM.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nationality { get; set; }
        [Range(1,100)]
         [Required]
        public int Rating { get; set; }
        [Range(1, 100)]
        [Required]
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

    }
}
