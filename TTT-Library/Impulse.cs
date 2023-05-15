using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class Impulse
    {
        private int _deltaI;
        private int _deltaJ;
        public Impulse(int di, int dj)
        {
            _deltaI = di;
            _deltaJ = dj;
        }

        public void Translate(ref int i, ref int j)
        {
            i += _deltaI;
            j += _deltaJ;
        }
    }
}
