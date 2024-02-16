#include "flat.h"
#include <iostream>
#include <iomanip>

/**
 * @brief: checks to see if length < kMinSize or length > 15 if so it throws out_of_age else length_ = length
 * @param length double: used to set length_
 */
void Flat::set_length(double length)
{
    if (length < kMinSize || length > 15)
    {
        throw std::out_of_range("Length must be between .007 and 15");
    }
    length_ = length;
}

/**
 * @breif: checks to see if height < kMinSize or height > 12 if so it throws out_of_rage else height_ = height
 * @param height double: used to set height_
 */
void Flat::set_height(double height)
{
    if (height < kMinSize || height > 12)
    {
        throw std::out_of_range("Height must be between .007 and 12");
    }
    height_ = height;
}

/**
 * @breif: checks to see if thickness < kMinSize or thickness > 0.75 if so it throws out_of_range else
 * thickness_ = thickness
 * @param thickness double: used to set thickness_
 */
void Flat::set_thickness(double thickness)
{
    if (thickness < kMinSize || thickness > 0.75)
    {
        throw std::out_of_range("Thickness must be between .007 and .75");
    }
    thickness_ = thickness;
}

/**
 * @brief: default constructor that sets the height_ = 8, thickness_ = .4 the other measurements and address are set
 * by the abstract class shipping_item default constructor
 */
Flat::Flat()
{
    height_ = 8;
    thickness_ = .4;
}

/**
 * @brief: none default constructor uses the setter methods to set the private data members.
 * @param address Address: used to set address_
 * @param weight double: used to set weight_
 * @param length double: used to set length_
 * @param height double: used to set height_
 * @param thickness double: used to set thickness_
 */
Flat::Flat(Address address, double weight, double length, double height, double thickness)
{
    set_address(address);
    set_weight(weight);
    set_length(length);
    set_height(height);
    set_thickness(thickness);
}

/**
 * @brief used to calculate and return the volume of the package
 * @return double of the volume calculated by length_ * height_ * thickness_
 */
double Flat::Volume() const
{
    return length_ * height_ * thickness_;
}

/**
 * @brief: used to output the information about the flat object format with one decimal
 * Flat: weight_ lbs. length_ x height_ x thickness_
 * @param out ostream: the location where the user wants to output to
 */
void Flat::Display(std::ostream &out) const
{
    out << std::fixed << std::setprecision(1) <<
    "Flat: " << weight_ << " lbs. " << length_ << " x " << height_ << " x " << thickness_ << std::endl;
}