/**
 * @file specs.cpp
 * @author Trevor Egbert
 * @brief Demo for a switch statement
 *
 */

#include <iostream>
using namespace std;

int main()
{
    int opselect = 0;
    double first_num = 0.0, second_num = 0.0;

    cout << "Please type in two numbers: ";
    cin >> first_num >> second_num; // take two inputs from user

    cout << "Enter a select code: ";
    cout << "\n        1 for addition";
    cout << "\n        2 for multiplication: ";
    cout << "\n        3 for division:  ";

    cin >> opselect;

    // work with int, and chars
    switch(opselect)
    {
        case 1:    //of (opselect == 1)
            cout << " the sum of " << first_num << " and " << second_num << " = " << (first_num + second_num)
                << endl;
                break;
        case 2:    //of (opselect == 1)
            cout << " the product of " << first_num << " and " << second_num << " = " << (first_num * second_num)
                << endl;
            break;
        case 3:    //of (opselect == 1)
            cout << " the division of " << first_num << " and " << second_num << " = " << (first_num / second_num)
                << endl;
            break;
        default:  // else case
            cout << "Invalid choice" << endl;
            break;
    }


    return 0;
}