using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Forms_App
{
    public class ButtonTile : Button
    {
        public int Row { get { return _tile.Row; } }
        public int Column { get { return _tile.Column; } }

        TicTacToeGame _game;
        GameTile _tile;

        MainForm _parent;

        public ButtonTile(TicTacToeGame myGame, MainForm parentForm, GameTile original)
        {
            _game = myGame;
            _tile = original;
            _parent = parentForm;

            Font = new Font("Microsoft Sans Serif", 36F);
            Size = new Size(100, 100);
        }

        public void UpdateMe()
        {
            Text = _tile.Character.ToString();
            Update();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _tile.Click();
            _parent.UpdateAll();
        }
    }
}
