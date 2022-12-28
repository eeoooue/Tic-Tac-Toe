using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class Judge
    {
        public static bool HasWinner(GameBoard gameboard)
        {
            foreach (char[] line in gameboard.GetPossibleWinningLines())
            {
                if (IsWinningLine(line))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsWinningLine(char[] line)
        {
            Dictionary<char, int> table = new Dictionary<char, int>()
            {
                { '.', 0 },
                { 'X', 0 },
                { 'O', 0 },
            };

            foreach (char x in line)
            {
                table[x] += 1;
            }
            return (table['X'] == 3 || table['O'] == 3);
        }
    }
}
