/**
 * Challenge: Data Analytics 2
 * Trevor Egbert
 * 7/18/2022
 * Loads CSV and analyzes the data
 */

#include <iostream>
#include <vector>
#include "containers.h"
using namespace std;

// Main Function
int main()
{
  // TODO: Part I
  // Loads CSV file into a string name input and creates a vector of type Car
  string input = "../../data/MOCK_DATA_CARS.csv";
  vector<Car>cars;

  // Uses Load_Data to load the cars vector with the input file. Prints out car.size()
  Load_Data(cars, input);
  cout << "Cars size: " << cars.size() << endl;


  // TODO: Part II
  // Uses Car_Value_Analytics to get the MIN and MAX of cars.value.  Then prints them out.
  Car max_car = Car_Value_Analytics(cars, MAX);
  cout << "Car max value: " << max_car.value << endl;
  Car min_car = Car_Value_Analytics(cars, MIN);
  cout << "Car min Value: " << min_car.value << endl;

  // TODO: Part III
  // Sets up int and vector used in the Cars_from_decade
  int decade = 1978;
  std::vector<Car> new_cars = Cars_from_decade(cars, decade);
  // Uses Cars_from_decade and prints out car.year car.value and prints out the new_car vector
  for (const Car &car: new_cars)
  {
      cout << "New cars for " << decade << " " << car.year << " " << car.value << endl;
  }
  cout << new_cars.size() << endl;

  return 0;
}