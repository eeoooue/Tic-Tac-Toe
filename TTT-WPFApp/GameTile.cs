using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using TTT_Library;

namespace TTT_WPFApp
{
    internal class GameTile : Button
    {

        private TicTacToeGame _myGame;

        public int Row { get; private set; }
        public int Column { get; private set; }

        public GameTile(TicTacToeGame myGame, int i, int j)
        {
            _myGame = myGame;
            Content = "";
            Width = 80;
            Height = 80;
            FontSize = 36;
            Foreground = Brushes.White;

            Row = i;
            Column = j;
            UpdateMe();
        }

        protected override void OnClick()
        {
            _myGame.AttemptMove(Row, Column);
            UpdateMe();
        }

        public void UpdateMe()
        {
            string cellValue = _myGame.GetCellText(Row, Column);

            for (int i = 0; i < 9; i++)
            {
                Content = cellValue;
                Background = GetBrushColour(cellValue);
            }
        }

        private Brush GetBrushColour(string text)
        {
            switch (text)
            {
                case "X":
                    return Brushes.Red;
                case "O":
                    return Brushes.Blue;
                default:
                    return Brushes.White;
            }
        }
    }
}
