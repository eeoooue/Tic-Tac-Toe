using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class Judge
    {
        public char Winner { get; private set; }

        private GameBoard _board;
        private bool _winnerFound = false;

        public Judge(GameBoard gameboard)
        {
            Winner = 'N';
            _board = gameboard;
        }

        public bool FindsWinner(PlayerMove recentMove)
        {
            _winnerFound = false;
            CheckForWinner(recentMove);
            return _winnerFound;
        }

        private void CheckForWinner(PlayerMove move)
        {
            CheckColumn(move.column);
            CheckRow(move.row);
            CheckHorizontals();
        }

        private void CheckColumn(int column)
        {
            List<GameTile> line = new List<GameTile>();
            for(int i=0; i<3; i++)
            {
                GameTile tile = _board.GetTile(i, column);
                line.Add(tile);
            }
            CheckLine(line);
        }

        private void CheckRow(int row)
        {
            List<GameTile> line = new List<GameTile>();
            for (int j = 0; j < 3; j++)
            {
                GameTile tile = _board.GetTile(row, j);
                line.Add(tile);
            }
            CheckLine(line);
        }

        private void CheckHorizontals()
        {
            List<GameTile> line;
            line = new List<GameTile>()
            {
                _board.GetTile(0, 0),
                _board.GetTile(1, 1),
                _board.GetTile(2, 2),
            };
            CheckLine(line);

            line = new List<GameTile>()
            {
                _board.GetTile(0, 2),
                _board.GetTile(1, 1),
                _board.GetTile(2, 0),
            };
            CheckLine(line);
        }

        private void CheckLine(List<GameTile> line)
        {
            if (IsWinningLine(line))
            {
                _winnerFound = true;
                Winner = line[0].Character;
            }
        }

        private bool IsWinningLine(List<GameTile> line)
        {
            Dictionary<char, int> table = new()
            {
                { ' ', 0 },
                { 'X', 0 },
                { 'O', 0 },
            };

            foreach (GameTile tile in line)
            {
                table[tile.Character] += 1;
            }

            return (table['X'] == 3 || table['O'] == 3);
        }
    }
}
