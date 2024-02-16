/**
 * Tying-it-out: Cars
 * @author Trevor Egbert
 * @date 5/21/2022
 * @brief Using functions and namespaces
 */
#include <iostream>
#include "cars.h"


int main() 
{
    // Part 1: Regular Car
    std::cout << "Part 1:" << std::endl;
    double sedan_value = 18500;
    ShowPrice(sedan_value);

    // Updating price and displaying the new value
    std::cout << "Updating price" << std::endl;
    UpdatePrice(sedan_value, 20340.9);
    ShowPrice(sedan_value);

    // Displaying horsepower
    std::cout << "The horse power of a sedan is: " << HorsePower() << std::endl;

    // Part 2: Lamborghini Car
    std::cout << "Part2:" << std::endl;
    double lambo_value = 18500;
    lamborghini::ShowPrice(lambo_value);

    // Updating price and displaying the new value
    std::cout << "Updating price" << std::endl;
    lamborghini::UpdatePrice(lambo_value, 20340.99);
    lamborghini::ShowPrice(lambo_value);

    // Displaying horsepower
    std::cout << "The horse power of a lambo is: " << lamborghini::HorsePower() << std::endl;

    return 0;
}
