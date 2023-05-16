using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class GameTile
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char Character { get; private set; }
        public bool Marked { get; private set; }

        private TicTacToeGame _game;

        public GameTile(TicTacToeGame myGame, int row, int column)
        {
            _game = myGame;
            Row = row;
            Column = column;
            Character = ' ';
        }

        public void Mark()
        {
            if (!Marked && !_game.GameOver)
            {
                Character = _game.CurrentPlayer;
                Marked = true;
            }
        }

        public void Unmark()
        {
            if (Marked)
            {
                Character = ' ';
                Marked = false;
            }
        }

        public void Click()
        {
            if (!Marked && !_game.GameOver)
            {
                PlayerMove move = new PlayerMove(Row, Column, _game.CurrentPlayer);
                _game.SubmitMove(move);
            }
        }
    }
}
