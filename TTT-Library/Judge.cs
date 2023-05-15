using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class Judge
    {
        public bool WinnerFound { get; private set; }
        public char Winner { get; private set; }

        private GameBoard _board;
        private readonly List<BoardTile> _currentLine = new();

        public Judge(GameBoard gameboard)
        {
            WinnerFound = false;
            Winner = 'N';
            _board = gameboard;
        }

        public bool FindsWinner()
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Explore(i, j, new Impulse(0, 1));
                    Explore(i, j, new Impulse(1, 0));
                    Explore(i, j, new Impulse(1, 1));
                    Explore(i, j, new Impulse(1, -1));
                }
            }

            return WinnerFound;
        }

        private bool ValidCoordinates(int i, int j)
        {
            return (0 <= i && i < 3) && (0 <= j && j < 3);
        }

        private void Explore(int i, int j, Impulse impulse)
        {
            if (ValidCoordinates(i, j))
            {
                BoardTile tile = _board.Tiles[i, j];
                _currentLine.Add(tile);

                if(_currentLine.Count < 3)
                {
                    impulse.Translate(ref i, ref j);
                    Explore(i, j, impulse);
                }
                else
                {
                    CheckForWinner();
                }

                _currentLine.Remove(tile);
            }
        }

        private void CheckForWinner()
        {
            if (IsWinningLine(_currentLine))
            {
                WinnerFound = true;
                Winner = _currentLine[0].Character;
            }
        }

        private bool IsWinningLine(List<BoardTile> line)
        {
            Dictionary<char, int> table = new()
            {
                { ' ', 0 },
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
