using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3service.Models
{
    public class Movement
    {
        public Guid gameId;     // The game in which the current move will take place
        public Guid playerId;   // The player that performed the movement.
        public int position;    // position for movement
    }
}
