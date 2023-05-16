using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class BoardTile : AbstractTile
    {
        
        private TicTacToeGame _game;

        public BoardTile(TicTacToeGame myGame, int i, int j) : base(i, j)
        {
            _game = myGame;
        }

        public override void Click()
        {
            if (!Clicked && !_game.GameOver)
            {
                Character = _game.CurrentPlayer;
                _game.MoveCount++;
                Clicked = true;
                _game.NotifyMove();
            }
        }
    }
}
