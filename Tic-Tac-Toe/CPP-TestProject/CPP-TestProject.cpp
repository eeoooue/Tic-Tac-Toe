// CPP-TestProject.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include "Counter.h"

using namespace std;

vector<vector <char>> unpackBoard(string line);
int CountMoves(vector<vector <char>> board);

int main()
{
    vector<vector <char>> board = unpackBoard("xoxox  ox");
    int moves = CountMoves(board);

    Counter myCounter;
    for (int i = 0; i < 5; i++) {
        myCounter.SayNumber();
    }
    

    cout << "the move count is : " << moves;
}





vector<vector <char>> unpackBoard(string line)
{
    vector<vector <char>> board(3, vector<char>(3));

    int p = 0;

    for (int i = 0; i < 3; i++) {

        for (int j = 0; j < 3; j++) {

            board[i][j] = line[p];
            cout << line[p];
            p++;
        }

        cout << endl;
    }

    return board;
}

int CountMoves(vector<vector <char>> board) {

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

