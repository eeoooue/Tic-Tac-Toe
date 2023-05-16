﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class CPUOpponent
    {
        public char CPUTeam { get; private set; }

        private readonly AnalysisBoard _analysisBoard = new AnalysisBoard();

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

            BoardTile tile = _game.Tiles[bestMove.Row, bestMove.Column];
            tile.Click();
        }

        private PlayerMove GetBestMove()
        {
            _analysisBoard.MirrorBoardState(_game.Board);
            CPUTeam = _analysisBoard.GetCurrentPlayer();

            ExploreMinMax(0);

            return _nextMove;
        }

        private int ExploreMinMax(int depth)
        {
            char currentPlayer = _analysisBoard.GetCurrentPlayer();

            if (_analysisBoard.GameOver())
            {
                // if X won

                // if O won

                // if it was a draw

                if (_analysisBoard.WinnerExists())
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

                    if (_analysisBoard.SubmitMove(projectedMove))
                    {
                        int score = ExploreMinMax(depth + 1);

                        if (score > bestMove.Score)
                        {
                            bestMove = new EvaluatedMove(projectedMove, score);
                        }

                        if (score < worstMove.Score)
                        {
                            worstMove = new EvaluatedMove(projectedMove, score);
                        }

                        _analysisBoard.UndoPreviousMove();
                    }
                }
            }

            if (depth == 0)
            {
                _nextMove = bestMove;
            }

            if (currentPlayer == CPUTeam)
            {
                return bestMove.Score;
            }
            else
            {
                return worstMove.Score;
            }
        }
    }
}
