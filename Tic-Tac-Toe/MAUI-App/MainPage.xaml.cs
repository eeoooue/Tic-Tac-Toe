using CPU_Opponent;
using Game_Library;

namespace MAUI_App
{
    public partial class MainPage : ContentPage
    {

        private TicTacToeGame _myGame;

        private List<ButtonTile> _buttonTiles = new List<ButtonTile>();

        public MainPage()
        {
            InitializeComponent();
            _myGame = new GameAgainstOpponent(new CPUOpponent('O'));
            CreateButtons();
        }

        private void CreateButtons()
        {
            _buttonTiles.Clear();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile tile = _myGame.Board.GetTile(i, j);
                    ButtonTile button = new(_myGame, this, tile);
                    GameBoard.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    _buttonTiles.Add(button);
                }
            }
        }
    }
}