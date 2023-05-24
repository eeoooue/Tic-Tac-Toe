// CPP-TestProject.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>

#include "Solver.h"

using namespace std;

vector<vector <char>> unpackBoard(string line);

// tried unpackBoard("         "); > said 0 0
// tried unpackBoard("XO       "); > said 1 0
// tried unpackBoard("XO X  O  "); > said 1 1
// tried unpackBoard("XO XXOO  "); > said 2 2

int main()
{
    vector<vector <char>> board = unpackBoard("XO XXOO  ");
    Solver solver;

    string line = solver.GetBestMove(board);

    cout << "the best move is: " << line;
    cout << endl;
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

