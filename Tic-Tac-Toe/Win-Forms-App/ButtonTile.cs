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
        private TicTacToeGame _game;
        private GameTile _tile;
        private MainForm _parent;
        private bool Marked { get; set; }

        public ButtonTile(MainForm parent, TicTacToeGame myGame, GameTile original)
        {
            _parent = parent;
            _game = myGame;
            _tile = original;

            Font = new Font("Microsoft Sans Serif", 36F);
            Size = new Size(100, 100);
            _game.Attach(this);

            Update();
        }

        public new void Update()
        {
            if (_tile.Marked && !Marked)
            {
                Mark();
                _parent.Update();
            }
        }

        private void Mark()
        {
            Text = _tile.Character.ToString();
            Marked = true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _tile.Click();
        }
    }
}
