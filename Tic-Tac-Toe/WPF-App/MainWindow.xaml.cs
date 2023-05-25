using CPP_Wrapper;
using CPU_Opponent;
using Game_Library;
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

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TicTacToeGame _myGame;

        private HashSet<Key> _pressed = new HashSet<Key>();

        public MainWindow()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(KeyDownListener);
            KeyUp += new KeyEventHandler(KeyUpListener);
            _myGame = new GameAgainstOpponent(new CPPOpponent('O'));
            CreateButtons();
        }

        private void CreateButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile boardTile = _myGame.Board.GetTile(i, j);
                    ButtonTile tile = new(_myGame, this, boardTile);
                    GameBoard.Children.Add(tile);
                    Grid.SetRow(tile, boardTile.Row);
                    Grid.SetColumn(tile, boardTile.Column);
                }
            }
        }

        private void StartNewGame()
        {
            GameBoard.Children.Clear();
            _myGame = new GameAgainstOpponent(new CPUOpponent('O'));
            CreateButtons();
        }

        #region keyboard commands

        private void KeyDownListener(object sender, KeyEventArgs e)
        {
            _pressed.Add(e.Key);

            switch (e.Key)
            {
                case Key.N:
                    UserShortcutNewGame();
                    return;

                case Key.Escape:
                    UserShortcutQuitGame();
                    return;

                default:
                    return;
            }
        }

        private void KeyUpListener(object sender, KeyEventArgs e)
        {
            if (_pressed.Contains(e.Key))
            {
                _pressed.Remove(e.Key);
            }
        }

        void UserShortcutNewGame()
        {
            if ((_pressed.Contains(Key.LeftCtrl) || _pressed.Contains(Key.RightCtrl)) && _pressed.Contains(Key.N))
            {
                StartNewGame();
            }
        }

        void UserShortcutQuitGame()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
