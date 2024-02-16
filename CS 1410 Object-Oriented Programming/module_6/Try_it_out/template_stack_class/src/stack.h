#ifndef STACK_H
#define STACK_H
#include <array>

/**
 * @brief: A template class for the Stack class.  It creates an array to store type T into and functions like a Stack
 * @tparam T: the type the user defines
 * @tparam max_size: an int to set the size of the array.
 */
template <typename T, int max_size>
class Stack
{
private:
    // The array used for the class
    std::array<T, max_size>stack_{};
    // Used for marking where in the array
    int top_;

public:
    // Constructor and destructor
    Stack() : top_(0) {}
    Stack(T item);
    ~Stack() {}

    // Other methods
    void Push(T item);
    T Pop();
    T Top() const;
    int Size() const;
    bool Empty() const;
    bool Full() const;

};

/**
 * @brief: Adds the new item to the next index in the array
 * @tparam T: The data type that is used for the Stack. Must match the same type as the Stack object
 * @tparam max_size: The size of the array
 * @param item: the item that the user wants to to add to the array
 * @remark: Throws out_of_range if the top_ = max_size
 */
template<typename T, int max_size>
void Stack<T, max_size>::Push(T item)
{
    if(top_ == max_size)
    {
        throw std::out_of_range("The stack is full item was not added.");
    }
    stack_[top_++] = item;
}

/**
 * @breif: A constructor for the Stack class.
 * @tparam T: They type the user wants to make the array.
 * @tparam max_size: the size of the array
 * @param item: the item that the user wants to add to the array
 */
template<typename T, int max_size>
Stack<T, max_size>::Stack(T item)
{
    top_= 0;
    Push(item);
}

/**
 * @brief: Move the top_ down one in the array so more items can be put in the array.
 * @tparam T: The type that is used in the array.
 * @tparam max_size: The size of the array.
 * @return: The new location in the array.
 * @remark: Throw's out of range when the array is at 0
 */
template<typename T, int max_size>
T Stack<T, max_size>::Pop()
{
    if(top_ == 0)
    {
        throw std::out_of_range("The stack is empty");
    }
    top_ -= 1;
    return stack_[top_];
}

/**
 * @breif: Tells the user whats is on top of the array.
 * @tparam T: The type of the array
 * @tparam max_size: The size of the array.
 * @return: the value currently is on top of the stack.
 * @remark: Throws out_of_range if top_ = 0
 */
template<typename T, int max_size>
T Stack<T, max_size>::Top() const
{
    if(top_ == 0)
    {
        throw std::out_of_range("The stack is empty");
    }
    return stack_[top_ -1];
}

/**
 * @brief Gives the user the current size of the array
 * @tparam T: The type of the array
 * @tparam max_size: The size of the array
 * @return Where top_ is currently is in the array
 */
template<typename T, int max_size>
int Stack<T, max_size>::Size() const
{
    return top_;
}

/**
 * @brief: Checks the see if the array is empty.
 * @tparam T: The type of the array
 * @tparam max_size: The size of the array
 * @return True of array = 0. returns false if not
 */
template<typename T, int max_size>
bool Stack<T, max_size>::Empty() const
{
    if (top_ == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief: Checks to see if the array is full by check top_ = max_size
 * @tparam T: The type of the array
 * @tparam max_size: The size of the array
 * @return: True if top_ = max_size if not returns false
 */
template<typename T, int max_size>
bool Stack<T, max_size>::Full() const
{
    if(top_ == max_size)
    {
        return true;
    }
    else
    {
        return false;
    }
}


#endif