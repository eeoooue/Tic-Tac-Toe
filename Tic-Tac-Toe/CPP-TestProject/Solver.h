#pragma once

#include "MinMaxEval.h"

#include <vector>

using namespace std;


class Solver
{
	public:
		void GetBestMove(vector<vector <char>> board);
		MinMaxEval MinMaxExplore(vector<vector <char>> board, char team, int moves);

		MinMaxEval GetDummyEval(int score);
		MinMaxEval BuildEval(int i, int j, int score);

		char GetTurnPlayer(int moves);

};

