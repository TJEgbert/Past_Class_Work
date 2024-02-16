/**
 * @auther Trevor Egbert
 * @date 5-12-2022
 * @brief Calculate the Volume of a sphere
 */


#include <iostream>
using namespace std;


const double kPI = 3.14159265359; // constant variable

int main()
{
    double radius = 2.5; // meters
    double volume = 0;

    // Volume = 4/3 * PI * radius**2
    volume = (4.0/3.0) * kPI * radius * radius;
    // print result
    cout << "the volume of the sphere is " << volume << endl;

    return 0;
}
