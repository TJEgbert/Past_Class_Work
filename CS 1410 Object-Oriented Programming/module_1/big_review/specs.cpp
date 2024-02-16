/**
 * @file specs.cpp
 * @author Trevor Egbert
 * @brief Print the specs based on user input
 *
 */

#include <iostream>
using namespace std;

int main() {
    char code;

    cout << "Enter a specification code: ";
    cin >> code;

    if (code == 'S')
    {
        cout << "This item is space exploration grade." << endl;
    }
    else if (code == 'M')
    {
        cout << "This is is Military grade." << endl;
    }
    else if (code == 'C')
    {
        cout << "The item is commercial grade." << endl;
    }
    else if (code == 'T')
    {
        cout << "This item is toy grade." << endl;
    }
    else
    {
        cout << "An invalid code was entered." << endl;
    }
    cout << endl;
    return 0;
}