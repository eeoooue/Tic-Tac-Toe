using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Forms_App
{
    public class ButtonTile : Button, Observer
    {
        TicTacToeGame _game;
        GameTile _tile;

        public ButtonTile(TicTacToeGame myGame, GameTile original)
        {
            _game = myGame;
            _tile = original;

            Font = new Font("Microsoft Sans Serif", 36F);
            Size = new Size(100, 100);
            _game.Attach(this);

            Update();
        }

        public new void Update()
        {
            Text = _tile.Character.ToString();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _tile.Click();
        }
    }
}
