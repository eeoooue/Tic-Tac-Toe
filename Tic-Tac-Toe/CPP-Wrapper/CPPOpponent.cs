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
            int boardStateInt = GetBoardstateInt(game.Board);
            return Solver.GetBestMove(boardStateInt);
        }

        private int GetBoardstateInt(GameBoard board)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameTile tile = board.GetTile(i, j);
                    char digit = GetBoardstateChar(tile.Character);
                    sb.Append(digit);
                }
            }

            string stateString = sb.ToString();
            return int.Parse(stateString);
        }

        private char GetBoardstateChar(char team)
        {
            switch (team)
            {
                case 'X':
                    return '1';
                case 'O':
                    return '2';
                default:
                    return '0';
            }
        }
    }
}
