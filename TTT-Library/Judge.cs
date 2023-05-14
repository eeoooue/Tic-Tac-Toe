using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class Judge
    {
        private GameBoard _board;

        public Judge(GameBoard gameboard)
        {
            _board = gameboard;
        }

        public bool FindsWinner()
        {
            foreach (List<BoardTile> line in GetPossibleWinningLines())
            {
                if (IsWinningLine(line))
                {
                    return true;
                }
            }
            return false;
        }

        private List<List<BoardTile>> GetPossibleWinningLines()
        {
            List<List<BoardTile>> result = new List<List<BoardTile>>();

            // horizontals
            for (int i = 0; i < 3; i++)
            {
                result.Add(LineFromImpulse(i, 0, 0, 1));
            }

            // verticals
            for (int j = 0; j < 3; j++)
            {
                result.Add(LineFromImpulse(0, j, 1, 0));
            }

            // diagonals
            result.Add(LineFromImpulse(0, 0, 1, 1));
            result.Add(LineFromImpulse(0, 2, 1, -1));

            return result;
        }

        private List<BoardTile> LineFromImpulse(int i, int j, int y, int x)
        {
            List<BoardTile> result = new List<BoardTile>();

            for (int d = 0; d < 3; d++)
            {
                result.Add(_board.tiles[i, j]);
                i += y;
                j += x;
            }

            return result;
        }

        private bool IsWinningLine(List<BoardTile> line)
        {
            Dictionary<char, int> table = new()
            {
                { '.', 0 },
                { 'X', 0 },
                { 'O', 0 },
            };

            foreach (BoardTile tile in line)
            {
                table[tile.Character] += 1;
            }

            return (table['X'] == 3 || table['O'] == 3);
        }
    }
}
