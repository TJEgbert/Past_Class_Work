#include <iostream>
using namespace std;

int main()
{
    float numb1 = 15.2;
    float numb2 = 2.8;


    cout << "\nDate Type Bytes"
         << "\n--------- ------"
         << "\nint        " << sizeof(int)
         << "\nchar       " << sizeof(char)
         << "\ndouble     " << sizeof(double)
         << "\nbool       " << sizeof(bool)
         << endl;

    cout << numb1 << " plus " << numb2 << " equals " << (numb1 + numb2) << endl;
    cout << numb1 << " minus " << numb2 << " equals " << (numb1 - numb2) << endl;
    cout << numb1 << " times " << numb2 << " equals " << (numb1 * numb2) << endl;
    cout << numb1 << " divided " << numb2 << " equals " << (numb1 / numb2) << endl;
    return 0;
}