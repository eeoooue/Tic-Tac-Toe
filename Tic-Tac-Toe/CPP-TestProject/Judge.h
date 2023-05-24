#pragma once
#include <vector>

using namespace std;

class Judge
{

public:

	int CountMoves(vector<vector <char>> board);
	bool FindsWinner(vector<vector <char>> board);
	bool IsWinningRow(vector<vector <char>> board, int i);
	bool IsWinningColumn(vector<vector <char>> board, int j);
	bool HasWinningDiagonal(vector<vector <char>> board);
};

