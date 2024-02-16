#ifndef CONTAINERS_H_
#define CONTAINERS_H_

#include <string>
#include <vector>
#include <map>
#include <string>

/**
 * @brief: A struct to store data
 * @param id: int
 * @param gender: std::string
 * @parem school: std::string
 * @param state: std::string
 */
struct Data
{
    int id;
    std::string gender;
    std::string school;
    std::string state;
};

void Load_Data(std::vector<Data> & data, const std::string &in_file);
int Count_Gender(std::vector<Data> &data, const std::string gender);
void Count_by_State(std::vector<Data> &data, std::map<std::string, int> &st_count);


void Display_by_State(std::map<std::string, int> &st_count);

#endif /* !CONTAINERS_H_ */
