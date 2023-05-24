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

    if (bestMove == "0 0") {
        return 0;
    }

    if (bestMove == "0 1") {
        return 1;
    }

    if (bestMove == "0 2") {
        return 2;
    }

    if (bestMove == "1 0") {
        return 10;
    }

    if (bestMove == "1 1") {
        return 11;
    }

    if (bestMove == "1 2") {
        return 12;
    }

    if (bestMove == "2 0") {
        return 20;
    }

    if (bestMove == "2 1") {
        return 21;
    }

    if (bestMove == "2 2") {
        return 22;
    }

    return 0;
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