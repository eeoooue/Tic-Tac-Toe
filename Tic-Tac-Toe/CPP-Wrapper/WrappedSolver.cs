using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPP_Wrapper
{
    internal class WrappedSolver
    {
        [DllImport("CPPOpponent.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int fnCPPOpponent();

        private char Team { get; set; }

        public WrappedSolver(char team)
        {
            Team = team;
        }

        public PlayerMove GetBestMove(string boardState)
        {
            string move = "0 0";
            return ParseMove(move);
        }

        private PlayerMove ParseMove(string moveString)
        {
            string[] arr = moveString.Split(' ');
            int i = int.Parse(arr[0]);
            int j = int.Parse(arr[1]);

            return new PlayerMove(i, j, Team);
        }
    }
}
