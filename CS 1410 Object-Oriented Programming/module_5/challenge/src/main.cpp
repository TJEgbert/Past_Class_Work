/**
 * Challenge: Great Britain Monetary System
 * Trevor Egbert
 * 6/27/22
 * Creates and use the Sterling Class
 */

#include <iostream>
using namespace std;
#include "sterling.h"

int main()
{
    //testing constructors
    Sterling df;
    Sterling ot(10, 10, 10);
    cout << "default constructor pounds: " << df.get_pounds() << " shills: " << df.get_shills()
        << " pence: " << df.get_pence() << endl;

    cout << "secondary constructor pounds: " << ot.get_pounds() << " shills: " << ot.get_shills()
         << " pence: " << ot.get_pence() << endl;

    Sterling test("45.59.25");

    cout << "string constructor pounds: " << test.get_pounds() << " shills: " << test.get_shills()
         << " pence: " << test.get_pence() << endl;

    Sterling pound(33.15);

    cout << "decimal constructor pounds: " << pound.get_pounds() << " shills: " << pound.get_shills()
         << " pence: " << pound.get_pence() << endl;

    // test overloaded operators <<, != and ==
    cout << test.get_old_system() << endl;
    cout << ot << endl;
    cout << test << endl;
    cout << pound << endl;

    if (df == pound)

    if (df != pound)
    {
        cout << "first: " << df << endl;
        cout << "second: " << pound << endl;
        cout << "there not equal" << endl;
    }
    else
    {
        cout << "first " << df << endl;
        cout << "second " << pound << endl;
        cout << "there equal" << endl;
    }

    if (df != test)
    {
        cout << "first " << df << endl;
        cout << "second " << test << endl;
        cout << "there not equal" << endl;
    }
    else
    {
        cout << "first " << df << endl;
        cout << "second " << test << endl;
        cout << "there equal" << endl;
    }

    // testing setters
    df.set_pounds(12);
    df.set_shills(5);
    df.set_pence(5);

    // testing decimal_pound
    cout << df << " total have decimal_pound = " << df.decimal_pound() << endl;
    Sterling p1(27.26);
    Sterling p2(12.78);

    // test overloaded operators + and -
    cout << p1 << endl;
    cout << p2 << endl;
    Sterling p3 = p1 + p2;
    cout << "the sum of p1 + p2 = " << p3.decimal_pound() << endl;

    cout << endl;
    cout << p1 << endl;
    cout << p2 << endl;
    Sterling s4 = p1 - p2;
    cout << "the difference ob p1 - p2 = " << s4 << endl;



    return 0;
}
