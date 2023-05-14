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
        private BoardTile _boardTile;

        public GameTile(BoardTile original)
        {
            Width = 80;
            Height = 80;
            FontSize = 42;
            Foreground = Brushes.White;

            _boardTile = original;
            UpdateMe();
        }

        protected override void OnClick()
        {
            _boardTile.Click();
            UpdateMe();
        }

        public void UpdateMe()
        {
            Content = _boardTile.Character.ToString();
            Background = GetBackgroundColour();
        }

        private Brush GetBackgroundColour()
        {
            switch (_boardTile.Character)
            {
                case 'X':
                    return Brushes.Red;
                case 'O':
                    return Brushes.Blue;
                default:
                    return Brushes.White;
            }
        }
    }
}
