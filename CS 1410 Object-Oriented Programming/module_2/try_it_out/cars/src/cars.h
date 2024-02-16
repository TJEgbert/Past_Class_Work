#ifndef CARS_H_
#define CARS_H_

// Variables
const int kHorsepower = 120;

// Functions
void ShowPrice(double value);
void UpdatePrice(double &current_value, double new_value);
int HorsePower();


// lamborghini namespace functions
namespace lamborghini
{
    // variables
    const int kHorsepower = 759;

    // Functions
    void ShowPrice(double value);
    void UpdatePrice(double &current_value, double new_value);
    int HorsePower();
}
#endif /* !CARS_H_ */
