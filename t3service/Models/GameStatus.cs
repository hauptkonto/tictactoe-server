using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3service.Models
{
    public class GameStatus
    {
            private GameStatus(string value) { Value = value; }

            public string Value { get; set; }

            public static GameStatus ONGOING { get { return new GameStatus("Ongoing"); } }
            public static GameStatus P1_WON { get { return new GameStatus("Player 1 won"); } }
            public static GameStatus P2_WON { get { return new GameStatus("Player 2 won"); } }
            public static GameStatus DRAW { get { return new GameStatus("Draw"); } }
    }
}
