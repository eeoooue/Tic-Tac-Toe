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
        public CPUOpponent(char team) : base(team) { }

        public override PlayerMove MakeMove(TicTacToeGame game)
        {
            SimulationGame simulation = new SimulationGame(game);
            MinMaxEval evaluation = ExploreMinMax(simulation, 0);

            return new PlayerMove(evaluation.i, evaluation.j, Team);
        }

        private MinMaxEval ExploreMinMax(SimulationGame simulation, int depth)
        {
            char currentPlayer = simulation.CurrentPlayer;

            if (simulation.WinnerExists)
            {
                int score = (currentPlayer == Team) ? (depth - 255) : (255 - depth);
                return new MinMaxEval(0, 0, score);
            }
            else if (simulation.MoveCount == 9)
            {
                return new MinMaxEval(0, 0, 0);
            }

            MinMaxEval bestMove = new MinMaxEval(0, 0, int.MinValue);
            MinMaxEval worstMove = new MinMaxEval(0, 0, int.MaxValue);

            foreach (PlayerMove possibleMove in simulation.GetPossibleMoves())
            {
                simulation.SubmitMove(possibleMove);
                MinMaxEval projection = ExploreMinMax(simulation, depth + 1);
                MinMaxEval evaluation = new MinMaxEval(possibleMove, projection.score);
                simulation.UndoPreviousMove();

                if (evaluation.score > bestMove.score)
                {
                    bestMove = evaluation;
                }
                if (evaluation.score < worstMove.score)
                {
                    worstMove = evaluation;
                }
            }

            return (currentPlayer == Team) ? bestMove : worstMove;
        }
    }
}
