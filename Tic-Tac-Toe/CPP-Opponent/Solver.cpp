#include "pch.h"
#include "Solver.h"
#include "Judge.h"
#include "MinMaxEval.h"

#include <vector>
#include <string>

using namespace std;

string Solver::GetBestMove(const string line) {

	vector<vector <char>> board = UnpackBoard(line);
	const int moves = judge.CountMoves(board);
	const char team = GetTurnPlayer(moves);

	if (moves == 0) {
		return "1 1";
	}

	const MinMaxEval evaluation = MinMaxExplore(board, team, moves);

	return UnpackEvaluation(evaluation);
}

char Solver::GetTurnPlayer(const int moves) {

	if (moves % 2 == 0) {
		return 'X';
	}
	return 'O';
}

MinMaxEval Solver::MinMaxExplore(vector<vector <char>> board, const char team, const int moves) {

	const char turnPlayer = GetTurnPlayer(moves);

	if (moves > 4) {

		if (judge.FindsWinner(board)) {

			if (turnPlayer == team) {
				return MinMaxEval{ 0, 0, moves - 255 };
			}
			else {
				return MinMaxEval{ 0, 0, 255 - moves };
			}
		}

		if (moves == 9) {
			return MinMaxEval{ 0, 0, 0 };
		}
	}

	MinMaxEval bestMove = { 0, 0, -255 };
	MinMaxEval worstMove = { 0, 0, 255 };

	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			if (board[i][j] == ' ') {

				board[i][j] = turnPlayer;
				const MinMaxEval projection = MinMaxExplore(board, team, moves + 1);
				const MinMaxEval evaluation = { i, j, projection.score };
				board[i][j] = ' ';

				if (evaluation.score > bestMove.score) {
					bestMove = evaluation;
				}

				if (evaluation.score < worstMove.score) {
					worstMove = evaluation;
				}
			}
		}
	}

	if (turnPlayer == team) {
		return bestMove;
	}
	else {
		return worstMove;
	}
}


vector<vector <char>> Solver::UnpackBoard(const string line)
{
	vector<vector <char>> board(3, vector<char>(3));

	int p = 0;

	for (int i = 0; i < 3; i++) {

		for (int j = 0; j < 3; j++) {

			board[i][j] = line[p];
			p++;
		}
	}

	return board;
}


string Solver::UnpackEvaluation(const MinMaxEval evaluation) {

	const string line = to_string(evaluation.i) + " " + to_string(evaluation.j);
	return line;
}


