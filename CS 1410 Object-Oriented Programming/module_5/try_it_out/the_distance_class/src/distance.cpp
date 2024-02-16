#include <iostream>
#include <cmath>
using namespace std;
#include "distance.h"

/**
 * @brief Lets the user input information for feet_ and inches_
 */
void Distance::set_distance() // get it from user
{
    cout << "Enter feet: ";
    cin >> feet_;
    cout << "\nEnter inches: " << endl;
    cin >> inches_;
}

/**
 * @brief Displays feet_ and inches_
 */
void Distance::show_distance() const
{
    cout << feet_ << "\'-" << inches_ << "\"" << endl;
}

/**
 * @brief Overload operator for +
 * @param d2: The second Distance object
 * @return Distance object with feet_ and inches_
 */
Distance Distance::operator + (Distance d2) const // add 2 distances
{
    int ft = feet_ + d2.feet_;
    double in = inches_ + d2.inches_;
    if (in >= 12.0)
    {
        in = in - 12.0;
        ft++;
    }
    return Distance(ft, in);
}

/**
 * @brief Overload operator for -
 * @param d2: The second Distance object
 * @return Distance object with feet_ and inches_
 */
Distance Distance::operator - (Distance d2) const
{
    int ft = feet_ - d2.feet_;
    double in = inches_ - d2.inches_;

    if (in < 0)
    {
        ft -= 1;
        in += 12;
    }
    return Distance(ft, in);
}

/**
 * @breif Updates the feet_ and inches_
 * @param ft the new input for feet_
 * @param in the new input for inches_
 * @remark checks to see if ft and in are above zero. If in is above 12 it calculates the amount of feet and remaining
 * inches left
 */
void Distance::update_distance(int ft, double in)
{
    if (ft < 0)
    {
        feet_ = 0;
    }
    else
    {
        feet_ = ft;
    }
    if (in < 0)
    {
        inches_ = 0;
    }
    else
    {
        inches_ = in;
    }
    if (in > 12)
    {
        int inches = static_cast<double>(in);
        int div_in = inches / 12;
        inches_ = inches - (div_in * 12);
        feet_ += div_in;
    }

/**
 * @breif overload << and prints out feet_ and inches_
 */
}
std::ostream &operator << (std::ostream &os, const Distance &d)
{
    os << "feet_: " << d.feet_ << "\'"<< " inches_: " << d.inches_ << "\"";
    return os;
}

