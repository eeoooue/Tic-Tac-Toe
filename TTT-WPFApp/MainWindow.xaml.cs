using CPU_Opponent;
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
            _myGame = new GameAgainstCPU();
            CreateButtons();
        }

        private void CreateButtons()
        {
            for(int i=0; i<3; i++)
            {
                for(int  j=0; j<3; j++)
                {
                    GameTile boardTile = _myGame.Board.GetTile(i, j);
                    ButtonTile tile = new(_myGame, this, boardTile);
                    GameBoard.Children.Add(tile);
                    Grid.SetRow(tile, boardTile.Row);
                    Grid.SetColumn(tile, boardTile.Column);
                }
            }
        }

        public void UpdateAllTiles()
        {
            foreach(ButtonTile tile in GameBoard.Children)
            {
                tile.Update();
            }
        }
    }
}
