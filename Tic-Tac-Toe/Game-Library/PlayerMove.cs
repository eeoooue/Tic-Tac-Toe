using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class PlayerMove
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char Team { get; private set; }

        public PlayerMove(int i, int j, char team)
        {
            Row = i;
            Column = j;
            Team = team;
        }
    }
}
