/**
 *Try it out Activity: Collection
 * Trevor Egbert
 * 9/4/2022
 * Creates the Collection class and uses it
 */
#include <iostream>
#include "Collection.h"

using std::cout;
using std::endl;

int main()
{

    Collection test;
    Collection test2(15);
//    test2.getEnd();
//    test.getFront();

    cout << "Max size of test2 is " << test2.getCapacity() << endl;
    cout << "current size of test is " << test.getSize() << endl;
    for(int i = 0; i < 15; i++)
    {
        test2.add(i);
    }

    cout << test2 << endl;


    for(int i = 0; i < 8; i++)
    {
        test.add(i);
    }

    cout << test << endl;
//    cout << "number " << test.get(8) << " is at index number 8";

    cout << endl;
    cout << "The position of the needle is: " << test2.find(20) << endl;

    cout << endl;

    test.addFront(100);

    cout << test << endl;

    return 0;
}
