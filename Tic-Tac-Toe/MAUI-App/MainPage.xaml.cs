﻿using CPU_Opponent;
using Game_Library;

namespace MAUI_App
{
    public partial class MainPage : ContentPage
    {

        private TicTacToeGame _myGame;

        public MainPage()
        {
            InitializeComponent();
            _myGame = new TicTacToeGame();
            CreateButtons();
        }

        private void CreateButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile tile = _myGame.Board.GetTile(i, j);
                    ButtonTile button = new(_myGame, tile);
                    GameBoard.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }
        }

    }
}