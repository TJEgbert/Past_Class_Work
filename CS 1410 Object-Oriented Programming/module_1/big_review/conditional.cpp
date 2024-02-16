/**
 * @auther Trevor Egbert
 * @date 5-12-2022
 * @brief practice conditionals in C++
 */

#include <iostream>
using namespace std;

int main()
{
    int age = 13;
    // Take user input use: cin
    cout << "Enter your age: ";
    cin >> age;

    if(age > 12)
    {
        cout << age << " is > 12" << endl;
    }
    else if(age == 12)
    {
        cout << age << " is = 12" << endl;
    }
    else
    {
        cout << age << " is <= 12" << endl;
    }

    cout << "Done!" << endl;
    return 0;
}