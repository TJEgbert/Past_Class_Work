/**
 * Try it out: Coordinates Class
 * Trevor Egbert
 * 6/26/2022
 * Creates and use the coordinates class
 */

#include <iostream>
#include "coordinates.h"
using namespace std;

// Main Function
int main() 
{

    // Testing
    Coordinates ogden( 41.2230, -111.9738);
    Coordinates ogden2(41.2230, -111.9738);
    Coordinates logan( 41.7370, -111.8338);
    Coordinates p1(-33.924870, 18.424055);

    if (ogden != logan)
    {
        cout << "they are not the same" << endl;
    }
    else
    {
        cout << "they are the same" << endl;
    }

    if (ogden == ogden2)
    {
        cout << "they are the same" << endl;
    }
    else
    {
        cout << "they are different" << endl;
    }

    cout << ogden << endl;
    cout << p1.gps() << endl;


    return 0;
}