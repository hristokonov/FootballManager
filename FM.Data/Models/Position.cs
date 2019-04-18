using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FM.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Player> Player { get; set; }

    }
}
