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
        public bool GameOver { get { return (Moves == 9 || HasWinner); } }
        public bool HasWinner { get { return _judge.FindsWinner(); } }
        public int Moves { get; set; }
        public BoardTile[,] Tiles { get { return _gameboard.tiles; } }

        private GameBoard _gameboard;
        private Judge _judge;

        public TicTacToeGame()
        {
            _gameboard = new GameBoard(this);
            _judge = new Judge(_gameboard);
        }
    }
}
