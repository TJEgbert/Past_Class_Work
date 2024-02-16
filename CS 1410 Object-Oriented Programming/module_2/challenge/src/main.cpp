/**
 * Challenge: 3D Game Library
 * Trevor Egbert
 * 5/22/2022
 * Calculate distance between 1D points and 3D points
 */

#include <iostream>
#include "game3d.h"

int main()
{
    //////////////// Part 1 //////////////////////////

    std::cout << "\n******** Part 1********" << std::endl;
    // Sets up double variables to use for the distance functions
    double p1 = 5.9, p2 = 4.5;

    // Runs the game3d::Distance functions with variables p1 and p2
    game3d::Distance(p1,p2);
    game3d::Distance(p1);

    std::cout << "Now calculate for " << game3d::kMaxPoints << " points" << std::endl;

    // Sets up points in an array of doubles to use for the functions TotalWalkingDistance
    std::array<double, game3d::kMaxPoints> location_1d = {11, 22, 37, 41, 53, 66, 79, 80, 95, 101};

    // Uses TotalWalkingDistance to calculates the distance between and adds them together and displays on the screen
    // using total_distance to print the results
    double total_distance = game3d::TotalWalkingDistance(location_1d);
    std::cout << "Total traveled distance between " << " = " << total_distance << std::endl;

    //////////////// Part 2 //////////////////////////

    std::cout << "\n**************Part 2************\n";

    // Test if safe to travel between points
    p1 = 8.5, p2 = 26.9;
    game3d::SafeToTravelMessage(game3d::SafeToTravel(p1, p2));

    p1 = 8.5, p2 = 10.9;
    game3d::SafeToTravelMessage(game3d::SafeToTravel(p1, p2));

    p1 = 10.5;
    game3d::SafeToTravelMessage(game3d::SafeToTravel(p1));

    // Checks an array of points to see if it's to move and add the totals to give of the safe points
    std::cout <<"\n Calculating safe traveled distance for " << game3d::kMaxPoints << " points " << std::endl;
    total_distance = game3d::TotalSafeWalkingDistance(location_1d);
    std::cout << "\nTotal safe traveled distance =" << total_distance << std::endl;

    //////////////// Part 3 //////////////////////////

    std::cout << "*************Part 3*************\n";
    // Sets up test variables for 3D distance calculations
    std::array<double, 3> enemy1_location = {2, 6, 1};
    std::array<double, 3> enemy2_location = {3, 4, 0};

    // Calculates distance of the points and prints them to the console
    double enemy_distance = game3d::Distance(enemy1_location, enemy2_location);
    std::cout << "Distance between 2 3D points " << enemy_distance << std::endl;
    enemy_distance = game3d::Distance(enemy1_location);
    std::cout << "Distance between 1 3ds point and origin " << enemy_distance << std::endl;

    // Calculates the distance of points from an array and prints them from to the console
    std::cout << "\nCalculating 3D distance for " << game3d::kMaxPoints << " 3D points " << std::endl;
    std::array<std::array<double, game3d::kDimensions>, game3d::kMaxPoints>
    location_3d{
        enemy1_location,
        {3, 6, 7},         // point 2, index [1]
        {2, 3, 3},         // point 3, index [2]
        {5, 3, 5},         // point 4, index [3]]
        {8, 3, 0},         // point 5, index [4]
        {8, 8, 2},         // point 6, index [5]
        {2, 1, 2},         // point 7, index [6]
        {6, 3, 1},         // point 8, index [7]
        {5, 2, 0},         // point 9, index [8]
        enemy2_location};  // point 10, index [9]
    total_distance = game3d::TotalWalkingDistance(location_3d);
    std::cout << "Total traveled distance between " << game3d::kMaxPoints << " 3D points "
              << " = " << total_distance << std::endl;


    return 0;
}