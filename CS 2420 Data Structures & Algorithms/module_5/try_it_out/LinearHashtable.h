#ifndef TRY_IT_OUT_SOURCE_LINEARHASHTABLE_H
#define TRY_IT_OUT_SOURCE_LINEARHASHTABLE_H

#include <iostream>
#include <iomanip>

template <class T>
class LinearHashtable;

template <class T>
std::ostream& operator<< (std::ostream& out, const LinearHashtable<T>& t);



template <class T>
class LinearHashtable
{
public:

    LinearHashtable(int capacity);//Constructor, that initializes the hashtable.  It initializes the array for storing the data to size capacity.
    ~LinearHashtable(); //Deallocates memory used from the array pointer.
    void add(T item);  //Adds an item to the array, if a collision occurs, it will try the next position until it finds an empty position.  If the hashtable is at capacity then std::throw runtime_error("Table is full");
    bool contains(T item); //Determines if an item is in the hashtable
    bool remove(T item); //Removes the item from the hashtable
    bool full(); //Determines if the hashtable has reached capacity
    int size(); //Determines the max capacity of the hashtable
    bool empty(); //returns true if the hashtable is empty
    T &operator[] (int ndx); //returns the value at position ndx
    friend std::ostream& operator<< <>(std::ostream& out, const LinearHashtable<T>& t); //Allows the user to output the hashtable


protected:

    int size_;
    int capacity_;
    T* htable_;

};

/**
 * @brief the constructor of the LinearHashTable class
 * @tparam T any type that can use < > ==
 * @param capacity int size of the array for the hash table
 */
template <class T>
LinearHashtable<T>::LinearHashtable(int capacity)
{
    size_ = 0;
    capacity_ = capacity;
    htable_ = new T[capacity_];

    for (int i = 0; i < capacity_; ++i)
    {
        htable_[i] = -1;
    }

}

/**
 * @brief the destructor for the LinearHashtable class deletes htable_ array
 * @tparam T any type that can use < > ==
 */
template <class T>
LinearHashtable<T>::~LinearHashtable()
{
    delete htable_;
}

/**
 * @brief Checks to see if the LinearHashTable is full by check size_ == capacity
 * @tparam T any type that can use < > ==
 * @return true if it is full , false if not
 */
template <class T>
bool LinearHashtable<T>::full()
{
    if(size_ == capacity_)
    {
        return true;
    }

    return false;
}

/**
 * @brief Returns the max size of LinearHashtable
 * @tparam T any type that can use < > ==
 * @return int returns capacity_
 */
template <class T>
int LinearHashtable<T>::size()
{
    return capacity_;
}

/**
 * @brief checks to see if the LinearHashtable is empty by check size_ == 0
 * @tparam T any type that can use < > ==
 * @return true if its empty, else returns false
 */
template <class T>
bool LinearHashtable<T>::empty()
{
    if(size_ == 0)
    {
        return true;
    }
    return false;
}

/**
 * @brief add the item to the LinearHashtable by checking.  Checks to see if its key location if is filled if so
 * it loops the array finding a spot.  Else it adds it to its key location
 * @tparam T any type that can use < > ==
 * @param item the item to be added to the LinearHashtable
 */
template <class T>
void LinearHashtable<T>::add(T item)
{
    if(size_ == capacity_)
    {
        throw std::runtime_error("Table is full");
    }
    else
    {
        int key = item % capacity_;
        int starting_point = key;
        if(htable_[key] != -1)
        {
            key++;
            while(key != starting_point)
            {
                if(htable_[key] == -1 || htable_[key] == -2)
                {
                    htable_[key] = item;
                    size_++;
                    break;
                }
                key++;
                if(key >= capacity_)
                {
                    key = 0;
                }
            }
        }
        else
        {
            htable_[key] = item;
            size_++;
        }


    }
}

/**
 * @brief Returns the item at the ndx passed in
 * @tparam T any type that can use < > ==
 * @param ndx int the location the user wants to access
 * @return the item in that index
 */
template <class T>
T& LinearHashtable<T>::operator[](int ndx)
{
    if(ndx > capacity_ || htable_[ndx] == -1 || htable_[ndx] == -2)
    {
        throw std::runtime_error("There is nothing at that index");
    }
    return htable_[ndx];
}

/**
 * @brief checks to see if an item is LinearHashtable.  If its in its key location it returns true.  If its not in it
 * by encountering a -1 or by making it back to the starting key value it will return false
 * @tparam T any type that can use < > ==
 * @param item the item the user wants to find
 * @return
 */
template <class T>
bool LinearHashtable<T>::contains(T item)
{
    int key = item % capacity_;
    int starting_point = key;

    if(htable_[key] == item)
    {
        return true;
    }
    else
    {
        while(key != starting_point)
        {
            key++;
            if(htable_[key] == item)
            {
                return true;
            }
            else if(htable_[key] == -1)
            {
                return false;
            }
            else if(key == starting_point)
            {
                return false;
            }
            else if(key == capacity_)
            {
                key = 0;
            }
        }
    }
}

/**
 * @brief Checks to see if the LinearHashtable is empty if so throws runtime_error.  If not gets the key and set
 * starting_point = key.  It then checks to see key location contains the item  an removes it if so and decrease
 *  the size-- and sets the location to -2. if not it loops the array checking to see its anywhere else.
 *  If it encounters a -1 or gets back to where it started it returns false
 * @tparam T
 * @param item
 * @return
 */
template <class T>
bool LinearHashtable<T>::remove(T item)
{
    if(this->empty())
    {
        throw std::runtime_error("Table is empty");
    }

    int key = item % capacity_;
    int starting_point = key;
    if(htable_[key] == item)
    {
        htable_[key] = -2;
        size_--;
        return true;
    }
    else
    {
        while(key != starting_point)
        {
            key++;
            if(htable_[key] == item)
            {
                htable_[key] = -2;
                size_--;
                return true;
            }
            else if(htable_[key] == -1)
            {
                return false;
            }
            else if(key == capacity_)
            {
                key = 0;
            }
            else if(key == starting_point)
            {
                return false;
            }
        }
    }

}

/**
 * @brief out puts the information in a easily read format
 * @tparam T any type that can use < > ==
 * @param out ostream that the user wants to output to
 * @param t any type that can use < > ==
 * @return the formatted data
 */
template <class T>
std::ostream& operator<< (std::ostream& out, const LinearHashtable<T>& t)
{
    for (int i = 0; i < t.capacity_; ++i)
    {
        out << std::setw(8) << i << ": " << t.htable_[i] << std::endl;
    }

    return out;
}


#endif TRY_IT_OUT_SOURCE_LINEARHASHTABLE_H
