#include "Solver.h"
#include "Judge.h"
#include "MinMaxEval.h"

#include <vector>
#include <string>
#include <iostream>

using namespace std;

void Solver::GetBestMove(vector<vector <char>> board) {

	Judge judge;
	int moves = judge.CountMoves(board);
	char team = GetTurnPlayer(moves);

	MinMaxEval evaluation = MinMaxExplore(board, team, moves);
	string line = to_string(evaluation.i) + " " + to_string(evaluation.j);

	cout << "the best move is: " << line;
}




MinMaxEval Solver::MinMaxExplore(vector<vector <char>> board, char team, int moves) {

	char turnPlayer = GetTurnPlayer(moves);
	Judge judge;



	


	MinMaxEval bestMove = GetDummyEval(-255);
	MinMaxEval worstMove = GetDummyEval(255);

	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			if (board[i][j] == ' ') {

				board[i][j] = turnPlayer;
				MinMaxEval projection = MinMaxExplore(board, team, moves + 1);
				board[i][j] = ' ';

				MinMaxEval evaluation;
				evaluation.i = i;
				evaluation.j = j;
				evaluation.score = projection.score;

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
	} else {
		return worstMove;
	}
}



MinMaxEval Solver::BuildEval(int i, int j, int score) {

	MinMaxEval evaluation;
	evaluation.i = i;
	evaluation.j = j;
	evaluation.score = score;

	return evaluation;
}


MinMaxEval Solver::GetDummyEval(int score) {

	return BuildEval(0, 0, score);
}


char Solver::GetTurnPlayer(int moves) {

	if (moves % 2 == 0) {
		return 'X';
	}
	return 'O';
}