// CPP-Opponent.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "framework.h"
#include "CPP-Opponent.h"
#include <string>
#include "Solver.h"

using namespace std;

// This is an example of an exported function.
extern "C" CPPOPPONENT_API int fnCPPOpponent(void)
{
    return 56;
}

// This is an example of an exported function.
extern "C" CPPOPPONENT_API string GetMoveString(string boardState)
{
    Solver solver;
    string bestMove = solver.GetBestMove(boardState);

    return bestMove;
}
