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
        public char CurrentPlayer { get { return (MoveCount % 2 == 0) ? 'X' : 'O'; } }
        public bool GameOver { get { return MoveCount == 9 || _judge.FindsWinner(); } }
        public char Winner { get { return _judge.Winner; } }
        public int MoveCount { get { return _moveHistory.Count; } }

        public PlayerMove previousMove { get { return _moveHistory.Peek(); } }

        

        public GameBoard Board { get; private set; }
        private Judge _judge;

        protected Stack<PlayerMove> _moveHistory = new Stack<PlayerMove>();

        public TicTacToeGame()
        {
            Board = new GameBoard(this);
            _judge = new Judge(Board);
        }

        public void SubmitMove(PlayerMove move)
        {
            AbstractTile tile = Board.GetTile(move.Row, move.Column);
            tile.Mark();
            _moveHistory.Push(move);
            NotifyMove();
        }

        public virtual void NotifyMove() { }
    }
}
