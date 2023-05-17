namespace Win_Forms_App
{
    public partial class MainForm : Form
    {
        public List<ButtonTile> Buttons { get; set; }

        public MainForm()
        {
            InitializeComponent();
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
                    ButtonTile btn = new ButtonTile(i, j);
                   
                    int x_position = 240 + (115 * j);
                    int y_position = 65 + (115 * i);
                    btn.Location = new Point(x_position, y_position);
                    Buttons.Add(btn);
                    Controls.Add(btn);
                }
            }
        }
    }
}