#pragma once

#include "MinMaxEval.h"
#include "Judge.h"

#include <vector>
#include <string>

using namespace std;


class Solver
{
	private:
		Judge judge;
		
		char GetTurnPlayer(int moves);
		MinMaxEval MinMaxExplore(vector<vector <char>> board, char team, int moves);
		string UnpackEvaluation(MinMaxEval evaluation);


	public:
		string GetBestMove(vector<vector <char>> board);
};

