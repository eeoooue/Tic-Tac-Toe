using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPP_Wrapper
{
    public class WrappedSolver
    {
        [DllImport("CPPOpponent.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetMoveString(int boardStateInt);

        private char Team { get; set; }

        public WrappedSolver(char team)
        {
            Team = team;
        }

        public PlayerMove GetBestMove(int boardStateInt)
        {
            int value = GetMoveString(boardStateInt);
            int i = value / 10;
            int j = value % 10;

            return new PlayerMove(i, j, Team);
        }
    }
}
