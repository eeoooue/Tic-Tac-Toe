using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_App
{
    internal class ButtonTile : Button
    {

        private TicTacToeGame _game;
        private GameTile _tile;

        public ButtonTile(TicTacToeGame game, GameTile tile)
        {
            _game = game;
            _tile = tile;
            Text = " ";
            FontSize = 50;
            Clicked += ClickAction;
            BorderColor = Color.FromArgb("#666666");
        }

        public void UpdateAppearance()
        {
            Text = _tile.Character.ToString();
        }

        private void ClickAction(object sender, EventArgs e)
        {
            _tile.Click();
            UpdateAppearance();
        }
    }
}
