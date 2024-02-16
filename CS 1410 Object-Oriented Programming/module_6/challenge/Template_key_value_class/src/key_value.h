#ifndef KEY_VALUE_H
#define KEY_VALUE_H
#include <vector>
#include <iostream>
#include <algorithm>

/**
 * @brief: A template class the creates two vectors, and manages the values inside them.
 * @tparam K: Data type the user chooses.  This is the Key and used for looking up elements in the vectors
 * @tparam V: Date type the user chooses.
 * @tparam max_size: An int that manages the size of the vector.
 */
template<typename K, typename V, int max_size>
class KeyValue
{
private:
    // Vectors
    std::vector<K>keys_{};
    std::vector<V>values_{};

    // Variables
    int size_;

    // Other methods
    int FindIndex(K key) const;

public:
    // Constructor and destructor
    KeyValue() : size_(0) {}
    ~KeyValue() {}

    // Other methods
    int GetSize() const {return size_;}
    bool KeyExists(K key) const;
    void Add(K key, V item);
    V ValueAt(K key) const;
    bool Full() const;
    bool Empty() const;
    bool RemoveOne(K key);
    int RemoveAll(K key);

    /**
     * @brief: Friend operator is the << class.  Used to output formatted key_ and item_ vector elements
     * @param out:  A reference in the ostream item we are outputting to
     * @param kv: A reference to the KeyValue objects
     * @return out: The formatted data
     */
    friend std::ostream& operator<<(std::ostream& out, const KeyValue<K, V, max_size>& kv)
    {
        int i = 0;
        while(i < kv.size_)
        {
            out << kv.keys_[i] << ": " << kv.values_[i] << std::endl;
            i++;
        }
        return out;
    }

};

/**
 * @brief: Adds the key, and item to there respective vectors and updates size_
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: The data the user wants to add must match data type K
 * @param item: The data the user wants to add must match data type V
 * @remark: Checks to see of size_ = max_size and throw out_of_range
 */
template<typename K, typename V, int max_size>
void KeyValue<K, V, max_size>::Add(K key, V item)
{
    if(size_ == max_size)
    {
        throw std::out_of_range("The KeyValue container is full, item was not added");
    }
    keys_.insert(keys_.begin() + size_, key);
    values_.insert(values_.begin() + size_, item);

    size_++;
}

/**
 * @brief: The private methods that finds the key_ index in the vector
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: The data the user wants to look for.  Must match K type
 * @return: returns to location in the vector of key or returns -1 if not in the vector
 */
template<typename K, typename V, int max_size>
int KeyValue<K, V, max_size>::FindIndex(K key) const
{
    for (int i = 0; i < keys_.size() ; ++i)
    {
        if(keys_[i] == key)
        {
            return i;
        }
    }
    return -1;
}

/**
 * @brief: Checks to see if the key is in the vector uses FindIndex
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: The data the user wants to look for.  Must match K type
 * @return: True if the data is found and returns false if not
 */
template<typename K, typename V, int max_size>
bool KeyValue<K, V, max_size>::KeyExists(K key) const
{
    if(FindIndex(key) >= 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief: Looks to key using that FindIndex method and returns the value associated with it
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: The data the use wants to look for.  Must match K type
 * @return: The value associated with the key
 * @remark: Throws out_of_range if the key is not fond
 */
template<typename K, typename V, int max_size>
V KeyValue<K, V, max_size>::ValueAt(K key) const
{
    int results = FindIndex(key);
    if (results >= 0)
    {
        return values_[results];
    }
    else
    {
        throw std::out_of_range("The key was not fond.");
    }
}

/**
 * @brief: Checks to see if the key_vector is empty
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @return: True if vector is at zero if returns false
 */
template<typename K, typename V, int max_size>
bool KeyValue<K, V, max_size>::Empty() const
{
    if(keys_.empty())
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief: Checks to see if the key_vector size == max_size
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @return: True if vector is = to max_size, false if not
 */
template<typename K, typename V, int max_size>
bool KeyValue<K, V, max_size>::Full() const
{
    if(keys_.size() == max_size)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief: Using the FindIndex method it removes the key in the key_vector and removes the value associated value_vector
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: the data that the user wants to remove
 * @return: True if something got removed, false if there was nothing to remove
 */
template<typename K, typename V, int max_size>
bool KeyValue<K, V, max_size>::RemoveOne(K key)
{
    int loc = FindIndex(key);
    if(loc >= 0)
    {
        keys_.erase(keys_.begin() + loc);
        values_.erase(values_.begin() + loc);
        size_--;
        return true;
    }
    else
    {
        return false;

    }
}

/**
 * @brief Uses the RemoveOne method and repeats it until all keys_ and values_ are removed matching key
 * @tparam K: The data type the user chose when creating the object
 * @tparam V: The data type the user chose when creating the object
 * @tparam max_size: The max size the vector can be
 * @param key: the data that the user wants to remove
 * @return: an int of the count that got removed from the vectors.
 */
template<typename K, typename V, int max_size>
int KeyValue<K, V, max_size>::RemoveAll(K key)
{
    int count = 0;
    while(RemoveOne(key))
    {
        count++;
    }

    return count;
}

#endif