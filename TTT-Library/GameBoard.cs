using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class GameBoard : AbstractGameBoard
    {
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
    }
}
