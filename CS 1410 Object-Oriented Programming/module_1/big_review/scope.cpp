/**
 * @auther Trevor Egbert
 * @date 5-12-2022
 * @brief Discus the constant variables nd scope of variables
 */

#include <iostream>
using namespace std;
// Outside main, variables are local
int global_var = 100;

// function prototype
int print();

int main()
{
    // Inside main, variables are local
    const int kMonths = 12;
    int local_var = 10;
    int global_var = 345;


    cout << local_var << endl;
    cout << " Local " << global_var << endl;
    // Access to global_var from outside the function
    cout << " Global " << ::global_var << endl;

    print(); // call function

    return 0;
}

int print()
{
    cout << global_var << endl;
    return 0;
}