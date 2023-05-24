using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Char_Matrix
{
    internal class MinMaxEval
    {
        // in cpp we'll just do this with a string or a struct
        public int I { get; private set; }
        public int J { get; private set; }
        public int Score { get; private set; }

        public MinMaxEval(int i, int j, int score)
        {
            I = i;
            J = j;
            Score = score;
        }
    }
}
