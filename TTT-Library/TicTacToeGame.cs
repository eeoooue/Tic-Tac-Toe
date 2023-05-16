using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTT_Library
{
    public class TicTacToeGame
    {
        public GameBoard Board { get; private set; }
        public char CurrentPlayer { get { return (MoveCount % 2 == 0) ? 'X' : 'O'; } }
        public bool GameOver { get { return MoveCount == 9 || _judge.FindsWinner(); } }
        public int MoveCount { get { return MoveHistory.Count; } }
        public char Winner { get { return _judge.Winner; } }
        public bool WinnerExists { get { return _judge.FindsWinner(); } }

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
            GameTile tile = Board.GetTile(move.Row, move.Column);
            tile.Mark();
            MoveHistory.Push(move);
            NotifyMove();
        }

        public virtual void NotifyMove() { }
    }
}
