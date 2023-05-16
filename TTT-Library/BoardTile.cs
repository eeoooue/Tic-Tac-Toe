using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class BoardTile
    {
        public char Character { get; protected set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public bool Clicked { get { return _clicked; } }

        private bool _clicked = false;
        private TicTacToeGame _game;

        public BoardTile(TicTacToeGame myGame, int i, int j)
        {
            _game = myGame;
            Character = ' ';
            Row = i;
            Column = j;
        }

        public void Click()
        {
            if (!_clicked && !_game.GameOver)
            {
                Character = _game.CurrentPlayer;
                _game.MoveCount++;
                _clicked = true;
                _game.NotifyMove();
            }
        }
    }
}
