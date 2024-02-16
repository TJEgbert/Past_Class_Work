#ifndef GAME_3D_H
#define GAME_3D_H

#include <array>

// set up for our name space game3d
namespace game3d {
// namespace constants
const int kMaxPoints = 10;
const double kSafeRadius = 12.0;
const int kDimensions = 3;

// Task 1
// Default parameters used if user lacks a second input
double Distance(double point_a, double point_b = 0);
double TotalWalkingDistance(const std::array<double, kMaxPoints> &locations);

// Task 2:
// Default parameters used if user lacks a second input
bool SafeToTravel(double point1, double point2 = 0);
void SafeToTravelMessage(bool status);
double TotalSafeWalkingDistance(const std::array<double, kMaxPoints> &locations);

// Task 3: Overload functions
// Default parameters used if user lacks a second input
double Distance(std::array<double, kDimensions> a, std::array<double, kDimensions> b = {0, 0, 0});
double TotalWalkingDistance(const std::array<std::array<double, kDimensions>, kMaxPoints> & locations);

}  // namespace game3d
#endif
