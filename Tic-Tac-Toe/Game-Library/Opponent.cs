using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public abstract class Opponent
    {
        public char Team { get; private set; }

        public Opponent(char team)
        {
            Team = team;
        }

        public abstract PlayerMove MakeMove(TicTacToeGame game);
    }
}
