using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class GameBoard
    {
        public BoardTile[,] Tiles { get; private set; } 

        public GameBoard(TicTacToeGame myGame) 
        {
            Tiles = new BoardTile[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Tiles[i, j] = new BoardTile(myGame, i, j);
                }
            }
        }

        public BoardTile GetTile(int i, int j)
        {
            return Tiles[i, j];
        }
    }
}
