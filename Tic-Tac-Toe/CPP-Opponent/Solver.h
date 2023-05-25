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
	char GetTurnPlayer(const int moves);
	MinMaxEval MinMaxExplore(vector<vector <char>> board, const char team, const int moves, const int prevRow, const int prevCol);
	vector<vector <char>> UnpackBoard(const string line);
	string UnpackEvaluation(const MinMaxEval evaluation);

public:
	string GetBestMove(const string line);
};

