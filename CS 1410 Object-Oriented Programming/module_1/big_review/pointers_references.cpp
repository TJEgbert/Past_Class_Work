/**
 * @file pointers_references.cpp
 * @author Trevor Egbert
 * @brief Play with pointers and reference
 * @version 0.1
 * @date 5-12-2022
 *
 * @copyright Copyright (c) 2022
 *
 */
#include <iostream>
using namespace std;

int main()
{
    int first_variable = 10;
    int &ref_name = first_variable;   // this is a reference "alias" to variable

    int * p_first_variable = &first_variable; // pointer takes the address of a variable

    cout << " Value of first_variable is " << first_variable << endl;
    cout << " Value of ref_name is " << ref_name << endl;
    cout << " Value of p_first_variable is " << p_first_variable << endl;
    cout << " Value of address first_variable is " << &first_variable << endl;
    cout << " Value living at p_first_variable is " << *p_first_variable << endl;
    return 0;
}