#include "SortedCollection.h"

/**
 * @brief: default constructor, sets private variables arraySize_= 8, arrayIndex_ = 0, array[8]
 */
SortedCollection::SortedCollection()
{
    arraySize_ = 8;
    arrayIndex_ = 0;
    array = new double[8];
}

/**
 * None default constructor sets arraySize_ = size and array[size] and arrayIndex= 0
 * @param size int: the size of the array
 */
SortedCollection::SortedCollection(int size)
{
    arraySize_ = size;
    arrayIndex_ = 0;
    array = new double[size];
}

/**
 * @brief: checks to see the last item in the array > item.  It uses Collection::add() add the item.  Then it loops
 * through adjusting the array until all numbers are from least to greatest.  If last item in array < item then it use
 * Collection::add() to add it to the array.
 * @param item double: the double the user wants to add
 */
void SortedCollection::add(double item)
{
    if(array[arrayIndex_ - 1] > item)
    {
        Collection::add(item);
        int temp_index = arrayIndex_ - 2;
        for (int i = temp_index; i >= 0; --i)
        {
            if(array[i] > array[i + 1])
            {
                double larger = array[i];
                double smaller = array[i + 1];
                array[i] = smaller;
                array[i + 1] = larger;
            }

        }

    }
    else if(array[arrayIndex_] < item)
    {
        Collection::add(item);
    }

}

/**
 * @brief: overload operator for the + uses add() to add the item in the array
 * @param item double: the number the user wants to add
 * @return pointer to this
 */
SortedCollection &SortedCollection::operator+(double item)
{
    this->add(item);
    return *this;
}

/**
 * @brief: overload operator for + add a SortedCollection to another.  Use the add()
 * @param other StoredCollection: the other SortedCollection item
 * @return pointer to this
 */
SortedCollection &SortedCollection::operator+(const SortedCollection &other)
{
    for (int i = 0; i < other.arrayIndex_; ++i)
    {
        this->add(other.array[i]);
    }
    return *this;
}

/**
 * @brief: overload operator for << uses add() to add item to the array
 * @param item double: the number the user wants to add
 * @return pointer to this
 */
SortedCollection &SortedCollection::operator<<(double item)
{
    this->add(item);
    return *this;
}
