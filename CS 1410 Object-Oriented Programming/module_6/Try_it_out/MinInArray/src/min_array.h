#ifndef MIN_ARRAY_H
#define MIN_ARRAY_H
#include <array>

const int kMaxSize = 20;

/**
 * @brief: A template function for an Array to find the smallest variable
 * @tparam T: Variable type the user uses
 * @param item_array: a reference to an array the user uses
 * @param size:  The size of the array the user is using
 * @return the smallest variable of the array
 */
template<typename T>
T MinInArray(const std::array<T, kMaxSize>& item_array, int size)
{
    T min_val = item_array[0];
    for (int i = 0; i < size; ++i)
    {
        if (item_array[i] < min_val)
        {
            min_val = item_array[i];
        }
    }
    return min_val;
}

#endif