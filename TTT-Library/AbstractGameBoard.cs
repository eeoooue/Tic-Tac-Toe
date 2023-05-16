using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public abstract class AbstractGameBoard
    {
        protected int _rows = 3;
        protected int _cols = 3;

        protected AbstractTile[,] _tiles = new AbstractTile[3, 3];

        public AbstractTile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }
    }
}
