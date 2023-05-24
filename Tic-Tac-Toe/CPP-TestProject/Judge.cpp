#include "Judge.h"
#include <vector>

using namespace std;


int Judge::CountMoves(vector<vector <char>> board) {

    int count = 0;

    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {

            if (board[i][j] != ' ') {
                count++;
            }
        }
    }

    return count;
}


bool Judge::FindsWinner(vector<vector <char>> board) {

    for (int i = 0; i < 3; i++) {

        if (IsWinningRow(board, i)) {
            return true;
        }

        if (IsWinningColumn(board, i)) {
            return true;
        }
    }

    return HasWinningDiagonal(board);
}


bool Judge::IsWinningRow(vector<vector <char>> board, int i) {

    char team = board[i][0];

    if (team == ' ') {
        return false;
    }

    if (board[i][1] == team) {
        if (board[i][2] == team) {
            return true;
        }
    }

    return false;
}


bool Judge::IsWinningColumn(vector<vector <char>> board, int j) {

    char team = board[0][j];

    if (team == ' ') {
        return false;
    }

    if (board[1][j] == team) {
        if (board[2][j] == team) {
            return true;
        }
    }

    return false;
}


bool Judge::HasWinningDiagonal(vector<vector <char>> board) {

    char team = board[1][1];

    if (team == ' ') {
        return false;
    }

    if (board[0][0] == team) {
        if (board[2][2] == team) {
            return true;
        }
    }

    if (board[0][2] == team) {
        if (board[2][0] == team) {
            return true;
        }
    }

    return false;
}
