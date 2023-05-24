using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Char_Matrix
{
    internal class MatrixJudge
    {
        public int CountMoves(char[,] game)
        {
            int count = 0;
            foreach (char c in game)
            {
                if (c != ' ')
                {
                    count++;
                }
            }

            return count;
        }

        public bool ContainsWinner(char[,] game)
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsWinningRow(game, i) || IsWinningColumn(game, i))
                {
                    return true;
                }
            }

            if (HasWinningDiagonal(game))
            {
                return true;
            }

            return false;
        }

        private bool IsWinningRow(char[,] game, int i)
        {
            char team = game[i, 0];

            if (team == ' ')
            {
                return false;
            }

            return (game[i, 1] == team && game[i, 2] == team);
        }

        private bool IsWinningColumn(char[,] game, int j)
        {
            char team = game[0, j];

            if (team == ' ')
            {
                return false;
            }

            return (game[1, j] == team && game[2, j] == team);
        }

        private bool HasWinningDiagonal(char[,] game)
        {
            char team = game[1, 1];

            if (team == ' ')
            {
                return false;
            }
            if (game[0, 0] == team && game[2, 2] == team)
            {
                return true;
            }
            else if (game[0, 2] == team && game[2, 0] == team)
            {
                return true;
            }
            return false;
        }
    }
}
