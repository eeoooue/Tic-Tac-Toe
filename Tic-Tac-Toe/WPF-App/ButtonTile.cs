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

namespace WPF_App
{
    internal class ButtonTile : Button, Observer
    {
        private GameTile _boardTile;
        private TicTacToeGame _myGame;
        private MainWindow _mainWindow;

        public ButtonTile(TicTacToeGame myGame, MainWindow mainWindow, GameTile original)
        {
            Width = 80;
            Height = 80;
            FontSize = 50;
            Foreground = Brushes.White;

            _myGame = myGame;
            _mainWindow = mainWindow;
            _boardTile = original;
            _myGame.Attach(this);

            Update();
        }

        protected override void OnClick()
        {
            _boardTile.Click();
        }

        public void Update()
        {
            SetTeamAppearance();
            if (_myGame.GameOver && !IsWinningTile())
            {
                SetLosingAppearance();
            }
        }

        private bool IsWinningTile()
        {
            return (_boardTile.Character == _myGame.Winner);
        }

        private void SetLosingAppearance()
        {
            Foreground = Brushes.DarkGray;
            Background = Brushes.White;
        }

        private void SetTeamAppearance()
        {
            Content = _boardTile.Character;
            Background = Brushes.White;

            if (_boardTile.Character == 'X')
            {
                Background = Brushes.PaleVioletRed;
            }
            else if (_boardTile.Character == 'O')
            {
                Background = Brushes.CornflowerBlue;
            }
        }
    }
}
