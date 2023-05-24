// CPP-TestProject.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>

#include "Solver.h"

using namespace std;

// tried unpackBoard("         "); > said 0 0
// tried unpackBoard("XO       "); > said 1 0
// tried unpackBoard("XO X  O  "); > said 1 1
// tried unpackBoard("XO XXOO  "); > said 2 2

int main()
{
    Solver solver;
    string boardState = "         ";

    string bestMove = solver.GetBestMove(boardState);

    cout << "the best move is: " << bestMove;
    cout << endl;
}

