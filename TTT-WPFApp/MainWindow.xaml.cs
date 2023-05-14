using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TTT_Library;

namespace TTT_WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TicTacToeGame _myGame;

        public MainWindow()
        {
            InitializeComponent();
            _myGame = new TicTacToeGame();
            CreateButtons();
        }

        private void CreateButtons()
        {
            foreach(BoardTile boardTile in _myGame.Tiles)
            {
                GameTile tile = new(boardTile);
                GameBoard.Children.Add(tile);
                Grid.SetRow(tile, boardTile.Row);
                Grid.SetColumn(tile, boardTile.Column);
            }
        }
    }
}
