using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Forms_App
{
    public class ButtonTile : Button
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public ButtonTile(int i, int j)
        {
            Row = i;
            Column = j;
            Font = new Font("Microsoft Sans Serif", 36F);
            Size = new Size(100, 100);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Text = "X";
        }
    }
}
