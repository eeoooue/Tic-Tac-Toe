using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class TicTacToeGame
    {
        public GameBoard gameboard;
        public int moves = 0;

        public TicTacToeGame()
        {
            gameboard = new GameBoard();
        }

        public void AttemptMove(int i, int j)
        {
            if (gameboard.CanMove(i, j))
            {
                char stone = (moves++ % 2 == 0) ? 'X' : 'O';
                gameboard.PlaceMove(i, j, stone);
            }
        }

        public bool HasWinner()
        {
            return Judge.HasWinner(gameboard);
        }

        public bool GameOver()
        {
            return (moves == 9 || HasWinner());
        }
    }
}
