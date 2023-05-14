using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class GameBoard
    {
        public BoardTile[,] tiles = new BoardTile[3, 3];

        public GameBoard(TicTacToeGame myGame) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = new BoardTile(myGame, i, j);
                }
            }
        }
    }
}
