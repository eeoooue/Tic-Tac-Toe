using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Char_Matrix
{
    internal readonly struct MinMaxEval
    {
        public readonly int i;
        public readonly int j;
        public readonly int score;

        public MinMaxEval(int i, int j, int score)
        {
            this.i = i;
            this.j = j;
            this.score = score;
        }
    }
}
