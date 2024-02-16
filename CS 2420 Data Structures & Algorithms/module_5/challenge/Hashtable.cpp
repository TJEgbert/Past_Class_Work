#include "Hashtable.h"


const int Hashtable::c1 = 0;
const int Hashtable::c2 = 1;

/**
 * @brief Calculates the base key used in the quadratic probing v % capacity of the hashtable
 * @param v int passed in for calculations
 * @return the base key for int passed in
 */
int Hashtable::hash(int v) const
{
   return v % capacity();
}

/**
 *@brief The default constructor for the class Hashtable
 * sets the private variables to defaults for and then uses fillTable() to fill the array with -1
 */
Hashtable::Hashtable()
{
    capacity_ = 17;
    size_ = 0;
    loadFactor_ = .65;
    hTable_ = new int[capacity_];
    this->fillTable();

}

/**
 * @brief A none default constructor for the class Hashtable uses default values expect for the capacity which gets
 * passed in.  Uses fillTable() to fill the array with -1
 * @param capacity int the current max size of the HashTable
 */
Hashtable::Hashtable(int capacity)
{
    capacity_ = capacity;
    size_ = 0;
    loadFactor_ = .65;
    hTable_ = new int[capacity_];
    this->fillTable();
}

/**
 * @brief A none default constructor for the class Hashtable uses default values expect for the capacity and threshold
 * which gets passed in.  Uses fillTable() to fill the array with -1.
 * @param capacity int the current max size of the Hashtable
 * @param threshold double that when the size_ / capacity_ is greater the table well resize itself
 */
Hashtable::Hashtable(int capacity, double threshold)
{
    capacity_ = capacity;
    size_ = 0;
    loadFactor_ = threshold;
    hTable_ = new int[capacity_];
    this->fillTable();
}

/**
 * @breif Copy constructor for the Hashtable class.  Sets the private variables the the Hashtable that gets passed in
 * uses fillTable() to fill the array with -1.  Then it loops through the other and checks if anything -1 or -2
 * if not it uses the insert() to add the values to the table.
 * @param other Hashtable object tha the user wants to copy
 */
Hashtable::Hashtable(const Hashtable& other)
{
    capacity_ = other.capacity_;
    loadFactor_ = other.loadFactor_;
    hTable_ = new int[capacity_];
    this->fillTable();
    for (int i = 0; i < other.capacity_; ++i)
    {
        if(other.hTable_[i] == -1 || other.hTable_[i] == -2)
        {
            ;
        }
        else
        {
            this->insert(other.hTable_[i]);
        }

    }
}

/**
 * @brief Copy constructor for the Hashtable class.  It deletes the current hTable .Sets the private variables the the
 * Hashtable that gets passed in uses fillTable() to fill the array with -1.  Then it loops through the other and
 * checks if anything -1 or -2 if not it uses the insert() to add the values to the table.
 * @param other Hashtable object that user wants to copy
 * @return the update Hashtable object
 */
Hashtable& Hashtable::operator=(const Hashtable& other)
{
    delete hTable_;
    capacity_ = other.capacity_;
    loadFactor_ = other.loadFactor_;
    size_ = 0;
    hTable_ = new int[capacity_];
    this->fillTable();

    for (int i = 0; i < capacity_; ++i)
    {
        if(other.hTable_[i] == -1 || other.hTable_[i] == -2)
        {
            ;
        }
        else
        {
            this->insert(other.hTable_[i]);
        }
    }

    return *this;
}

/**
 * @brief the destructor of the class it deletes the hTable_ array
 */
Hashtable::~Hashtable()
{
    delete hTable_;
}

/**
 * @brief Returns the size_ private variable
 * @return int the current number of items in the Hashtable
 */
int Hashtable::size() const
{
    return size_;
}

/**
 * @brief Returns the capacity_ private variable
 * @return int the current max size of the Hashtable
 */
int Hashtable::capacity() const
{
    return capacity_;
}

/**
 * @brief Returns the loadFactor_ private variable
 * @return double the threshold that size_ / capacity_ must reach to resize the HashTable
 */
double Hashtable::getLoadFactorThreshold() const
{
   return loadFactor_;
}

/**
 * @brief Checks to see if the Hashtable is empty
 * @return true if size_ is equal to zero else it return false
 */
bool Hashtable::empty() const
{
    if(size_ == 0)
    {
        return true;
    }
    return false;
}

/**
 * @brief Inserts the value value using quadratic probing to handle any collisions.
 * @param value int the item to be added to the Hashtable
 */
void Hashtable::insert(int value)
{
    // First sets up the for loop, so it can be used the formula to get the key
    for (int i = 0; i < capacity_; ++i)
    {
        // key formula
        int key = ((hash(value) + c1 * i + c2 * i * i) % capacity_);

        // Once the key location is == -1 or -2 it will inset itself at that location and updates the size_ and break
        if (hTable_[key] == -1 || hTable_[key] == -2)
        {
            hTable_[key] = value;
            size_++;
            break;
        }

    }
    // Checks to see if size_ / capacity_ >= loadFactor_
    if((static_cast<float>(size_)/static_cast<float>(capacity_)) >= loadFactor_)
    {
        // If so it makes a temp copy if of its by looping through and saving it into a new array
        int tempTable[capacity_];
        // sets tempTableLength to the current capacity_
        int tempTableLength = capacity_;
        for (int i = 0; i < capacity_; ++i)
        {
            tempTable[i] = hTable_[i];
        }

        // it deletes the hTable_ and updates the capacity use nextPrime and passing in the capacity times two
        delete hTable_;
        capacity_ = nextPrime(capacity_ * 2);

        // Creates a new hTable with the updated capacity uses fillTable() and sets the size_ = 0
        hTable_ = new int[capacity_];
        this->fillTable();
        size_ = 0;

        // It loops through the tempTable and uses a recursive call of insert to add the data back into hTable_
        for (int i = 0; i < tempTableLength; ++i)
        {
            // if current item is not equal to -1 or -2 it will inset into the updated table
            if(tempTable[i] == -1 || tempTable[i] == -2)
            {
                ;
            }
            else
            {
                this->insert(tempTable[i]);
            }
        }

    }
}

/**
 * @brief remove the the first instant of the value that gets based in.  It sets up the key with using quadratic probing
 * and searches the Hashtable if found it sets that location to -2 and if not found it does nothing
 * @param value the value the user wants to remove
 */
void Hashtable::remove(int value)
{
    for (int i = 0; i < capacity_; ++i)
    {
        int key = ((hash(value) + c1 * i + c2 * i * i) % capacity_);
        if(hTable_[key] == value)
        {
            hTable_[key] = -2;
            size_--;
            return;
        }
    }
}

/**
 * @brief checks to see if the value is contained in the Hashtable.  Uses quadratic probing to search the Hashtable for
 * the value.
 * @param value int the value the user wants to checks if its in the Hashtable
 * @return true if it found, if not return false.  If it runs into a bin that been empty since the start (-1) it will
 * also return false
 */
bool Hashtable::contains(int value) const
{
    for (int i = 0; i < capacity_; ++i)
    {
        int key = ((hash(value) + c1 * i + c2 * (i * i)) % capacity_);
        if(hTable_[key] == value)
        {
            return true;
        }
        else if(hTable_[key] == -1)
        {
            return false;
        }
    }

    return false;
}

/**
 * @brief Checks the Hashtable to see if a value is and returns the index.  It uses quadratic probing to search for the
 * value
 * @param value int the value the user wants to get the index of
 * @return int the index of the item if not found it returns -1
 */
int Hashtable::indexOf(int value) const
{
    for (int i = 0; i < capacity_; ++i)
    {
        int key = ((hash(value) + c1 * i + c2 * (i * i)) % capacity_);
        if (hTable_[key] == value)
        {
            return key;
        }
    }
    return -1;
}

/**
 * @brief Uses the fillTable function to reset the table to the default state and sets size_ back to zero
 */
void Hashtable::clear()
{

    this->fillTable();
    size_ = 0;
}

/**
 * @brief Checks to see if a number is prime.
 * @param n the number passed to be checked if its prime
 * @return if it is prime returns true else returns false
 */
bool Hashtable::isPrime(int n)
{
    // It checks 2 and 3 manually
    if(n == 2 || n == 3)
    {
        return true;
    }
    else
    {
        // loops through and checks if n is divisible by i if returns 0 then the number is not prime and return false
        for (int i = 2; i <= n/2; ++i)
        {
            if(n % i == 0)
            {
                return false;
            }
        }
    }

    return true;

}

/**
 * @brief Loops through the number while isPrime() false it will increase n++
 * @param n int the number to start at looping at check if its prime
 * @return int the next prime number
 */
int Hashtable::nextPrime(int n)
{
    while(!isPrime(n))
    {
        n++;
    }

    return n;
}

/**
 * @brief loops feeling the hTable with -1 to used as a tracker empty since start
 */
void Hashtable::fillTable()
{
    for (int i = 0; i < capacity_; ++i)
    {
        hTable_[i] = -1;
    }
}
