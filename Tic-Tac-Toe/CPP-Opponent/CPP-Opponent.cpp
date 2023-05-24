// CPP-Opponent.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "framework.h"
#include "CPP-Opponent.h"
#include <string>
#include "Solver.h"

using namespace std;

string ParseStateInt(int boardStateInt);

// This is an example of an exported function.
extern "C" CPPOPPONENT_API int fnCPPOpponent(void)
{
    return 56;
}

// This is an example of an exported function.
extern "C" CPPOPPONENT_API int GetMoveString(int boardStateInt)
{
    string boardState = ParseStateInt(boardStateInt);

    Solver solver{};
    string bestMove = solver.GetBestMove(boardState);

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

string ParseStateInt(int boardStateInt) {

    string digitString = to_string(boardStateInt);

    const int n = digitString.length();

    string padding = "";

    for (int i = n; i < 9; i++) {
        padding = padding + " ";
    }

    string conversion = "";
    for (int i = 0; i < n; i++) {

        char digit = digitString[i];

        if (digit == '1') {
            conversion = conversion + "X";
        } else if (digit == '2') {
            conversion = conversion + "O";
        } else {
            conversion = conversion + " ";
        }
    }

    return padding + conversion;
}