#include "factor.h"  // "" local library
#include <iostream>
using namespace std;

void FactorMod()
{
    int remainder;
    int dividend = 30;
    int divisor = 5;

    remainder = dividend % divisor;
    if (remainder == 0)
    {
        cout << dividend << " is divisible by " << divisor << endl;
    }
    else
    {
        cout << dividend << " is not divisible by " << divisor << endl;
    }
}
