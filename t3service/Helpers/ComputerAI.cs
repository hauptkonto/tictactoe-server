using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using t3service.Models;

namespace t3service.Helpers
{
    public class ComputerAI
    {
        public Games Move(Games game, int[] board)
        {
            int[] positions = GetAvailablePositions(board);

            // Move on random position.
            Random rnd = new Random();
            int position = rnd.Next(0, positions.Length);
            board[position] = 2; // Computer is always player 2.
            game.UpdateGameStatus(board);
            return game;
        }

        /**
         * Gets the index of all the positions that can be used.
         */
        private int[] GetAvailablePositions(int[] board)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if(board[i] == 0)
                {
                    positions.Add(i);
                }
            }
            return positions.ToArray();
        }
    }
}
