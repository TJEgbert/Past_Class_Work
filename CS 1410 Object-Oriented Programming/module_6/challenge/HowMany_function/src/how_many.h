#ifndef HOW_MANY_H
#define HOW_MANY_H
#include "array"


int const kMaxSize = 20;

/**
 * @brief: A template function for an array the counts how many of variable the uses chooses
 * @tparam T: Variable type that the user choose.  NOTE: must support the == operator
 * @param variable: the variable the user want to check in the array to count
 * @param item_list: the array the use want to check through
 * @param size: the size of the array that is being used
 * @return int: the number of variables that the user want to check for
 */
template <typename T>
int HowMany(T variable, const std::array<T, kMaxSize>& item_list, int size)
{
    int counter = 0;
    for (int i = 0; i < size; ++i)
    {
        if(item_list[i] == variable)
        {
            ++counter;
        }
    }
    return counter;
}


#endif