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

        /**
         * Converts the current board to an array of ints.
         */
        public int[] GetIntBoard()
        {
            string[] boardElements  = Board.Split(",");
            int[] boardInts = new int[9];
            for (int i = 0; i < 9; i++)
            {
                boardInts[i] = Int32.Parse(boardElements[i]);
            }
            return boardInts;
        }

        /**
         * Updates the board value to store it in the datbase.
         */
        public void SetStrBoard(int[] boardInts)
        {
            string strBoard = "";
            for (int i = 0; i < 9 - 1; i++)
            {
                strBoard += boardInts[i] + ",";
            }
            strBoard += boardInts[8];
            Board = strBoard;
        }

        /**
         * Updates the board and all of the game variables.
         */
        public void UpdateGameStatus(int[] boardInts)
        {
            SetStrBoard(boardInts);
            int winner = CheckForWinner(boardInts);
            UpdateGameStatus(winner);
            EndDateTime = DateTime.UtcNow;
        }

        /**
         * TODO: Change this for a proper algorythm.
         */
        public int CheckForWinner(int[] boardInts)
        {
            // Check for diagonals
            bool diagonalLMarches = CoordinatesMatch(0,4,8, boardInts);
            if (diagonalLMarches)
            {
                return boardInts[0];
            }

            bool diagonalRMarches = CoordinatesMatch(2, 4, 6, boardInts);
            if (diagonalRMarches)
            {
                return boardInts[2];
            }

            // Check for columns and rows
            for (int i = 0; i < 3; i++)
            {
                bool columnMarches = CoordinatesMatch(i + 0 * 3, i + 1 * 3, i + 2 * 3, boardInts);
                bool rowMarches = CoordinatesMatch(0 + i * 3, 1 + i * 3, 2 + i * 3, boardInts);
                if (columnMarches)
                {
                    return boardInts[i + 0 * 3];
                }
                else if (rowMarches)
                {
                    return boardInts[0 + i * 3];
                }
            }
            return 0;
        }

        /**
         * Checks if the three positions have the same value and this value is not 0.
         */
        private bool CoordinatesMatch(int x1, int x2, int x3, int[] b)
        {
            bool condition = b[x1] == b[x2] && b[x1] == b[x3] && b[x1] != 0;
            return condition;
        }

        private void UpdateGameStatus(int winner)
        {
            switch (winner)
            {
                case 0: // ongoing or draw
                    if (!Board.Contains("0"))
                    {
                        Status = GameStatus.DRAW.ToString();
                    }
                    break;
                case 1: // Player 1 won
                    Status = GameStatus.P1_WON.ToString();
                    break;
                case 2: // Player 2 won
                    Status = GameStatus.P2_WON.ToString();
                    break;
                default:
                    Status = GameStatus.ONGOING.ToString();
                    break;
            }
        }

        /**
         * Returns true of the game is not finished.
         */
        public bool IsOnGoing()
        {
            return Status.Equals(GameStatus.ONGOING.ToString());
        }

        public bool P2isCPU()
        {
            return Player2Id == null;
        }
    }
}
