/*
 * Try-It-Out: Stock Pricing
 * Trevor Egbert
 * 5-19-2022
 * Practicing using arrays
 */

#include <array>  // for array container
#include <iostream>
#include "stock.h"  // link to stock library
using namespace std;

// Main Function
int main()
{
    // Initial stock values
    array<double, STOCKS> portfolio{150.30, 218.34, 34.10, 110.99, 87.34};

    // Part 1: Display portfolio

    ShowStock(portfolio);

    // Part 2: Update values by percentage
    IncreaseValueStock(portfolio, 0.10);
    ShowStock(portfolio);

    // Part 3: Set all values to zero
    SellStock(portfolio);
    ShowStock(portfolio);

    return 0;
}