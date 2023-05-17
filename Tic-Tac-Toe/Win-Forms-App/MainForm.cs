using CPU_Opponent;
using Game_Library;
using System.Windows.Forms;

namespace Win_Forms_App
{
    public partial class MainForm : Form
    {
        public List<ButtonTile> Buttons { get; set; }

        private TicTacToeGame _myGame = new GameAgainstCPU();

        private HashSet<Keys> _pressed = new HashSet<Keys>();
        
        public MainForm()
        {
            KeyPreview = true;
            Buttons = new List<ButtonTile>();
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            _myGame = new GameAgainstCPU();
            BuildButtons();
            UpdateAll();
        }

        private void BuildButtons()
        {
            Controls.Clear();
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

        #region keyboard commands

        protected override void OnKeyDown(KeyEventArgs e)
        {
            _pressed.Add(e.KeyCode);

            if (_pressed.Contains(Keys.Escape))
            {
                Application.Exit();
            }

            if (_pressed.Contains(Keys.ControlKey) && _pressed.Contains(Keys.N))
            {
                StartNewGame();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            _pressed.Remove(e.KeyCode);
        }

        #endregion
    }
}