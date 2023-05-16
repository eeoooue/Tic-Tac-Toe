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
        public char CurrentPlayer { get { return (Moves % 2 == 0) ? 'X' : 'O'; } }
        public bool GameOver { get { return (Moves == 9 || _judge.FindsWinner()); } }
        public char Winner { get { return _judge.Winner; } }
        public int Moves { get; set; }
        public BoardTile[,] Tiles { get { return Board.Tiles; } }

        public GameBoard Board { get; private set; }
        private Judge _judge;

        public TicTacToeGame()
        {
            Board = new GameBoard(this);
            _judge = new Judge(Board);
            
        }

        public virtual void NotifyMove() { }
    }
}
