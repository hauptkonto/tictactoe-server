using System;
using System.Collections.Generic;

namespace t3service.Models
{
    public partial class Games
    {
        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Guid? Player2Id { get; set; }
        public string Symbol { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string Status { get; set; }
        public string Board { get; set; }

        public Users Player1 { get; set; }
        public Users Player2 { get; set; }
    }
}
