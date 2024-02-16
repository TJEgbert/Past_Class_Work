#include "tube.h"
#include <iostream>
#include <iomanip>

// static const variable
const double Tube::kPi = 3.14159;


/**
 * @brief: Checks to see circumference is < kMinSize or if length_ + circumference > kMaxSize if so it throws
 * out_of_range if not it sets circumference_ = circumference;
 * @param circumference double: used to set circumference_
 */
void Tube::set_circumference(double circumference)
{
    if (circumference < kMinSize || (length_ + circumference) > kMaxSize)
    {
        throw std::out_of_range("Circumference must be between .007 and sum of circumference + length");
    }
    circumference_ = circumference;
}

/**
 * @brief: default constructor to set circumference_ = 12.  The other measurements and address is used from the
 * abstract class ShippingItem.
 */
Tube::Tube()
{
    circumference_ = 12;
}

/**
 * @brief: none default constructor uses set methods to set private data member.  Throws out_of_range if
 * set_circumference fails.
 * @param address Address: used to set address_
 * @param weight double: used to set weight_
 * @param length double: used to set length_
 * @param circumference double: used to set circumference
 */
Tube::Tube(Address address, double weight, double length, double circumference)
{
    set_address(address);
    set_weight(weight);
    set_length(length);
    try
    {
        set_circumference(circumference);
    }
    catch (std::out_of_range e)
    {
        throw;
    }
}

/**
 * @brief: calculates the volume of the tube
 * @return double: the product of kPi * ((circumference_/(2*kPi)) * (circumference_/(2*kPi))) * length_
 */
double Tube::Volume() const
{
    return kPi * ((circumference_/(2*kPi)) * (circumference_/(2*kPi))) * length_;
}

/**
 * @brief: used to display the data about the tube formatted with one decimal
 * Tube: weight_ lbs. length_ x circumference_
 * @param out
 */
void Tube::Display(std::ostream &out) const
{
    out << std::fixed << std::setprecision(1) <<
    "Tube: " << weight_ << " lbs. " << length_ << " x " << circumference_ << std::endl;
}