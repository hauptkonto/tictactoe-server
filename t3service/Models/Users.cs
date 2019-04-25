using System;
using System.Collections.Generic;

namespace t3service.Models
{
    public partial class Users
    {
        public Users()
        {
            GamesPlayer1 = new HashSet<Games>();
            GamesPlayer2 = new HashSet<Games>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Games> GamesPlayer1 { get; set; }
        public ICollection<Games> GamesPlayer2 { get; set; }
    }
}
