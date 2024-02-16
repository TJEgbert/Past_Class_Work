/**
 * Try-It_out: Data Analytics 1
 * Trevor Egbert
 * 7/16/2022
 * Loads CSV and analyzes the data
 */
#include <iostream>
#include "containers.h"
using namespace std;

// Main Function
int main()
{
    //Loads the sample_data.csv into a string
    std::string input = "../../data/sample_data.csv";
    //Sets up a vector type data called information
    vector<Data> information;

    // Use Load_Data and gets size of the vector
    Load_Data(information, input);
    cout << "Information size: " << information.size() << endl;

    // Uses Count_Gender to count
    cout << "Number of Males: " << Count_Gender(information, "Male") << endl;
    cout << "Number of Females: " << Count_Gender(information, "Female") << endl;
    cout << "Number of cars: " << Count_Gender(information, "Cars") << endl;

    // Creates a Map and loads with the States from the vector
    map<string, int>states;
    Count_by_State(information, states);

    // Display the map data
    Display_by_State(states);
  return 0;
}