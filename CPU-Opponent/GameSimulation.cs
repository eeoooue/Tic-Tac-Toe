using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class GameSimulation
    {
        public char[,] Tiles { get; private set; }

        private readonly Stack<PlayerMove> _moves = new Stack<PlayerMove>();


        public char CurrentPlayer { get { return (MoveCount % 2 == 0) ? 'X' : 'O'; } }

        public int MoveCount { get { return GetMoveCount(); } }

        private CPUJudge _judge = new CPUJudge();

        private TicTacToeGame _game;

        public GameSimulation(TicTacToeGame game)
        {
            _game = game; 
            Tiles = new char[3, 3];

            MirrorBoardState(game.Board);
        }

        private int GetMoveCount()
        {
            int count = 0;
            foreach (char c in Tiles)
            {
                if (c != ' ')
                {
                    count++;
                }
            }

            return count;
        }

        public bool WinnerExists()
        {
            return _judge.HasWinner(Tiles);
        }

        public bool GameOver()
        {
            return (MoveCount == 9) || WinnerExists();
        }

        public void MirrorBoardState(GameBoard board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    AbstractTile tile = board.GetTile(i, j);
                    Tiles[i, j] = tile.Character;
                }
            }
        }

        private bool CanMove(int i, int j)
        {
            return Tiles[i, j] == ' ';
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
