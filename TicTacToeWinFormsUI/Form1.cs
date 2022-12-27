using TicTacToeLibrary;

namespace TicTacToeWinFormsUI
{
    public partial class Form1 : Form
    {

        public Game myGame;
        public Button[] buttons;

        public Form1()
        {
            InitializeComponent();

            myGame = new Game();
            buttons = new Button[9];

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            string[] flat = FlattenGrid(myGame.grid);

            for(int i=0; i<9; i++)
            {
                buttons[i].Text = flat[i];
                buttons[i].BackColor = ChooseColour(flat[i]);
            }
        }

        private Color ChooseColour(string text)
        {
            switch (text)
            {
                case "X":
                    return Color.Red;
                case "O":
                    return Color.DodgerBlue;
                default:
                    return Color.White;
            }
        }

        private string GetButtonText(int i)
        {
            i--;
            return buttons[i].Text;
        }

        private void MakeMove(int i)
        {
            i--;
            myGame.PlaceMove(i / 3, i % 3);
        }

        private void ButtonClicked(int i)
        {
            if(GetButtonText(i) == "." && !myGame.GameOver())
            {
                MakeMove(i);
                UpdateButtons();
            }
        }

        private string[] FlattenGrid(char[,] grid)
        {
            string[] flat = new string[9];

            int p = 0;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    flat[p++] = grid[i,j].ToString();
                }
            }

            return flat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClicked(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClicked(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClicked(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClicked(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonClicked(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonClicked(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonClicked(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonClicked(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonClicked(9);
        }
    }
}