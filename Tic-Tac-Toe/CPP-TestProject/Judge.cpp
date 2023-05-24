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



    return true;
}