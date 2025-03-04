#include <iostream>
#include "carton.h"
#include "cmath"


using namespace std;

// constructors and destructor
/**
 * @brief Construct a new Carton:: Carton object
 * Sets length to 1, width to 1, and height to 1
 *
 */
Carton::Carton() : length_(1.0), width_(1.0), height_(1) {}

/**
 * @brief Construct a new Carton:: Carton object. Sets the measurements to
 * the values sent.
 * @remark If any measurement is zero or less, the dimension will be set to 1.
 * @param length - one dimension of the carton
 * @param width - one dimension of the carton
 * @param height - one dimension of the carton
 */
Carton::Carton(float length, float width, float height) {
  SetLength(length);
  SetWidth(width);
  SetHeight(height);
}

// setters
/**
 * @brief - sets the value of length
 * @remark If value sent is zero or negative, the length is set to 1.
 *
 * @param width - the value of the new length
 */
void Carton::SetLength(float length) {
  if (length <= 0) {
    length_ = 1;
  } else {
    length_ = length;
  }
}

/**
 * @brief - sets the value of width
 * @remark If value sent is zero or negative, the width is set to 1.
 *
 * @param width - the value of the new width
 */
void Carton::SetWidth(float width) {
  if (width <= 0) {
    width_ = 1;
  } else {
    width_ = width;
  }
}

/**
 * @brief - sets the value of height
 * @remark If value sent is zero or negative, the height is set to 1.
 *
 * @param height - the value of the new height
 */
void Carton::SetHeight(float height) {
  if (height <= 0) {
    height_ = 1;
  } else {
    height_ = height;
  }
}

// other methods
/**
 * @brief - returns the volume of the carton
 *
 * @return float - the volume of the Carton
 */
float Carton::Volume() const {
  return length_ * width_ * height_;
}


/**
 * @brief - writes the carton data, length, width and height, to the output
 * stream
 *
 * @param out - an output stream where the Carton data
 * will be output
 */
void Carton::WriteData(std::ostream &out) const {
  out << length_ << " " << width_ << " " << height_ << endl;
}

/**
 * @brief - writes carton information in a sentence to the output stream
 *
 * @param out - an output stream where the Carton information
 * will be output
 */
void Carton::WriteCarton(std::ostream &out) const {
  out << "A carton with length " << length_ << ", width " << width_
      << ", and height " << height_ << ".";
}

/**
 * @brief: overload operator == that checks if the Volume of the two Carton objects are with 0.1 of each other
 * @param rhs: the second Carton object or the on the "Right Hand Side"
 * @return true if there are within the tolerance if not returns false
 */
bool Carton::operator==(const Carton& rhs) const
{
    if(fabs(Volume() - rhs.Volume()) < 0.1)
    {
        return true;
    }
    else
    {
        return false;
    }
}