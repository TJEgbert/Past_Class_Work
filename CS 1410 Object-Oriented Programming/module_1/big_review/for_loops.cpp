/**
 * @file specs.cpp
 * @author Trevor Egbert
 * @brief practice for loops
 *
 */

#include <iostream>
using namespace std;

int main()
{
    const int kMaxI = 5;
    const int kMaxJ = 3;

    for(auto i = 1; i <= kMaxI; ++i)
    {
        cout << "i is " << i << endl;
        for (auto j = 1; j < kMaxJ; ++j)
        {
            cout << "\ni*j is now " << i * j << endl;
        }
    }
    cout << "Done!" << endl;
    return 0;
}