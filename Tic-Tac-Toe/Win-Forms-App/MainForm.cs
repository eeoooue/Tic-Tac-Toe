using CPU_Opponent;
using Game_Library;

namespace Win_Forms_App
{
    public partial class MainForm : Form
    {
        public TicTacToeGame _myGame;
        public List<ButtonTile> Buttons { get; set; }

        public MainForm()
        {
            InitializeComponent();
            _myGame = new GameAgainstCPU();
            Buttons = new List<ButtonTile>();
            BuildButtons();
        }

        private void BuildButtons()
        {
            Buttons = new List<ButtonTile>();

            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    GameTile boardTile = _myGame.Board.GetTile(i, j);
                    ButtonTile btn = new(_myGame, this, boardTile);
                    
                    int x_position = 240 + (115 * j);
                    int y_position = 65 + (115 * i);
                    btn.Location = new Point(x_position, y_position);
                    Buttons.Add(btn);
                    Controls.Add(btn);
                }
            }
        }

        public void UpdateAll()
        {
            foreach(ButtonTile btn in Buttons)
            {
                btn.UpdateMe();
            }
        }
    }
}