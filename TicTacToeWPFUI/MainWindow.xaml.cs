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
using TicTacToeLibrary;

namespace TicTacToeWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game myGame;
        public Button[] buttons;

        public MainWindow()
        {
            InitializeComponent();

            myGame = new Game();
            buttons = new Button[9];

            CreateButtons();
            UpdateButtons();
        }

        private void CreateButtons()
        {
            int b = 0;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Button button = new Button()
                    {
                        Content = "",
                        Width = 80,
                        Height = 80,
                        FontSize = 36,
                        Foreground = Brushes.White,
                    };
                    
                    GameBoard.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    button.Click += Button_Click;
                    buttons[b++] = button;
                }
            }
        }

        private void UpdateButtons()
        {

            string[] flat = FlattenGrid(myGame.grid);

            for(int i=0; i<9; i++)
            {
                buttons[i].Content = flat[i];
                buttons[i].Background = GetBrushColour(flat[i]);
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

        private string[] FlattenGrid(char[,] grid)
        {
            string[] flat = new string[9];

            int p = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    flat[p++] = grid[i, j].ToString();
                }
            }
            return flat;
        }

        private string GetButtonText(int i)
        {
            return (string)buttons[i].Content;
        }

        private void ButtonClicked(int i)
        {
            if (GetButtonText(i) == "." && !myGame.GameOver())
            {
                myGame.PlaceMove(i / 3, i % 3);
                UpdateButtons();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<9; i++)
            {
                if(sender == buttons[i])
                {
                    ButtonClicked(i);
                }
            }
        }        
    }
}
