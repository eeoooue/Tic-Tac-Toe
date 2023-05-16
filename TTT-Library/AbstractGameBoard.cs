using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public abstract class AbstractGameBoard
    {
        protected AbstractTile[,] _tiles = new AbstractTile[3, 3];

        public AbstractGameBoard() { }

        public AbstractTile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }
    }
}
