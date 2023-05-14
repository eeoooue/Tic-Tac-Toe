using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string Text { get { return _myGame.GetCellText(Row, Column); } }

        public GameTile(TicTacToeGame myGame, int i, int j)
        {
            _myGame = myGame;
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
            Content = Text;
            Background = GetBackgroundColour(Text);
        }

        private Brush GetBackgroundColour(string text)
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
