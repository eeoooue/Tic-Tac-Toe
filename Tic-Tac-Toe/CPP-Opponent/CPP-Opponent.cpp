// CPP-Opponent.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "framework.h"
#include "CPP-Opponent.h"
#include <string>
#include "Solver.h"

using namespace std;

string ParseStateInt(int boardStateInt);
int ConvertMove(string move);

// This is an exported function.
extern "C" CPPOPPONENT_API int GetMoveString(int boardstate)
{
    string board = ParseStateInt(boardstate);

    Solver solver{};
    string bestMove = solver.GetBestMove(board);

    return ConvertMove(bestMove);
}

int ConvertMove(string bestMove) {

    string build;
    build += bestMove[0];
    build += bestMove[2];

    return stoi(build);
}

string ParseStateInt(int boardstate) {

    const string s = to_string(boardstate);
    const int n = s.length();

    string build = "";
    for (int i = n; i < 9; i++) {
        build = build + " ";
    }

    for (int i = 0; i < n; i++) {
        char digit = s[i];
        if (digit == '1') {
            build = build + "X";
        } else if (digit == '2') {
            build = build + "O";
        } else {
            build = build + " ";
        }
    }

    return build;
}