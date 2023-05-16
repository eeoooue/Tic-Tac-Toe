using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    internal class CPUJudge
    {
        public CPUJudge() { }

        public bool HasWinner(char[,] tiles)
        {
            if (ContainsWinningRow(tiles))
            {
                return true;
            }
            if (ContainsWinningColumn(tiles))
            {
                return true;
            }
            if (ContainsWinningDiagonal(tiles))
            {
                return true;
            }
            return false;
        }

        private bool ContainsWinningDiagonal(char[,] tiles)
        {

            if (tiles[1, 1] == ' ')
            {
                return false;
            }

            if (tiles[0, 0] == tiles[1, 1] && tiles[1, 1] == tiles[2, 2])
            {
                return true;
            }

            if (tiles[2, 0] == tiles[1, 1] && tiles[1, 1] == tiles[0, 2])
            {
                return true;
            }

            return false;
        }

        private bool ContainsWinningColumn(char[,] tiles)
        {
            for (int col = 0; col < 3; col++)
            {
                if (IsWinningColumn(tiles, col))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsWinningColumn(char[,] tiles, int column)
        {
            char start = tiles[0, column];

            if (start == ' ')
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (tiles[i, column] != start)
                {
                    return false;
                }
            }

            return true;
        }


        private bool ContainsWinningRow(char[,] tiles)
        {
            for (int row = 0; row < 3; row++)
            {
                if (IsWinningRow(tiles, row))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsWinningRow(char[,] tiles, int row)
        {
            char start = tiles[row, 0];

            if (start == ' ')
            {
                return false;
            }

            for (int j = 0; j < 3; j++)
            {
                if (tiles[row, j] != start)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
