#include "Collection.h"

/**
 *@brief default constructor sets arraySize_, arrayIndex, and sets up the collectionArray_ to arraySize_
 */
Collection::Collection()
{
    arraySize_ = 10;
    arrayIndex_ = 0;
    collectionArray_ = new double[arraySize_];
}

/**
 * @brief none default constructor sets arraySize_ = size, arrayIndex_ and sets up the collectionArray_ with arraySize_
 * @param size int: to set the size of the collectionArray_
 */
Collection::Collection(int size)
{
    arraySize_ = size;
    arrayIndex_ = 0;
    collectionArray_ = new double[arraySize_];
}

/**
 * @breif: checks to see what is at ndx in the collectionArray_
 * @param ndx int: used to get the double in the collectionArray_[ndx]
 * @return double: the double that is at collectionArray_[ndx]
 */
double Collection::get(int ndx)
{
    if(ndx >= arrayIndex_)
    {
        throw std::out_of_range("The index is outside of the range of the array");
    }
    else
    {
        return collectionArray_[ndx];
    }
}

/**
 * @brief: checks to see if arrayIndex == arraySize if so it throws out of range if not it add it to collectionArray_
 * and increase the arrayIndex by 1
 * @param value double: the number the user wants to add into the collectionArray_
 */
void Collection::add(double value)
{
    if(arrayIndex_ == arraySize_)
    {
        throw std::runtime_error("Array is full");
    }
    else
    {
        collectionArray_[arrayIndex_] = value;
        arrayIndex_++;
    }

}

/**
 * @brief: friend operator for << to print at the double in the collectionArray_ in format of "1 2 3 ..."
 * @param out ostream: where the doubles well be written to
 * @param c Collection: object passed in by reference to print out
 * @return array of doubles formatted
 */
std::ostream& operator<<(std::ostream& out, const Collection & c)
{

    for (int i = 0; i < c.arrayIndex_; ++i)
    {
        if(i != c.arrayIndex_ - 1)
        {
            out << c.collectionArray_[i] << " ";
        }
    }
    return out << c.collectionArray_[c.arrayIndex_ - 1];
}

/**
 * @breif: checks to see if the collectionArray_ is empty and throws out of range if not returns the double in index 0
 * @return double: the first item in the collectionArray_
 */
double Collection::getFront()
{
    if (arrayIndex_ == 0)
    {
        throw std::out_of_range("The array is empty.");
    }
    else
    {
        return collectionArray_[0];
    }
}

/**
 * @breif: checks to see if the collectionArray_ is empty and throws out of range if not returns the double at where
 * the arrayIndex_ is at
 * @return double: the last item in the collectionArray_
 */
double Collection::getEnd()
{
    if (arrayIndex_ == 0)
    {
        throw std::out_of_range("The array is empty.");
    }
    else
    {
        return collectionArray_[arrayIndex_];
    }
}

/**
 * @brief loops through the array to find the number the user passes in an return the index if not found returns -1
 * @param needle double: the double the user wants to find
 * @return int: the index of the double the user wants to find
 */
int Collection::find(double needle)
{
    for(int i = 0; i < arrayIndex_; ++i)
    {
        if(collectionArray_[i] == needle)
        {
            return i;
        }
    }
    return -1;
}

/**
 * @brief: loops through the array moving every double back one space to add the new double at the front of the
 * collectionArray_
 * @param value double: the value user wants to add to the collectionArray_
 */
void Collection::addFront(double value)
{
    if(arrayIndex_ == arraySize_)
    {
        throw std::runtime_error("Array is full");
    }
    else
    {
        for(int i = arrayIndex_; i >= 0; --i)
        {
            collectionArray_[i + 1] = collectionArray_[i];
        }
        collectionArray_[0] = value;
        arrayIndex_ ++;
    }
}