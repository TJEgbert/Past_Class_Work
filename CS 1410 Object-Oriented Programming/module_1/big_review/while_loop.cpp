/**
 * @file specs.cpp
 * @author Trevor Egbert
 * @brief Demo while loops
 *
 */

#include <iostream>
#include <iomanip> // for better IO
using namespace std;
const int kNum = 10;
int main()
{
    int num = 0;
    int div_num = 1;
    cout << "Enter a number to calculate Square and Cube values divisible by it: ";
    cin >> div_num;
    // Loop
    cout << "NUMBER    SQUARE    CUBE" << endl;
    cout << "------    ------    ----" << endl;
    while(num < kNum)
    {
        // iterator divisible by div_num
        // continue: skip the rest of the loop
        if (num % div_num == 0)
        {
            num++; // make sure you update cond. before continue statement.
            continue;
        }
        // do something
        cout << setw(3)<<num << "      "
            << setw(3) << num*num << "      "
            << setw(3)<< num*num*num << endl;

        // update condition
        if (num >5)
        {
            break;
        }
        num++; // increment value
    }
    cout << "Done!" << endl;

    return 0;
}