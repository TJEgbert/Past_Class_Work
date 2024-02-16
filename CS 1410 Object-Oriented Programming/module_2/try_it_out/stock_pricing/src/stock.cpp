#include "stock.h"
#include <iostream>
using namespace std;

/**
 * @brief Display portfolio
 *
 * @parem portfolio: array with stock values
 */
void ShowStock(const std::array<double, STOCKS> &portfolio)
{
    cout << "Stock value:" << endl;
    cout << "[ ";

    // For each loop
    for (auto value : portfolio)
    {
        cout << value << " ";
    }
    cout << "]" << endl;
}

/**
 * @brief Increment the value of the stock percentage
 *
 * @parem portfolio: array with stock values
 * @parem percentage : percentage of increase
 */
void IncreaseValueStock(std::array<double, STOCKS> &portfolio, double percentage)
{

    // Traditional for loop
    for (auto index = 0; index < portfolio.size(); ++index)
    {
        // Update each value by percentage
        portfolio[index] = portfolio[index] * (1 + percentage);
    }
}

/**
 * brief set all the values in the array to zero
 *
 * @param portfolio: array with stock values
 */
void SellStock(std::array<double, STOCKS> &portfolio)
{
    for (auto index = 0; index < portfolio.size(); ++index)
    {
        // Sets values to zero
        portfolio[index] = 0;
    }
}
