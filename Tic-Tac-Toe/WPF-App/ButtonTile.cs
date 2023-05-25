using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace WPF_App
{
    internal class ButtonTile : Button, Observer
    {
        private GameTile _tile;
        private TicTacToeGame _game;
        private MainWindow _mainWindow;

        private char Character { get { return _tile.Character; } }
        private bool GameOver { get { return _game.GameOver; } }
        private bool Marked { get; set; }
        private bool WinningTile { get { return GameOver && (Character == _game.Winner); } }

        public ButtonTile(TicTacToeGame game, MainWindow mainWindow, GameTile original)
        {
            Width = 80;
            Height = 80;
            FontSize = 50;
            Foreground = Brushes.White;

            _game = game;
            _mainWindow = mainWindow;
            _tile = original;
            _game.Attach(this);
            Marked = false;

            Update();
        }

        protected override void OnClick()
        {
            _tile.Click();
        }

        public void Update()
        {
            if (_tile.Marked && !Marked)
            {
                Mark();
                _mainWindow.Update();
            }

            if (GameOver && !WinningTile)
            {
                ShowLosingAppearance();
            }
        }

        private void ShowLosingAppearance()
        {
            Foreground = Brushes.DarkGray;
            Background = Brushes.White;
        }

        private void Mark()
        {
            Content = Character;
            Background = Brushes.White;

            if (Character == 'X')
            {
                Background = Brushes.PaleVioletRed;
            }
            else if (Character == 'O')
            {
                Background = Brushes.CornflowerBlue;
            }

            Marked = true;
        }
    }
}
