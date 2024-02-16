#include "Collection.h"

/**
 * @brief: default constructor sets arraySize_ = 8, arrayIndex = 0, array[8]
 */
Collection::Collection()
{
    arraySize_ = 8;
    arrayIndex_ = 0;
    array = new double[8];
}

/**
 * @brief: non default constructor sets arraySize_ = size and array[size].  arrayIndex_ = 0
 * @param size int: the size of array to make
 */
Collection::Collection(int size)
{
    arraySize_ = size;
    arrayIndex_ = 0;
    array = new double[size];

}

/**
 * @brief: returns the current size of the array
 * @return int: arrayIndex_
 */
int Collection::getSize() const
{
   return arrayIndex_;
}

/**
 * @brief: returns the max size of the array
 * @return int: arraySize_
 */
int Collection::getCapacity() const
{
   return arraySize_;
}

/**
 * @brief: takes in ndx and returns the double that is there.  If ndx > or ndx < 0 then it throws out_of_range
 * @param ndx int: the index number the use wants to get
 * @return double: the number at the ndx
 */
double Collection::get(int ndx) const
{
   if(ndx > arrayIndex_ - 1|| ndx < 0)
   {
       throw std::out_of_range("That number is out of the scope of the array");
   }
   else
   {
       return array[ndx];
   }
}

/**
 * @brief: gets the double the is at array[0].  throws out_of_range if the array is empty arrayIndex_ = 0
 * @return double: array[0]
 */
double Collection::getFront() const
{
   if(arrayIndex_ == 0)
   {
       throw std::out_of_range("The array is empty");
   }
   return array[0];
}

/**
 * @brief: returns the last item currently is in the array. if the arrayIndex_ = 0 throw_out_range that the array is
 * empty.
 * @return double: array[arrayIndex_ - 1]
 */
double Collection::getEnd() const
{
   if(arrayIndex_ == 0)
   {
       throw std::out_of_range("The array is empty");
   }
   return array[arrayIndex_ - 1];
}

/**
 * @brief: loops through the array looking for needle and then returns the index that its at. if its not in there
 * returns -1
 * @param needle: the double the user wants to find
 * @return int: if found the index if not returns -1
 */
int Collection::find(double needle) const
{
    for (int i = 0; i < arraySize_; ++i)
    {
        if(array[i] == needle)
        {
            return i;
        }

    }

   return -1;
}

/**
 * @brief:checks to see if the arrayIndex_ = arraySize_.  If so it makes a temp copy of the current array and then makes
 * a new array double the size.  Then it copies the temp to the new array and add the new item.  If not
 * arrayIndex_ = arraySize_ then it adds it the end of the array and increase the index
 * @param item double: the number the use wants to add
 */
void Collection::add(double item)
{
    if(arrayIndex_ == arraySize_)
    {
        int new_size = arraySize_ * 2;
        auto temp = new double[arraySize_];
        for (int i = 0; i < arrayIndex_; ++i)
        {
            temp[i] = array[i];
        }
        array = new double[new_size];
        arraySize_ = new_size;
        for (int i = 0; i < arrayIndex_; ++i)
        {
            array[i] = temp[i];
        }

        array[arrayIndex_] = item;
        ++ arrayIndex_;
    }
    else
    {
        array[arrayIndex_] = item;
        ++arrayIndex_;
    }
}

/**
 * @brief: if arrayIndex_= 0 then it does nothing. Else it loops through the array copying everything over and then
 * -- arrayIndex_
 */
void Collection::removeFront()
{
    if(arrayIndex_ == 0)
    {
        ;
    }
    else
    {
        for (int i = 0; i < arrayIndex_; ++i)
        {
            array[i] = array[i + 1];
        }
        --arrayIndex_;
    }
}

/**
 * @breif: if arrayIndex = 0 then it does nothing.  Else --arrayIndex_ and then replace that with 0;
 */
void Collection::removeEnd()
{
    if(arrayIndex_ == 0)
    {
        ;
    }
    else
    {
        --arrayIndex_;
        array[arrayIndex_] = 0;
    }

}

/**
 * @brief: checks to see if the item is in the array keeps track of what index its at.  If item_index = item then it
 * breaks from the loop and returns nothing.  Then if items_index < arraySize_ it copies over the array and --arrayIndex.
 * Removes the first instance of the number
 * @param item double: the number the user wants to remove
 */
void Collection::remove(double item)
{
    int item_index = 0;
    while (array[item_index] != item)
    {
        ++item_index;
        if (item_index == arraySize_)
        {
            break;
        }
    }

    if (item_index < arraySize_)
    {
        for (int i = item_index; i < arrayIndex_; ++i)
        {
            array[i] = array[i + 1];
        }
        --arrayIndex_;
    }
}

/**
 * @brief: overload operator [] if ndx > arrayIndex_ - 1 if ndx < 0 it throws out_of_range. returns the double at
 * array[ndx]
 * @param ndx int: the index the user wants to access.
 * @return double reference: the array[ndx]
 */
double& Collection::operator[](int ndx)
{
    if(ndx > arrayIndex_ - 1|| ndx < 0)
    {
        throw std::out_of_range("That number is out of the scope of the array");
    }

    return array[ndx];
}

/**
 * @brief: overload operator - checks to see if the - count us greater > arrayIndex_ then loops through the array \
 * putting zero and resets that arrayIndex_ = 0.  Else then loops through the amount to minus setting it to zero then
 * it minus count from arrayIndex.
 * @param count int: the amount the user wants to remove form the array
 * @return Collection&: the update object
 */
Collection& Collection::operator-(int count)
{
    if(count > arrayIndex_)
    {
        for (int i = arrayIndex_; i > 0; --i)
        {
            array[i] = 0;
        }
        arrayIndex_ = 0;
    }
    else
    {
        for (int i = arrayIndex_; i >= (arrayIndex_ - count); --i)
        {
            array[i] = 0;
        }
        arrayIndex_ = arrayIndex_ - count;
    }
   return *this;
}

/**
 * @brief: overload operator + uses the add() add the item to array
 * @param item double: the number the user wants to add
 * @return Collection&: the updated object
 */
Collection& Collection::operator+(double item)
{
    this->add(item);
   return *this;
}

/**
 * @brirf: overload operator + add Collections object to another:
 * @param other Collections&;
 * @return Collection&: the updated object
 */
Collection& Collection::operator+(const Collection& other)
{
    for (int i = 0; i < other.arrayIndex_; ++i)
    {
        this->add(other.array[i]);
    }
   return *this;
}

/**
 * @brief: overload operator of << uses add() to add item to the array
 * @param item double: the number the user wants to add
 * @return Collection&: updated object
 */
Collection& Collection::operator<<(double item)
{
    this->add(item);
   return *this;
}

/**
 * @brief: friend operator of the << and output to ostream.
 * @param out ostream&: the ostream the user wants to output to
 * @param other Collection& object: the one the user wants to output the array for
 * @return ostream&: format as "1 2 3 4 5"
 */
std::ostream& operator<<(std::ostream& out, const Collection& other)
{
    for (int i = 0; i < other.arrayIndex_; ++i)
    {
        out << other.array[i] << " ";
    }
   return out;
}

/**
 * @brief: copy constructor
 * @param other Collection object the user wants to copy
 */
Collection::Collection(const Collection &other)
{
    array = new double[other.arraySize_];
    arrayIndex_ = other.arrayIndex_;
    for (int i = 0; i < arrayIndex_; ++i)
    {
        array[i] = other.array[i];
    }
    arraySize_ = other.arraySize_;
}

/**
 * @brief: destructor for Collection class
 */
Collection::~Collection()
{
    delete array;
}

/**
 * @brief: overload operator = copies Collection object
 * @param other Collection&: the object the user wants to copy
 * @return Collection&;
 */
Collection& Collection::operator=(const Collection& other)
{
    if(this != &other)
    {
        delete array;
        array = new double[other.arraySize_];
        arrayIndex_ = other.arrayIndex_;
        *array = *(other.array);
        arraySize_ = other.arraySize_;
    }
}
