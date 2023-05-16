using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class GameBoard
    {
        protected int _rows = 3;
        protected int _cols = 3;

        protected AbstractTile[,] _tiles = new AbstractTile[3, 3];

        public GameBoard(TicTacToeGame myGame) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tiles[i, j] = new ClickableTile(myGame, i, j);
                }
            }
        }

        public AbstractTile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }
    }
}
