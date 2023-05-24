using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Char_Matrix
{
    public class CharArrayOpponent : Opponent
    {
        private Solver _solver = new Solver();

        public CharArrayOpponent(char team) : base(team) { }

        public override PlayerMove MakeMove(TicTacToeGame game)
        {
            char[,] board = DeriveCharArray(game.Board);
            PlayerMove move = _solver.GetBestMove(board);
            return move;
        }

        private char[,] DeriveCharArray(GameBoard gameBoard)
        {
            char[,] board = new char[3,3];

            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    GameTile tile = gameBoard.GetTile(i, j);
                    board[i, j] = tile.Character;
                }
            }

            return board;
        }
    }
}
