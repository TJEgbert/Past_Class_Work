/**
 * Try It Out: The Distance Class
 * Trevor Egbert
 * 6/25/2022
 * Creates the distance class uses it
 */

#include <iostream>
#include "distance.h"
using namespace std;

// Main Function
int main() 
{
    Distance dist1(12, 6.6);
    Distance dist2(3, 0);
    dist2.update_distance(0, 36);
    Distance dist3;

    dist3 = dist1 - dist2;

    cout << dist1 << endl;
    cout << dist2 << endl;
    cout << dist3 << endl;

  return 0;
}