using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class TicTacToeGame
    {
        public GameBoard Board { get; private set; }
        public char CurrentPlayer { get { return (MoveCount % 2 == 0) ? 'X' : 'O'; } }
        public bool GameOver { get { return MoveCount == 9 || WinnerExists; } }
        public int MoveCount { get { return MoveHistory.Count; } }
        public char Winner { get { return _judge.Winner; } }
        public bool WinnerExists { get { return MoveCount > 1 && _judge.FindsWinner(MoveHistory.Peek()); } }

        private Judge _judge;
        public Stack<PlayerMove> MoveHistory { get; private set; }

        public TicTacToeGame()
        {
            Board = new GameBoard(this);
            MoveHistory = new Stack<PlayerMove>();

            _judge = new Judge(Board);
        }

        public void SubmitMove(PlayerMove move)
        {
            if (move.team == CurrentPlayer)
            {
                GameTile tile = Board.GetTile(move.row, move.column);
                tile.Mark();
                MoveHistory.Push(move);
            }
        }

        public virtual void NotifyMove() { }
    }
}
