using Game_Library;

namespace CPU_Char_Matrix
{
    internal class CharArraySolver
    {
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
            int moveCount = CountMoves(givenGameState);

            if (ContainsWinner(givenGameState))
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
            int moveCount = CountMoves(gameState);
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

        private int CountMoves(char[,] game)
        {
            int count = 0;
            foreach (char c in game)
            {
                if (c != ' ')
                {
                    count++;
                }
            }

            return count;
        }

        private bool ContainsWinner(char[,] game)
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsWinningRow(game, i) || IsWinningColumn(game, i))
                {
                    return true;
                }
            }

            if (HasWinningDiagonal(game))
            {
                return true;
            }

            return false;
        }

        private bool IsWinningRow(char[,] game, int i)
        {
            char team = game[i, 0];

            if (team == ' ')
            {
                return false;
            }

            return (game[i, 1] == team && game[i, 2] == team);
        }

        private bool IsWinningColumn(char[,] game, int j)
        {
            char team = game[0, j];

            if (team == ' ')
            {
                return false;
            }

            return (game[1, j] == team && game[2, j] == team);
        }

        private bool HasWinningDiagonal(char[,] game)
        {
            char team = game[1, 1];

            if (team == ' ')
            {
                return false;
            }
            if (game[0, 0] == team && game[2, 2] == team)
            {
                return true;
            }
            else if (game[0, 2] == team && game[2, 0] == team)
            {
                return true;
            }
            return false;
        }
    }
}