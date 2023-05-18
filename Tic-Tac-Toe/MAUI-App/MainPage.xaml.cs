﻿namespace MAUI_App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CreateButtons();
        }

        private void CreateButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ButtonTile tile = new();
                    GameBoard.Children.Add(tile);
                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);
                }
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

        }
    }
}