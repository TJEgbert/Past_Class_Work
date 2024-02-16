#include "game3d.h"  // my game library
#include <array>     // for array container
#include <cmath>     // for pow(), sqrt() function
#include <iomanip>   // for formatted output
#include <iostream>

/**
 * @brief used to calculate the distance between two points
 * @param point_a: double
 * @param point_b: double
 * @return distance as a double
 */
double game3d::Distance(double point_a, double point_b)
{
    double distance = 0;
    distance = fabs(point_a - point_b);
    std::cout << std::fixed << std::setprecision(2);

    std::cout << "Distance between " << point_a << " and " << point_b << " = " << distance << std::endl;

    return distance;

}
/**
 * @brief calculates the total distance between points input through an array
 * @param locations: an array of doubles
 * @return total: a double with the total distances between the points
 */
double game3d::TotalWalkingDistance(const std::array<double, kMaxPoints> &locations)
{
    double total = 0;
    for (auto index = 0; index < locations.size() -1; ++index)
    {
        total += game3d::Distance(locations[index], locations[index + 1]);
    }
    return total;
}
/**
 * @brief uses the Distance function and checks its >= kSafeRadius.  If so safe gets returned true if not returns false
 * @param point1: double from the array of points from Distance functions
 * @param point2: double from the array of points from Distance functions
 * @return safe if true
 */
bool game3d::SafeToTravel(double point1, double point2)
{
    bool safe = true;
    double total = game3d::Distance(point1, point2);

    if (total >= game3d::kSafeRadius)
    {
        return safe;
    }
    else
    {
        return false;
    }
}

/**
 * @brief Print message if it is safe to move to another point
 *
 * @param status: true or false
 */
void game3d::SafeToTravelMessage(bool status)
{
    std::cout << "Should I move? " << std::endl;
    if (status)
    {
        std::cout << "\tYes, you are in the safe zone" << std::endl;
    }
    else
    {
        std::cout << "\tNo, stay put. You are in the danger zone" << std::endl;
    }
}

/**
 * @brief Irritates through an array check if the distance between points are in the kSafeRadius if so it adds it to
 * into the total.  Displays message depending on if its safe or not
 * @param locations: an array of doubles
 * @return total: a double of the total points within the kSafeRadius
 */
double game3d::TotalSafeWalkingDistance(const std::array<double, kMaxPoints> &locations)
{
    double total = 0;
    for (auto index = 0; index < locations.size() -1; ++index)
    {
        if (game3d::SafeToTravel(locations[index], locations[index +1]))
        {
            game3d::SafeToTravelMessage(true);
            total += game3d::Distance(locations[index], locations[index +1]);
        }
        else
        {
            game3d::SafeToTravelMessage(false);
        }
    }
    return total;

/**
 * @brief: calculates the distance of 3D points
 * @parem: Two array of doubles containing 3 points
 * @returns distance: a double of the distance
 */
}
double game3d::Distance(std::array<double, kDimensions> a, std::array<double, kDimensions> b)
{
    double distance = 0;

    distance = std::sqrt(std::pow((b[0] - a[0]), 2) + std::pow((b[1] - a[1]), 2) +
            std::pow((b[2] - a[2]),2 ));
    std::cout <<std::fixed << std::setprecision(2);
    std::cout << "\tDistance between (" << a[0] << "," << a[1] << "," << a[2] << ") and (" << b[0] << "," << b[1]
                << "," << b[2] << ") = " << distance << std::endl;

    return distance;
}

/**
 * @brief irritates through two arrays calculating the distance between points though the Distance function and then
 * adds them together
 * @param locations: the set of arrays used in calculations
 * @return total: the total about of distance between the 3D points
 */
double game3d::TotalWalkingDistance(const std::array<std::array<double, kDimensions>, kMaxPoints> &locations)
{
    double total = 0;
    for (auto index = 0; index < locations.size() - 1; ++index)
    {
        total += Distance(locations[index], locations[index + 1]);
    }
    return total;
}