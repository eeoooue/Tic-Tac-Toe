using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPP_Wrapper
{
    public class CPPOpponent : Opponent
    {
        [DllImport("CPPOpponent.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetMoveString(int boardStateInt);

        private Dictionary<char, char> CharTable { get; set; }

        public CPPOpponent(char team) : base(team)
        {
            CharTable = new Dictionary<char, char>();
            CharTable[' '] = '0';
            CharTable['X'] = '1';
            CharTable['O'] = '2';
        }

        public override PlayerMove MakeMove(TicTacToeGame game)
        {
            string boardState = DigitizeBoard(game.Board);
            int value = GetMoveString(int.Parse(boardState));
            int i = value / 10;
            int j = value % 10;

            return new PlayerMove(i, j, Team);
        }

        public string DigitizeBoard(GameBoard board)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile tile = board.GetTile(i, j);
                    char digit = CharTable[tile.Character];
                    sb.Append(digit);
                }
            }

            return sb.ToString();
        }
    }
}
