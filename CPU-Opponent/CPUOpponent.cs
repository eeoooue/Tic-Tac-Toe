using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    public class CPUOpponent
    {
        public char CPUTeam { get; private set; }

        private readonly TicTacToeGame _game;

        private PlayerMove _nextMove = new PlayerMove(0, 0, 'O');

        public CPUOpponent(TicTacToeGame game)
        {
            CPUTeam = 'O';
            _game = game;
        }

        public void MakeMove()
        {
            PlayerMove bestMove = GetBestMove();
            _game.SubmitMove(bestMove);
        }

        private PlayerMove GetBestMove()
        {
            CPUTeam = _game.CurrentPlayer;

            GameSimulation simulation = new GameSimulation(_game);
            
            ExploreMinMax(simulation, 0);

            return _nextMove;
        }

        private int ExploreMinMax(GameSimulation simulation, int depth)
        {
            char currentPlayer = simulation.CurrentPlayer;

            if (simulation.GameOver())
            {
                if (simulation.WinnerExists())
                {
                    if (currentPlayer == CPUTeam)
                    {
                        return -(20 + depth);
                    }
                    else
                    {
                        return 20 - depth;
                    }
                }

                return 0;
            }

            EvaluatedMove bestMove = new EvaluatedMove(0, 0, currentPlayer, int.MinValue);
            EvaluatedMove worstMove = new EvaluatedMove(0, 0, currentPlayer, int.MaxValue);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    PlayerMove projectedMove = new PlayerMove(i, j, currentPlayer);

                    if (simulation.SubmitMove(projectedMove))
                    {
                        int score = ExploreMinMax(simulation, depth + 1);

                        if (score > bestMove.Score)
                        {
                            bestMove = new EvaluatedMove(projectedMove, score);
                        }

                        if (score < worstMove.Score)
                        {
                            worstMove = new EvaluatedMove(projectedMove, score);
                        }

                        simulation.UndoPreviousMove();
                    }
                }
            }

            if (depth == 0)
            {
                _nextMove = bestMove;
            }

            return (currentPlayer == CPUTeam) ? bestMove.Score : worstMove.Score;
        }
    }
}
