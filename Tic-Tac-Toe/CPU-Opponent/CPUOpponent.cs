using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Opponent
{
    public class CPUOpponent : Opponent
    {
        private PlayerMove _nextMove;

        public CPUOpponent(char team) : base(team)
        {
            _nextMove = new PlayerMove(0, 0, Team);
        }

        public override PlayerMove MakeMove(TicTacToeGame game)
        {
            SimulationGame simulation = new SimulationGame(game);
            ExploreMinMax(simulation, 0);

            return _nextMove;
        }

        private int ExploreMinMax(SimulationGame simulation, int depth)
        {
            char currentPlayer = simulation.CurrentPlayer;

            if (simulation.WinnerExists)
            {
                if (currentPlayer == Team)
                {
                    return depth - 255;
                }
                else
                {
                    return 255 - depth;
                }
            }
            else if (simulation.MoveCount == 9)
            {
                return 0;
            }

            MinMaxEval bestMove = new MinMaxEval(0, 0, int.MinValue);
            MinMaxEval worstMove = new MinMaxEval(0, 0, int.MaxValue);

            foreach (PlayerMove possibleMove in simulation.GetPossibleMoves())
            {
                simulation.SubmitMove(possibleMove);
                int score = ExploreMinMax(simulation, depth + 1);

                if (score > bestMove.score)
                {
                    bestMove = new MinMaxEval(possibleMove, score);
                }
                if (score < worstMove.score)
                {
                    worstMove = new MinMaxEval(possibleMove, score);
                }
                simulation.UndoPreviousMove();
            }

            if (depth == 0)
            {
                _nextMove = new PlayerMove(bestMove.i, bestMove.j, Team);
            }

            return (currentPlayer == Team) ? bestMove.score : worstMove.score;
        }
    }
}
