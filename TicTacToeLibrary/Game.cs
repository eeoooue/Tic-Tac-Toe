using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{

    public class Game
    {

        public char[,] grid = new char[3,3];
        public int moves = 0;

        public Game()
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    grid[i,j] = '.';
                }
            }
        }

        public void PlaceMove(int i, int j)
        {
            char stone = (moves % 2 == 0) ? 'X' : 'O';
            grid[i,j] = stone;
            moves++;
        }

        public bool CanMove(int i, int j)
        {
            if (0 <= i && i < 3)
            {
                if (0 <= j && j < 3)
                {
                    if (grid[i,j] == '.')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsWinningLine(char[] line)
        {
            Dictionary<char, int> table = new Dictionary<char, int>()
            {
                { '.', 0 },
                { 'X', 0 },
                { 'O', 0 },
            };

            foreach(char x in line)
            {
                table[x] += 1;
            }

            return (table['X'] == 3 || table['O'] == 3);
        }


        private char[] LineFromImpulse(int i, int j, int y, int x)
        {
            char[] result = new char[3];

            for(int d=0; d<3; d++)
            {
                result[d] = grid[i, j];
                i += y;
                j += x;
            }

            return result;
        }

        public bool HasWinner()
        {
            // horizontals
            for(int i=0; i<3; i++)
            {
                if (IsWinningLine(LineFromImpulse(i, 0, 0, 1)))
                {
                    return true;
                }
            }

            // verticals
            for(int j=0; j<3; j++)
            {
                if (IsWinningLine(LineFromImpulse(0, j, 1, 0)))
                {
                    return true;
                }
            }

            // diagonals
            if (IsWinningLine(LineFromImpulse(0, 0, 1, 1)))
            {
                return true;
            }
            if (IsWinningLine(LineFromImpulse(0, 2, 1, -1)))
            {
                return true;
            }

            return false;
        }

        public bool GameOver()
        {
            return ( moves == 9 || HasWinner() );
        }

    }
}
