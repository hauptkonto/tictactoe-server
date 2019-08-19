using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using t3service.Models;

namespace t3service.Helpers
{
    public class GameManager
    {
        /**
         * Starts a new game.
         */
        public void InitGame(Games game)
        {
            game.Id = Guid.NewGuid();
            game.StartDateTime = DateTime.UtcNow;
            game.LastUpdated = DateTime.UtcNow;
            game.Status = GameStatus.ONGOING.ToString();
            game.Board = "0,0,0," + "0,0,0," + "0,0,0";
            using (tictactoeContext _context = new tictactoeContext()) {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
        }

        public Games GetGame(Guid gameId)
        {
            using (tictactoeContext _context = new tictactoeContext())
            {
                return _context.Games.Find(gameId);
            }
        }

        public Games Move(Movement movement)
        {
            Games game = null;
            using (tictactoeContext _context = new tictactoeContext())
            {
                game = _context.Games.Find(movement.gameId);
                int[] board = game.GetIntBoard();
                bool result = TryMovement(game, board, movement);
                if (result == true)
                {
                    if (game.IsOnGoing() && game.P2isCPU())
                    {
                        TriggerAI(game, board);
                    }
                    // Save game
                    game.LastUpdated = DateTime.UtcNow;
                    _context.Update<Games>(game);
                    _context.SaveChanges();
                    return game;
                }
            }
            return game;
        }

        /**
         * Attempt to perform the given movement in the given game.
         * Returns true if the movement was possible and false otherwise.
         */
        private bool TryMovement(Games game, int[] board, Movement movement)
        {
            if (board[movement.position] == 0)
            {
                // Movement is possible, so go ahead with it
                int symbol = game.Player1Id == movement.playerId ? 1 : 2;
                board[movement.position] = symbol;
                game.UpdateGameStatus(board);
                return true;
            }
            else
            {
                // Movement is not possible, return an error or do nothing for now.
                return false;
            }
        }

        private void TriggerAI(Games game, int[] board)
        {
            ComputerAI ai = new ComputerAI();
            ai.Move(game, board);
        }
    }
}
