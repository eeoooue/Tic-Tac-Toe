using Game_Library;

namespace CPU_Char_Matrix
{
    internal class Solver
    {
        private MatrixJudge _judge = new MatrixJudge();

        public PlayerMove GetBestMove(char[,] gameState)
        {
            char team = GetTurnPlayer(gameState);
            MinMaxEval move = ExploreMinMax(gameState, team);

            PlayerMove bestMove = new PlayerMove(move.I, move.J, team);
            return bestMove;
        }

        private MinMaxEval ExploreMinMax(char[,] givenGameState, char team)
        {
            char turnPlayer = GetTurnPlayer(givenGameState);
            int moveCount = _judge.CountMoves(givenGameState);

            if (_judge.ContainsWinner(givenGameState))
            {
                int score = (turnPlayer == team) ? (moveCount - 255) : (255 - moveCount);
                return new MinMaxEval(0, 0, score);
            }
            else if (moveCount == 9)
            {
                return new MinMaxEval(0, 0, 0);
            }

            char[,] gameState = CopyGameState(givenGameState);

            MinMaxEval bestMove = new MinMaxEval(0, 0, -255);
            MinMaxEval worstMove = new MinMaxEval(0, 0, 255);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameState[i, j] == ' ')
                    {
                        gameState[i, j] = turnPlayer;
                        MinMaxEval projection = ExploreMinMax(gameState, team);
                        MinMaxEval evaluation = new MinMaxEval(i, j, projection.Score);
                        gameState[i, j] = ' ';

                        if (evaluation.Score > bestMove.Score)
                        {
                            bestMove = evaluation;
                        }

                        if (evaluation.Score < worstMove.Score)
                        {
                            worstMove = evaluation;
                        }
                    }
                }
            }

            return (turnPlayer == team) ? bestMove : worstMove;
        }

        private char GetTurnPlayer(char[,] gameState)
        {
            return GetTurnPlayer(_judge.CountMoves(gameState));
        }

        private char GetTurnPlayer(int moveCount)
        {
            return (moveCount % 2 == 0) ? 'X' : 'O';
        }

        private char[,] CopyGameState(char[,] gameState)
        {
            char[,] copy = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    copy[i, j] = gameState[i, j];
                }
            }

            return copy;
        }
    }
}