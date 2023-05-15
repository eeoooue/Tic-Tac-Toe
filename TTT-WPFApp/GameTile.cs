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
        private TicTacToeGame _myGame;
        private MainWindow _mainWindow;

        public GameTile(TicTacToeGame myGame, MainWindow mainWindow, BoardTile original)
        {
            Width = 80;
            Height = 80;
            FontSize = 50;
            Foreground = Brushes.White;

            _myGame = myGame;
            _mainWindow = mainWindow;
            _boardTile = original;
            Update();
        }

        protected override void OnClick()
        {
            _boardTile.Click();
            Update();
            if (_myGame.GameOver)
            {
                _mainWindow.UpdateAllTiles();
            }
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
