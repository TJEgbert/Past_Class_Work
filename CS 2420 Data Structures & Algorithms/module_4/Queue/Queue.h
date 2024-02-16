#ifndef QUEUE_QUEUE_H
#define QUEUE_QUEUE_H
#include <iostream>
#include <string>

template <class Type>
struct Node
{
    Type data;
    Node *next;
};

template <class Type>
class Queue;

template <class Type>
std::ostream &operator<<(std::ostream&, Queue<Type> &q);

template <class Type>
class Queue
{
public:
    Queue();
    Queue(const Queue &other);
    ~Queue();
    void enqueue(Type item);
    void dequeue();
    Type peek();
    int size();
    bool empty();
    void clear();
    std::string output(Node<Type> *toPrint);
    friend std::ostream &operator<< <>(std::ostream &out, Queue<Type> &q);

private:
    Node<Type>* front;
    Node<Type>* back;
    int count;
    std::string fOutPut;
};

/**
 * @breif Default constructor of the Queue class sets the private variables
 * @tparam Type any type that can be use with = < > and <<
 */
template <class Type>
Queue<Type>::Queue()
{
    front = nullptr;
    back = nullptr;
    count = 0;
    fOutPut = "";
}

/**
 * @brief Copy constructor of the Queue. Set the private data members and use enqueue() to copy data from the other
 * Queue object
 * @tparam Type any type that can be use with = < > and <<
 * @param other Queue object.  The object you want to copy
 */
template <class Type>
Queue<Type>::Queue(const Queue<Type> &other)
{
    front = nullptr;
    back = nullptr;
    count = 0;
    fOutPut = "";


    auto otherCurrNode = other.front;
    while(otherCurrNode != nullptr)
    {
        this->enqueue(otherCurrNode->data);
        otherCurrNode = otherCurrNode->next;
    }
}

/**
 * @brief The destructor of the Queue class.  Loops through deleting nodes in the queue
 * @tparam Type any type that can be use with = < > and <<
 */
template <class Type>
Queue<Type>::~Queue()
{
    Node<Type>* deleteNode;
    while(front != nullptr)
    {
        deleteNode = front;
        front = front->next;
        delete deleteNode;
    }
}

/**
 * @brief Returns the size of the Queue
 * @tparam Type any type that can be use with = < > and <<
 * @return int the count
 */
template <class Type>
int Queue<Type>::size()
{
    return count;
}

/**
 * @brief Returns if the the Queue is empty of not
 * @tparam Type any type that can be use with = < > and <<
 * @return true if count == 0 else returns false
 */
template <class Type>
bool Queue<Type>::empty()
{
    if(count == 0)
    {
        return true;
    }
    return false;
}

/**
 * @brief Adds the item into the Queue object. If its the first item it updates front and back nodes.  Else it will
 * update the back->next and to the new node and then update back.  both updates count
 * @tparam Type any type that can be use with = < > and <<
 * @param item the data the user wants to add to the Queue
 */
template <class Type>
void Queue<Type>::enqueue(Type item)
{
    auto addNode = new Node<Type>;
    addNode->data = item;
    if(front == nullptr)
    {
        front = addNode;
        back = addNode;
        addNode->next = nullptr;
        ++count;
        return;
    }
    else
    {
        addNode->next = nullptr;
        back->next = addNode;
        back = addNode;
        ++count;
        return;
    }
}

/**
 * @brief Removes the first item in the Queue and updates accordingly.  If count == 1 then it well also updated the back
 * both updates counts
 * @tparam Type any type that can be use with = < > and <<
 */
template <class Type>
void Queue<Type>::dequeue()
{
    auto deleteNode = front;
    if(front == nullptr)
    {
        throw std::out_of_range("The queue is empty");
    }
    else
    {
        if(count == 1)
        {
            delete deleteNode;
            front = nullptr;
            back = nullptr;
            --count;
        }
        else
        {
            front = deleteNode->next;
            delete deleteNode;
            --count;
        }
    }
}

/**
 * @brief Checks the first item in the Queue if count == 0 then it throws out of range
 * @tparam Type any type that can be use with = < > and <<
 * @return the first item in the Queue
 */
template <class Type>
Type Queue<Type>::peek()
{
    if(count == 0)
    {
        throw std::out_of_range("This list is empty");
    }

    return front->data;
}

/**
 * @brief: Clears out all the Nodes out of the Queue object and sent the private data members back to there default
 * @tparam Type any type that can be use with = < > and <<
 */
template <class Type>
void Queue<Type>::clear()
{

    Node<Type>* deleteNode;
    while(front != nullptr)
    {
        deleteNode = front;
        front = front->next;
        delete deleteNode;
    }
    front = nullptr;
    back = nullptr;
    count = 0;
    fOutPut = "";

}

/**
 * @brief recursive functions that converts the data into a string and stores into the private data member FOutPut
 * @tparam Type any type that can be use with = < > and <<
 * @param toPrint A node
 * @return the formatted string as ->
 */
template <class Type>
std::string Queue<Type>::output(Node<Type> *toPrint)
{
    if(toPrint->next == nullptr)
    {
        fOutPut = std::to_string(toPrint->data);
        return fOutPut;
    }
    else
    {
        fOutPut = std::to_string(toPrint->data) + "->" + output(toPrint->next);
        return fOutPut;
    }
}

/**
 *
 * @tparam Type any type that can be use with = < > and <<
 * @param out ostream that you want to output to
 * @param q the Queue Object you want to use
 * @return the formatted data
 */
template <class Type>
std::ostream &operator<< (std::ostream &out, Queue<Type> &q)
{
    q.output(q.front);

    out << q.fOutPut;
    return out;
}

#endif //QUEUE_QUEUE_H
