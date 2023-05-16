using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class AnalysisBoard
    {
        public char[,] Tiles { get; private set; }

        private readonly Stack<PlayerMove> _moves = new Stack<PlayerMove>();

        private int _movesCount = 0;

        private CPUJudge _judge = new CPUJudge();

        public AnalysisBoard()
        {
            Tiles = new char[3, 3];
        }

        public char GetCurrentPlayer()
        {
            _movesCount = 0;

            foreach (char c in Tiles)
            {
                if (c != ' ')
                {
                    _movesCount++;
                }
            }

            if (_movesCount % 2 == 0)
            {
                return 'X';
            }
            else
            {
                return 'O';
            }
        }

        private int GetMoveCount()
        {
            _movesCount = 0;

            foreach (char c in Tiles)
            {
                if (c != ' ')
                {
                    _movesCount++;
                }
            }

            return _movesCount;
        }

        public bool WinnerExists()
        {
            return _judge.HasWinner(Tiles);
        }

        public bool GameOver()
        {
            if (GetMoveCount() == 9)
            {
                return true;
            }
            return WinnerExists();
        }

        public void MirrorBoardState(GameBoard board)
        {
            foreach (BoardTile tile in board.Tiles)
            {
                Tiles[tile.Row, tile.Column] = tile.Character;
            }
        }

        private bool ValidCoordinates(int i, int j)
        {
            return (0 <= i && i < 3) && (0 <= j && j < 3);
        }

        private bool CanMove(int i, int j)
        {
            return ValidCoordinates(i, j) && (Tiles[i, j] == ' ');
        }

        public bool SubmitMove(PlayerMove move)
        {
            if (CanMove(move.Row, move.Column))
            {
                Tiles[move.Row, move.Column] = move.Team;
                _moves.Push(move);
                return true;
            }

            return false;
        }

        public void UndoPreviousMove()
        {
            if (_moves.Count > 0)
            {
                PlayerMove move = _moves.Pop();
                Tiles[move.Row, move.Column] = ' ';
            }
        }
    }
}
