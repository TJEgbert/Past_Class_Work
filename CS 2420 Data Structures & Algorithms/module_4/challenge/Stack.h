#ifndef ORDEREDLINKEDLIST_H
#define ORDEREDLINKEDLIST_H
#include <iostream>
#include <string>

template <class Type>
struct Node
{
	Type data;
	Node *next;
};

template <class Type>
class Stack;

template <class Type>
std::ostream& operator<<(std::ostream&, const Stack<Type>& stack);


template <class Type>
class Stack
{
public:
	Stack();
	Stack(const Stack& other);
	Stack<Type>& operator=(const Stack<Type>& other);
	~Stack();

    int size() const;
    bool empty() const;
	Type top() const;
	void push(const Type&);
	void pop();
    void pop(int);
    Type topPop();
    void clear();
    friend std::ostream& operator<< <>(std::ostream&, const Stack<Type>& list);
    std::string format(int loops) const;
    Type copyHelper(int loops) const;

private:
    int size_;
    Node<Type>* front_;
    Node<Type>* back_;
};

/**
 * @breif Default constructor of the Stack class.  Sets the private data members
 * @tparam Type any data class that can use ==
 */
template <class Type>
Stack<Type>::Stack()
{
    front_ = nullptr;
    back_ = nullptr;
    size_ = 0;

}

/**
 * @brief Copy constructor of the Stack class sets private data members.  Uses push() and copyHelper() to make a copy
 * @tparam Type any data class that can use ==
 * @param other the Stack object to copy
 */
template <class Type>
Stack<Type>::Stack(const Stack<Type>& other)
{
    front_ = nullptr;
    back_ = nullptr;
    size_ = 0;
    int loops = 0;

    while(size_ != other.size_)
    {
        ++loops;
        this->push(other.copyHelper(loops));
    }

}

/**
 * @brief Overload operator for =.  Uses clear() to clear out the Stack object and then uses push() and copyHelper() to
 * copy the other Stack object
 * @tparam Type any data class that can use ==
 * @param other the stack object you want to copy
 * @return the update stack object
 */
template <class Type>
Stack<Type>& Stack<Type>::operator=(const Stack& other)
{
    this->clear();
    int loops = 0;

    while(size_ != other.size_)
    {
        ++loops;
        this->push(other.copyHelper(loops));
    }

    return *this;
}

/**
 * @brief The destructor for the Stack class.  Deletes all the nodes and pointers for Stack object
 * @tparam Type any data class that can use ==
 */
template <class Type>
Stack<Type>::~Stack()
{
    Node<Type>* deleteNode;

    while(front_ != nullptr)
    {
        deleteNode = front_;
        front_ = front_->next;
        delete deleteNode;
    }
}

/**
 * @brief Returns the current size of the Stack object
 * @tparam Type any data class that can use ==
 * @return int size_
 */
template <class Type>
int Stack<Type>::size() const
{

    return size_;
}

template <class Type>
bool Stack<Type>::empty() const
{
    if(size_ == 0)
    {
        return true;
    }

    return false;
}

/**
 * @brief Returns the data that is at the front of the Stack
 * @tparam Type any data class that can use ==
 * @return front->data
 */
template <class Type>
Type Stack<Type>::top() const
{
    if(front_ == nullptr)
    {
        throw std::logic_error("The stack is empty");
    }
    Type ret;
    ret = front_->data;
    return ret;
}

/**
 * @brief Adds a new item to the Stack object.  Checks to see if the size of the stack is zero if so it sets
 * front_ and back_ to the new node and increases size.  Else it updates the front and the new node to add it to the
 * stack
 * @tparam Type any data class that can use ==
 * @param item the data that gets added to the stack
 */
template <class Type>
void Stack<Type>::push(const Type& item)
{
    auto addedNode = new Node<Type>;
    addedNode->data = item;

    if(size_ == 0)
    {
        front_ = addedNode;
        back_ = addedNode;
        addedNode->next = nullptr;
        ++size_;
    }
    else
    {
        addedNode->next = front_;
        front_ = addedNode;
        ++size_;
    }
}

/**
 * @brief Removes the first item in the Stack.  If its empty it does nothing else it removes the item
 * @tparam Type any data class that can use ==
 */
template <class Type>
void Stack<Type>::pop()
{
    if(front_ == nullptr)
    {
        ;
    }
    else
    {
        auto deleteNode = front_;
        front_ = front_->next;
        delete deleteNode;
        --size_;
    }
}

/**
 * @brief Removes how many that gets passed through count.  If count greater then the stack size it remove all that it
 * can.  Else it removes how many that gets passed in.  Uses the single pop() to do this
 * @tparam Type any data class that can use ==
 * @param count the number to be removed from the stack
 */
template <class Type>
void Stack<Type>::pop(int count)
{
    if(count > size_)
    {
        for (int i = 0; i < size_; ++i)
        {
            this->pop();
        }
        size_ = 0;
    }
    else
    {
        for (int i = 0; i < count; ++i)
        {
            this->pop();
        }
    }
}

/**
 * @brief Returns the data and the top of the stack and removes it.   If the Stack is empty throws logic error
 * @tparam Type any data class that can use ==
 * @return the data at the top of the stack
 */
template <class Type>
Type Stack<Type>::topPop()
{
    if(front_ == nullptr)
    {
        throw std::logic_error("List is empty");
    }
    else
    {
        Type ret;
        ret = front_->data;
        this->pop();
        return ret;
    }
}

/**
 * @brief Deletes the nodes in the Stack object and resets the private variable to there default
 * @tparam Type any data class that can use ==
 */
template <class Type>
void Stack<Type>::clear()
{
    Node<Type>* deleteNode;
    while(front_ != nullptr)
    {
        deleteNode = front_;
        front_ = front_->next;
        delete deleteNode;
    }
    front_= nullptr;
    back_ = nullptr;
    size_ = 0;
}

/**
 * @brief A recursive helper function for the << overload operator.  Loops through and gets the data from each node
 * and formats it
 * @tparam Type any data class that can use ==
 * @param loops int the number that needs to minus by to get to the next data
 * @return string:  the formatted string example "1->2->3->4" for being the head / front
 */
template <class Type>
std::string Stack<Type>::format(int loops) const
{
    std::string data = "";
    auto currentNode = front_;
    if(size_ == 0)
    {
        ;
    }
    else
    {
        if(loops == size_)
        {
            data = std::to_string(currentNode->data);
        }
        else
        {
            for (int i = 0; i < size_ - loops; ++i)
            {
                currentNode = currentNode->next;
            }

            data = std::to_string(currentNode->data) + "->" + format(loops + 1);
        }
    }

    return data;
}

/**
 * @brief Helper function.  Loops through the Stack returning the data in the correct order for the copying functions
 * @tparam Type any data class that can use ==
 * @param loops the number that size_ needs to be minus by to loop to the correct data
 * @return the data from the Stack
 */
template <class Type>
Type Stack<Type>::copyHelper(int loops) const
{
    auto currentNode = front_;
    Type data = currentNode->data;

    if(loops == size_)
    {
        data = (currentNode->data);
    }
    else
    {
        for (int i = 0; i < size_ - loops; ++i)
        {
            currentNode = currentNode->next;
        }

        data = currentNode->data;
        return data;
    }

    return data;
}

/**
 * @brief: With the help of format outputs the data from the stack formatted
 * @tparam Type any data class that can use ==
 * @param out ostream that you want to output to
 * @param list the Stack object
 * @return ostream out with formatted data
 */
template <class Type>
std::ostream& operator<<(std::ostream& out, const Stack<Type>& list)
{
    out << list.format(1);
    return out;


}
#endif
