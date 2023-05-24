#pragma once
#include <vector>

using namespace std;

class Judge
{

public:

	int CountMoves(vector<vector <char>> board);
	bool FindsWinner(vector<vector <char>> board);
};

