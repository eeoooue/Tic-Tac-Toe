using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP_Wrapper
{
    public class CPPOpponent : Opponent
    {
        private WrappedSolver Solver { get; set; }

        public CPPOpponent(char team) : base(team)
        {
            Solver = new WrappedSolver(team);
        }

        public override PlayerMove MakeMove(TicTacToeGame game)
        {
            string boardState = GetBoardstateString(game.Board);
            return Solver.GetBestMove(boardState);
        }

        private string GetBoardstateString(GameBoard board)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile tile = board.GetTile(i, j);
                    sb.Append(tile.Character);
                }
            }

            return sb.ToString();
        }
    }
}
