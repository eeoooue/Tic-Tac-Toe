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
            // string move = "0 0";

            int val = GetMoveString(boardStateInt);
            string move = ParseDigits(val);
            return ParseMove(move);
        }

        private string ParseDigits(int input)
        {
            switch (input)
            {
                case 0:
                    return "0 0";
                case 1:
                    return "0 1";
                case 2:
                    return "0 2";
                case 10:
                    return "1 0";
                case 11:
                    return "1 1";
                case 12:
                    return "1 2";
                case 20:
                    return "2 0";
                case 21:
                    return "2 1";
                case 22:
                    return "2 2";
                default:
                    return "0 0";
            }
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
