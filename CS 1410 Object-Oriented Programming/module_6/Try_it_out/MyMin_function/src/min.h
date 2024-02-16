#ifndef MIN_H
#define MIN_H

/**
 * @brief: template function that checks that if a variable is less then that other variable
 * @tparam T: the type that the user uses for the function as longs as it supports the < operator
 * @param one: the first variable
 * @param two: the second variable
 * @return: T type of the smaller variable
 */
template <typename T>
T MyMin(const T& one, const T& two)
{
    if(one < two)
    {
        return one;
    }
    else
    {
        return two;
    }
}


#endif