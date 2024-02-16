#include "cars.h"
#include <iomanip>  // for formatted output
#include <iostream>

/**
 * @brief Displays Car's Value
 *
 * @param value: Car's Value
 */
void ShowPrice(double value)
{
    std::cout << std::fixed << std::setprecision(2);
    std::cout << "Car Value: " << value << std::endl;
}

/**
 * @brief Update current car's value to new value
 *
 * @parem current_value: old value
 * @parem new_value: new value
 */
void UpdatePrice(double &current_value, double new_value)
{
    // Update Current Value
    // Remember current_value is pass by reference
    current_value = new_value;
}

/**
 * @brief Display car's horse power
 *
 * @return int
 */
int HorsePower()
{
    return kHorsepower; // this is the constant value defined in cars.h
}

// lamborghini namespace functions

/**
 * @brief Displays Car's Value for the lamborghini namespace
 *
 * @param value: Car's Value
 */
void lamborghini::ShowPrice(double value)
{
    std::cout << std::fixed << std::setprecision(2);
    std::cout << "Car Value: " << value << std::endl;
}

/**
 * @brief Update current car's value to new value
 *
 * @parem current_value: old value
 * @parem new_value: new value
 */
void lamborghini::UpdatePrice(double &current_value, double new_value)
{
    current_value = new_value;
}

/**
 * @brief Display car's horse power
 *
 * @return int
 */
int lamborghini::HorsePower()
{
    return lamborghini::kHorsepower;
}