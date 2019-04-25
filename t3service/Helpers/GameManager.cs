using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using t3service.Models;

namespace t3service.Helpers
{
    public class GameManager
    {
        public void InitGame(Games game)
        {
            game.Id = Guid.NewGuid();
            game.StartDateTime = DateTime.UtcNow;
            game.LastUpdated = DateTime.UtcNow;
            game.Status = GameStatus.ONGOING.ToString();
            game.Board = "[[0,0,0],[0,0,0],[0,0,0]]";
            using (tictactoeContext _context = new tictactoeContext()) {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
        }
    }
}
