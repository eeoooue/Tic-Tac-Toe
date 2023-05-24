using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public readonly struct PlayerMove
    {
        public readonly int row;
        public readonly int column;
        public readonly char team;
        public PlayerMove(int row, int column, char team)
        {
            this.row = row;
            this.column = column;
            this.team = team;
        }
    }
}
