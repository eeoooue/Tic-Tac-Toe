using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class ClickableTile : AbstractTile
    {
        
        private TicTacToeGame _game;

        public ClickableTile(TicTacToeGame myGame, int i, int j) : base(i, j)
        {
            _game = myGame;
        }

        public override void Mark()
        {
            if (!Marked && !_game.GameOver)
            {
                Character = _game.CurrentPlayer;
                Marked = true;
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
