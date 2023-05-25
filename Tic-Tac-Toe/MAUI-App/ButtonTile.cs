using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_App
{
    internal class ButtonTile : Button, Observer
    {
        private TicTacToeGame _game;
        private GameTile _tile;

        private bool Marked { get; set; }

        private bool GameOver { get { return _game.GameOver; } }

        private bool WinningTile { get { return GameOver && (_tile.Character == _game.Winner); } }

        public ButtonTile(TicTacToeGame game, GameTile tile)
        {
            _game = game;
            _tile = tile;
            Text = " ";
            FontSize = 50;
            Clicked += ClickAction;
            TextColor = Color.FromArgb("#ffffff");
            _game.Attach(this);
            Marked = false;

            Update();
        }

        public void Update()
        {
            if (_tile.Marked && !Marked)
            {
                Mark();
            }
            
            if (GameOver && !WinningTile)
            {
                ShowLosingAppearance();
            }
        }

        private void Mark()
        {
            Text = _tile.Character.ToString();
            Background = Color.FromArgb("#ffffff");

            if (_tile.Character == 'X')
            {
                Background = Color.FromArgb("#DB7093");
            }
            else if (_tile.Character == 'O')
            {
                Background = Color.FromArgb("#6495ED");
            }

            Marked = true;
        }

        private void ShowLosingAppearance()
        {
            TextColor = Color.FromArgb("#aaaaaa");
            Background = Color.FromArgb("#ffffff");
        }

        private void ClickAction(object sender, EventArgs e)
        {
            _tile.Click();
        }
    }
}
