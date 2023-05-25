#pragma once
#include <vector>

using namespace std;

class Judge
{

private:
	bool IsWinningRow(const vector<vector <char>> board, const int i);
	bool IsWinningColumn(const vector<vector <char>> board, const int j);
	bool HasWinningDiagonal(const vector<vector <char>> board);

public:
	int CountMoves(const vector<vector <char>> board);
	bool WinningMove(const vector<vector <char>> board, const int i, const int j);
};

