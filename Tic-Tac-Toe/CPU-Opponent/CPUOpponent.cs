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

            EvaluatedMove bestMove = new EvaluatedMove(0, 0, currentPlayer, int.MinValue);
            EvaluatedMove worstMove = new EvaluatedMove(0, 0, currentPlayer, int.MaxValue);

            foreach (PlayerMove possibleMove in simulation.GetPossibleMoves())
            {
                simulation.SubmitMove(possibleMove);
                int score = ExploreMinMax(simulation, depth + 1);

                if (score > bestMove.Score)
                {
                    bestMove = new EvaluatedMove(possibleMove, score);
                }
                if (score < worstMove.Score)
                {
                    worstMove = new EvaluatedMove(possibleMove, score);
                }
                simulation.UndoPreviousMove();
            }

            if (depth == 0)
            {
                _nextMove = bestMove;
            }

            return (currentPlayer == Team) ? bestMove.Score : worstMove.Score;
        }
    }
}
