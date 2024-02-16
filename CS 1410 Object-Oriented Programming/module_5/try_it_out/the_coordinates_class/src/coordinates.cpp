#include <iostream>
#include <string>
#include <cmath>
#include <iomanip>
#include "coordinates.h"

using namespace std;

/**
 * @brief Construct a new point::Coordinates::Coordinates object
 *  Sets latitude and longitude to 0
 *
 */
Coordinates::Coordinates()
{
    set_latitude(0);
    set_longitude(0);
}

/**
 * @brief Construct a new point::Coordinates::Coordinates object
 * 
 * @param latitude: Initial Latitude
 * @param longitude: Initial Longitude
 */
Coordinates::Coordinates(float latitude, float longitude)
{
    set_latitude(latitude);
    set_longitude(longitude);
}

/**
 * @brief Setter for latitude
 * 
 * @param value, the value of the new latitude
 */
void Coordinates::set_latitude(float value)
{ 
    latitude_ = value; 
}

/**
 * @brief Set longitude for point
 * 
 * @param value, the value of the new longitude
 */
void Coordinates::set_longitude(float value)
{ 
    longitude_ = value; 
}
    

/**
 * @brief Get the latitude for the point
 * 
 * @return float, the value of latitude
 */
float Coordinates::latitude() const
{ 
    return latitude_; 
}

/**
 * @brief Get the longitude for the point
 * 
 * @return float, the value of longitude
 */
float Coordinates::longitude() const
{ 
    return longitude_; 
}

/**
 * @brief Convert latitude or longitude coordinates to 
 *  degrees, minutes, and seconds
 * 
 * 
 * @param number: latitude or longitude value
 * @param degrees: degrees int reference 
 * @param minutes: minutes int reference 
 * @param seconds: secods int reference 
 */
void Coordinates::from_float_to_gps_(float number, int &degrees, int &minutes, int &seconds)
{
    double frac = 0.0;
    //  * We will use the following formula to convert the units: 
    //  * 1) The whole units of degrees will remain the same (i.e. in 121.135° longitude, start with 121°).
    degrees = number; // take int part for degrees
    
    //  * 2) Multiply the decimal by 60 (i.e. .135 * 60 = 8.1).
    //  * 3) The whole number becomes the minutes (8′).
    frac = number - degrees;
    frac = fabs(frac * 60);
    minutes = frac; // take int part
    
    //  * 4) Take the remaining decimal and multiply by 60. (i.e. .1 * 60 = 6).
    //  * 5) The resulting number becomes the seconds (6″). Seconds can remain as a decimal.
    seconds = fabs(frac - minutes) * 60;
  
    //  * 6) Take your three sets of numbers and put them together, using the symbols for degrees (°), minutes (‘), and seconds (“) (i.e. 121°8’6” longitude)
    // cout<<"degrees: " << degrees << " minutes: " << minutes 
        // << " seconds: " << seconds << endl;
}

/**
 * @brief Compares two Coordinates objects latitude and longitude that are !=
 * @param c2: second Coordinates objects
 * @return: True if they are not. False if they are the same
 */
bool Coordinates::operator!=(Coordinates c2) const
{
    float c1la = latitude_, c1lo = longitude_;
    float c2la = c2.latitude_, c2lo = c2.longitude_;

    if (c1la != c2la || c1lo != c2lo)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief Compares two Coordinates objects latitude and longitude that are =
 * @param c2: second Coordinates objects
 * @return True if they are the same.  False if they are different
 */
bool Coordinates::operator==(Coordinates c2) const
{
    float c1la = latitude_, c1lo = longitude_;
    float c2la = c2.latitude_, c2lo = c2.longitude_;

    if (c1la == c2la && c1lo == c2lo)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief Overloads the << to be able to print Coordinates objects latitude_ and longitude_
 * @param os: a reference the ostream your outputting to
 * @param d: a reference of the Coordinates object
 * @return ostream
 */
std::ostream &operator << (std::ostream &os, const Coordinates &d)
{
    os << std::fixed << std::setprecision(3);
    os << "lat_: " << d.latitude_ << " long_: " << d.longitude_;
    return os;
}

/**
 * @brief takes the absolute value latitude_ and longitude_ and uses the from_float_to_gps and saves it a string
 * @return gps_notation: a string to save formatted data
 * @remark checks to see if latitude_ and longitude_ is positive or negative so format it correctly
 */
std::string Coordinates::gps()
{
    int la_degrees, la_minutes, la_seconds;
    std::string gps_notation = "";
    from_float_to_gps_(abs(latitude_), la_degrees, la_minutes, la_seconds);
    std::string s_la_degrees = to_string(la_degrees);
    std::string s_la_minutes = to_string(la_minutes);
    std::string s_la_seconds = to_string(la_seconds);

    int lo_degrees, lo_minutes, lo_seconds;
    from_float_to_gps_(abs(longitude_), lo_degrees, lo_minutes, lo_seconds);
    std::string s_lo_degrees = to_string(lo_degrees);
    std::string s_lo_minutes = to_string(lo_minutes);
    std::string s_lo_seconds = to_string(lo_seconds);

    if (latitude_ > 0 && longitude_ > 0)
    {
        gps_notation = s_la_degrees + "\370" + s_la_minutes + "\'" + s_la_seconds + "\"" + " N  " +
                s_lo_degrees + "\370" + s_lo_minutes + "\'" + s_lo_seconds + "\"" + " E";
        return gps_notation;
    }

    if (latitude_ > 0 && longitude_ < 0)
    {
        ;
        gps_notation = s_la_degrees + "\370" + s_la_minutes + "\'" + s_la_seconds + "\"" + " N  " +
                      s_lo_degrees + "\370" + s_lo_minutes + "\'" + s_lo_seconds + "\"" + " W";
        return gps_notation;
    }

    if (latitude_ < 0 && longitude_ > 0)
    {
        gps_notation = s_la_degrees + "\370" + s_la_minutes + "\'" + s_la_seconds + "\"" + " S  " +
                       s_lo_degrees + "\370" + s_lo_minutes + "\'" + s_lo_seconds + "\"" + " E";
        return gps_notation;
    }

    if (latitude_ < 0 && longitude_ < 0)
    {
        gps_notation = s_la_degrees + "\370" + s_la_minutes + "\'" + s_la_seconds + "\"" + " S  " +
                       s_lo_degrees + "\370" + s_lo_minutes + "\'" + s_lo_seconds + "\"" + " W";
        return gps_notation;
    }
    return gps_notation;
}