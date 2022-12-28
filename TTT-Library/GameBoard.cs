using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class GameBoard
    {
        public char[,] grid = new char[3, 3];

        public GameBoard() 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = '.';
                }
            }
        }

        public bool CanMove(int i, int j)
        {
            return ValidCoordinate(i, j) && grid[i, j] == '.';
        }

        public void PlaceMove(int i, int j, char stone)
        {
            grid[i, j] = stone;
        }

        public char[][] GetPossibleWinningLines()
        {
            char[][] result = new char[8][];

            int p = 0;
            // horizontals
            for (int i = 0; i < 3; i++)
            {
                result[p++] = LineFromImpulse(i, 0, 0, 1);
            }

            // verticals
            for (int j = 0; j < 3; j++)
            {
                result[p++] = LineFromImpulse(0, j, 1, 0);
            }

            // diagonals
            result[p++] = LineFromImpulse(0, 0, 1, 1);
            result[p++] = LineFromImpulse(0, 2, 1, -1);

            return result;
        }

        private char[] LineFromImpulse(int i, int j, int y, int x)
        {
            char[] result = new char[3];

            for (int d = 0; d < 3; d++)
            {
                result[d] = grid[i, j];
                i += y;
                j += x;
            }

            return result;
        }
        private bool ValidCoordinate(int i, int j)
        {
            return (0 <= i && i < 3) && (0 <= j && j < 3);
        }
    }
}
