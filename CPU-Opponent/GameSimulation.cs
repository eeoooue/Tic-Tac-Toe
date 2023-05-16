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
        public char CurrentPlayer { get { return (MoveCount % 2 == 0) ? 'X' : 'O'; } }
        public int MoveCount { get { return _board.GetMoveCount(); } }
        public bool WinnerExists { get { return _judge.FindsWinner(); } }

        private SimulationBoard _board;
        private Judge _judge;
        private readonly Stack<PlayerMove> _moves = new Stack<PlayerMove>();

        public GameSimulation(TicTacToeGame game)
        {
            _board = new SimulationBoard();
            _board.CopyBoard(this, game.Board);
            _judge = new Judge(_board);
        }

        private bool CanMove(int i, int j)
        {
            AbstractTile tile = _board.GetTile(i, j);
            return tile.Character == ' ';
        }

        public List<PlayerMove> GetPossibleMoves()
        {
            List<PlayerMove> possibleMoves = new();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (CanMove(i, j))
                    {
                        PlayerMove move = new PlayerMove(i, j, CurrentPlayer);
                        possibleMoves.Add(move);
                    }
                }
            }
            return possibleMoves;
        }

        public void SubmitMove(PlayerMove move)
        {
            _moves.Push(move);
            AbstractTile tile = _board.GetTile(move.Row, move.Column);
            tile.Click();
        }

        public void UndoPreviousMove()
        {
            if (_moves.Count > 0)
            {
                PlayerMove move = _moves.Pop();
                AbstractTile tile = _board.GetTile(move.Row, move.Column);
                if (tile is SimulationTile simTile)
                {
                    simTile.Unclick();
                }
            }
        }
    }
}
