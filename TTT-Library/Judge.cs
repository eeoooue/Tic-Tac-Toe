﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class Judge
    {
        public char Winner { get; private set; }

        private GameBoard _board;
        private readonly List<GameTile> _currentLine = new();
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
            Explore(move.Row, move.Column, new Impulse(0, 1));
            Explore(move.Row, move.Column, new Impulse(1, 0));
            Explore(move.Row, move.Column, new Impulse(0, -1));
            Explore(move.Row, move.Column, new Impulse(-1, 0));
            Explore(move.Row, move.Column, new Impulse(1, 1));
            Explore(move.Row, move.Column, new Impulse(-1, 1));
            Explore(move.Row, move.Column, new Impulse(1, -1));
            Explore(move.Row, move.Column, new Impulse(-1, -1));
        }

        private bool ValidCoordinates(int i, int j)
        {
            return (0 <= i && i < 3) && (0 <= j && j < 3);
        }

        private void Explore(int i, int j, Impulse impulse)
        {
            if (ValidCoordinates(i, j))
            {
                GameTile tile = _board.GetTile(i, j);
                _currentLine.Add(tile);

                if(_currentLine.Count < 3)
                {
                    impulse.Translate(ref i, ref j);
                    Explore(i, j, impulse);
                }
                else
                {
                    CheckCurrentLine();
                }

                _currentLine.Remove(tile);
            }
        }

        private void CheckCurrentLine()
        {
            if (IsWinningLine(_currentLine))
            {
                _winnerFound = true;
                Winner = _currentLine[0].Character;
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
