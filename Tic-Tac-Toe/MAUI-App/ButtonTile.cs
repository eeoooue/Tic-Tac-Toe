using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_App
{
    internal class ButtonTile : Button
    {

        public ButtonTile()
        {
            Text = "X";
            FontSize = 50;
            Clicked += ClickAction;
        }

        private void ClickAction(object sender, EventArgs e)
        {
            Text = "O";
        }

    }
}
