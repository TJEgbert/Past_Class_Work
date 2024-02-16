#include "containers.h"
#include "csvstream.h"
#include <iostream>
#include <algorithm>
#include <iterator>

/**
 * @brief Loads from csvstream file use Car struct to organize the data and store in a vector
 * @param cars: A vector of type Cars
 * @param in_file: the string that was load from a file of type .csv
 */
void Load_Data(std::vector<Car> &cars, const std::string &in_file)
{
    Car temp;
    csvstream in(in_file);
    std::map<std::string, std::string> row;

    while(in >> row)
    {
        temp.vin = row["vin"];
        temp.make = row["car_make"];
        temp.year = std::stoi(row["car_year"]);
        temp.color= row["car_color"];
        temp.value= std::stod(row["value"]);
        temp.state = row["state"];

        cars.push_back(temp);
    }
}

/**
 * @brief Checks vector of Type car .values and gets the min or the max
 * @param cars: A vector of type cars
 * @param operation: an int of MIN or MAX used to decide what value to look for
 * @return the type Car with the MIN or MAX value
 */
Car Car_Value_Analytics(std::vector<Car> &cars, int operation)
{
    if(operation == MAX)
    {
       auto results = std::max_element(cars.begin(), cars.end(), [](Car a, Car b)
       {return a.value < b.value;});
       return *results;
    }
    if(operation == MIN)
    {
       auto results =  std::min_element(cars.begin(), cars.end(), [] (Car a, Car b)
       {return a.value < b.value;});
       return *results;
    }

}

/**
 * @brief Does the calculation to figure out what decade to look for and makes a new vector to store them in and
 * organizes them least to greatest value
 * @param cars: A vector of type Car
 * @param decade: An int used to calculate the range for the copy_if
 * @return a Vector of type car
 */
std::vector<Car> Cars_from_decade(std::vector<Car> &cars, int decade)
{
    std::vector<Car> car_list;
    int minus = decade % 10;
    int st_year = decade - minus;

    std::copy_if(cars.begin(),cars.end(), std::back_inserter(car_list), [st_year](Car a)
    {return a.year >= st_year and a.year <= st_year + 9;});

    std::sort(car_list.begin(),car_list.end(),[](Car a, Car b) {return a.value < b.value;});
    return car_list;
}