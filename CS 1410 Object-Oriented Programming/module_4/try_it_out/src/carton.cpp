#include "carton.h"
#include <iostream>


/**
 * @brief sets the length of the carton
 * @remark if the value is less then zero it sets the length to 1
 * @param length: A float for the length
 */
void Carton::SetLength(float length)
{
    if (length > 0)
    {
        length_ = length;
    }
    else
    {
        length_ = 1;
    }
}

/**
 * @brief sets the width of the carton
 * @remark if the is less than zero it sets the width to 1
 * @param width: a float for the width
 */
void Carton::SetWidth(float width)
{
    if (width > 0)
    {
        width_ = width;
    }
    else
    {
        width_ = 1;
    }
}

/**
 * @brief sets the height of the carton
 * @remark if the is less than zero it sets the height to 1
 * @param height: a float for the height
 */
void Carton::SetHeight(float height)
{
    if (height > 0)
    {
        height_ = height;
    }
    else
    {
        height_ = 1;
    }
}

/**
 * @brief A Non-default constructor for Carton class.  Uses the Setters to set length, width, height
 * @param length: a float that the user/program can use to set the length
 * @param width: a float that the user/program can use to set the width
 * @param height: a float that the user/program can use to set the width
 */
Carton::Carton(float length, float width, float height)
{
    SetLength(length);
    SetWidth(width);
    SetHeight(height);

}

/**
 * @breif takes the length_, width_, height_ to format the data with spaces in between each
 * @param out: ostream that the data can write to
 */
void Carton::WriteData(std::ostream &out) const
{
    out << length_ << " " << width_ << " " << height_ << std::endl;
}

/**
 * @brief takes the length_, width_, height_ to format the data in a sentence
 * @remark: sentence ex: A carton with length 5, width 10, and height 20.
 * @remark: If used in a series an endl will need to be used to move the a new line
 * @param out : ostream that the date can write to
 */
void Carton::WriteCarton(std::ostream &out) const
{
    out << "A carton with length " << length_ << ", width " << width_ << ", and height " << height_ << ".";
}

/**
 *
 * @brief takes the length_, width_ and height and calculate the volume of the carton
 * @return volume: a float that the calculation it saved to.
 */
float Carton::Volume() const
{
    float volume = length_ * width_ * height_;
    return volume;
}