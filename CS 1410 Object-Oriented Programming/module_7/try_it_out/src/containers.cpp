#include "containers.h"
#include "csvstream.h"
#include <iostream>
#include <algorithm>
#include <iterator>

/**
 * @brief: Loads the csvstream string into a struct and then adds it to vector
 * @param data: The vector to load the int and strings into
 * @param in_file: The string from loaded csvstream
 */
void Load_Data(std::vector<Data> &data, const std::string &in_file)
{
    Data temp;
    csvstream csvin(in_file);

    std::map<std::string, std::string> row;

    while(csvin >> row)
    {
        temp.id = std::stoi(row["id"]);
        temp.gender = row["gender"];
        temp.school = row["school"];
        temp.state = row["state"];

        data.push_back(temp);
    }
}

/**
 * @brief: Checks through the vector for gender and returns that count
 * @param data: The vector that it searches through
 * @param gender: The string that will search through the gender row
 * @return int: The amount the string appears in the vector
 */
int Count_Gender(std::vector<Data> &data, const std::string gender)
{
    int count = 0;
    for(const auto &value: data)
    {
        if(value.gender == gender)
        {
            count ++;
        }
    }
    return count;
}

/**
 * @brief: Checks through the vector and loads the states from corresponding row as the key into the map
 *          and updates value for each duplicates.
 * @param data: The vector to search through
 * @param st_count: The map they is being loaded
 */
void Count_by_State(std::vector<Data> &data, std::map<std::string, int> &st_count)
{
    for(const auto &value: data)
    {
        if(st_count.find(value.state) == st_count.end())
        {
            st_count.insert(std::make_pair(value.state, 1));
        }
        else
        {
            st_count[value.state]++;
        }
    }

}


/**
 * @brief Display the content of a map
 * 
 * @param st_count: Reference to map with key-> states, value-> count 
 */
void Display_by_State(std::map<std::string, int> &st_count)
{
    int total = 0;

    // Iterate over the map using c++11 range based for loop
	for (std::pair<std::string, int> element : st_count) 
    {
		// std::cout << element.first << " :: " << element.second << std::endl;
		// Or more explicitly

        // Accessing KEY from element
		std::string word = element.first;
		// Accessing VALUE from element.
		int count = element.second;
		std::cout << word << " :: " << count << std::endl;
        
        total += count;
	}
    std::cout << "A total of "<< total << " records for all states" << std::endl;
}