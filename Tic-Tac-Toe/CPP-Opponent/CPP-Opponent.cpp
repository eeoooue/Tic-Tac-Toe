// CPP-Opponent.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "CPP-Opponent.h"


// This is an example of an exported variable
CPPOPPONENT_API int nCPPOpponent=0;

// This is an example of an exported function.
CPPOPPONENT_API int fnCPPOpponent(void)
{
    return 0;
}

// This is the constructor of a class that has been exported.
CCPPOpponent::CCPPOpponent()
{
    return;
}
