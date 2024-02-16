#ifndef ORDEREDLINKEDLIST_H
#define ORDEREDLINKEDLIST_H
#include <iostream>

template <class Type>
struct Node
{
	Type data;
	Node *next;
};

template <class Type>
class OrderedLinkedList;

template <class Type>
std::ostream& operator<<(std::ostream&, const OrderedLinkedList<Type>& list);


template <class Type>
class OrderedLinkedList
{
public:
	OrderedLinkedList();
	OrderedLinkedList(const OrderedLinkedList& other);
	OrderedLinkedList<Type>& operator=(const OrderedLinkedList<Type>& other);
	~OrderedLinkedList();

    int size() const;
    bool empty() const;
	Type get(int) const;
	Type getFirst() const;
	Type getLast() const;
	void insert(const Type&);
	int find(const Type&) const;
	void remove(const Type&);
    void clear();
    OrderedLinkedList<Type> everyOtherOdd();
    OrderedLinkedList<Type> everyOtherEven();
    friend std::ostream& operator<< <>(std::ostream&, const OrderedLinkedList<Type>& list);

protected:
    Node<Type>* front;
    Node<Type>* back;
    int count;

};

/**
 * @brief: Default constructor for the OrderedLinkedList sets the protected data members
 * @tparam Type: any data type that can use < > == << operators
 */
template <class Type>
OrderedLinkedList<Type>::OrderedLinkedList()
{
    front = nullptr;
    back = nullptr;
    count = 0;
}

/**
 * @brief: The copy constructor for the OrderedLinkedList.  Sets the data members like the default, then
 * uses insert function to import the data from the other object OrderLinkedList
 * @tparam Type: any data type that can use < > == << operators
 * @param other OrderedLinkedList object: the list that you want to copy from.
 */
template <class Type>
OrderedLinkedList<Type>::OrderedLinkedList(const OrderedLinkedList<Type>& other)
{
    front = nullptr;
    back = nullptr;
    count = 0;

    auto otherCurrentNode = other.front;
    for (int i = 0; i < other.count; ++i)
    {
        this->insert(otherCurrentNode->data);
        otherCurrentNode = otherCurrentNode->next;
    }
}

/**
 * @brief: It uses the clear function to clear out the list and then makes a copy other of the OrderedLinkedList.
 * Uses the same method as the copy constructor
 * @tparam Type any data type that can use < > == << operators
 * @param other OrderLinkedList object: the list that you want to copy from
 * @return the updated OrderLinkedList object
 */
template <class Type>
OrderedLinkedList<Type>& OrderedLinkedList<Type>::operator=(const OrderedLinkedList& other)
{
    this->clear();

    auto otherCurrentNode = other.front;
    for (int i = 0; i < other.count; ++i)
    {
        this->insert(otherCurrentNode->data);
        otherCurrentNode = otherCurrentNode->next;
    }

    return *this;
}

/**
 * @brief: The destructor of the OrderLinkedList cleans up the pointers of the class
 * @tparam Type any data type that can use < > == << operators
 */
template <class Type>
OrderedLinkedList<Type>::~OrderedLinkedList()
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
 * @brief: returns the size of the OrderedLinkedList object
 * @tparam Type any data type that can use < > == << operators
 * @return int count
 */
template <class Type>
int OrderedLinkedList<Type>::size() const
{

    return count;
}

/**
 * @breif: Checks to see if list is empty
 * @tparam Type any data type that can use < > == << operators
 * @return true if count is == 0 if not returns false
 */
template <class Type>
bool OrderedLinkedList<Type>::empty() const
{
    if(count == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

/**
 * @brief Returns the data at pos that gets passed in.  Throws out_of_range if the pos > count or if front == nullptr.
 * @tparam Type any data type that can use < > == << operators
 * @param pos the position the user wants to get the data from
 * @return the data at a given position
 */
template <class Type>
Type OrderedLinkedList<Type>::get(int pos) const
{
    if(pos > count)
    {
        throw std::out_of_range("That is out of bounds for the list");
    }

    if(front == nullptr)
    {
        throw std::out_of_range("The list is empty");
    }
    else
    {
        int nodeCounter = 0;
        auto currentNode = this->front;
        while(nodeCounter < pos)
        {
            ++nodeCounter;
            currentNode = currentNode->next;
        }
        Type ret;
        ret = currentNode->data;
        return ret;
    }
}

/**
 * @breif: Returns the data that is in the first position if the list is empty throws out_of_range
 * @tparam Type any data type that can use < > == << operators
 * @return the data that front is pointing to.
 */
template <class Type>
Type OrderedLinkedList<Type>::getFirst() const
{
    if(count == 0)
    {
        throw std::out_of_range("The list is empty");
    }
   Type ret;
   ret = front->data;
   return ret;
}

/**
 * @breif: Returns the data at the last position if the list is empty throws out_of_range
 * @tparam Type any data type that can use < > == << operators
 * @return the data that back is pointing to
 */
template <class Type>
Type OrderedLinkedList<Type>::getLast() const
{
    if(count == 0)
    {
        throw std::out_of_range("The list is empty");
    }

   Type ret;
   ret = back->data;
   return ret;
}

/**
 * @brief: Inserts the data in the order of least to greatest and adjust pointer accordingly
 * @tparam Type any data type that can use < > == << operators
 * @param item the data the user want to add
 */
template <class Type>
void OrderedLinkedList<Type>::insert(const Type& item)
{
    auto *temp = new Node<Type>;
    temp->data = item;
    auto currentNode = this->front;

    if(!front)
    {
        this->front = temp;
        this->back = temp;
        temp->next = nullptr;
        this->count++;
    }
    else
    {
        if(temp->data < front->data)
        {
            this->front = temp;
            temp->next = currentNode;
            this->count++;
            return;
        }
        else if(temp->data > back->data)
        {
            temp->next = nullptr;
            this->back->next = temp;
            this->back = temp;
            this->count++;
            return;
        }
        else
        {
            while(currentNode->next != nullptr)
            {
                if(temp->data > currentNode->data && temp->data < currentNode->next->data)
                {
                    temp->next = currentNode->next;
                    currentNode->next = temp;
                }

                currentNode = currentNode->next;
            }
            this->count++;
        }

    }
}

/**
 * @brief: Loops through the list and returns the position of data the user want to find
 * @tparam Type any data type that can use < > == << operators
 * @param item the data the user wants to find
 * @return and int: position of the item.  If its not in the list return -1
 */
template <class Type>
int OrderedLinkedList<Type>::find(const Type& item) const
{
    auto currentNode = this->front;
    for (int i = 0; i < this->count; ++i)
    {
        if(currentNode->data == item)
        {
            return i;
        }
        currentNode = currentNode->next;
    }

    return -1;
}

/**
 * @breif: Remove the item that gets passed in. If list is empty or if item is not in the list the function does
 * nothing.
 * @tparam Type any data type that can use < > == << operators
 * @param item the data the user wants to remove
 */
template <class Type>
void OrderedLinkedList<Type>::remove(const Type& item)
{
    if(front == nullptr)
    {
        ;
    }
    else
    {
        auto linkNode = this->front;
        auto deleteNode = this->front->next;

        for (int i = 0; i < count; ++i)
        {
            if(linkNode->data == item)
            {
                this->front = this->front->next;
                delete linkNode;
                this->count--;
                return;
            }
            else if(deleteNode->data == item)
            {
                if(deleteNode == back)
                {
                    linkNode->next = deleteNode->next;
                    back = linkNode;
                    delete deleteNode;
                    --count;
                    return;
                }
                else
                {
                    linkNode->next = deleteNode->next;
                    delete deleteNode;
                    --count;
                    return;
                }
            }
            linkNode = linkNode->next;
            deleteNode = deleteNode->next;
        }
    }

}

/**
 * @brief: Loops through the list deleting pointers and then sets front and back to nullptr
 * @tparam Type any data type that can use < > == << operators
 */
template <class Type>
void OrderedLinkedList<Type>::clear()
{
    Node<Type>* deleteNode;
    while(front != nullptr)
    {
        deleteNode = front;
        front = front->next;
        delete deleteNode;
        --count;
    }
    front = nullptr;
    back = nullptr;
}

/**
 * @brief: Loops through OrderLinkedList copying every odd number position into a new OrderLinkedList object
 * @tparam Type any data type that can use < > == << operators
 * @return the new OrderLinkedList
 */
template <class Type>
OrderedLinkedList<Type> OrderedLinkedList<Type>::everyOtherOdd()
{
    auto copyNode = this->front;
    OrderedLinkedList<Type> retVal;

    for (int i = 0; i < this->count; ++i)
    {
        if(i % 2 == 0)
        {
            retVal.insert(copyNode->data);
        }
        copyNode = copyNode->next;
    }
return retVal;
}

/**
 * @brief: Loops through OrderLinkedList copying every even number position into a new OrderLinkedList object
 * @tparam Type any data type that can use < > == << operators
 * @return the new OrderLinkedList
 */
template <class Type>
OrderedLinkedList<Type> OrderedLinkedList<Type>::everyOtherEven()
{
    auto copyNode = this->front;
    OrderedLinkedList<Type> retVal;

    for (int i = 0; i < this->count; ++i)
    {
        if(i % 2 != 0)
        {
            retVal.insert(copyNode->data);
        }
        copyNode = copyNode->next;
    }
    return retVal;
}

/**
 * @brief: Formats the data in the list as "1->2->3->..." to ostream
 * @tparam Type any data type that can use < > == << operators;
 * @param out Ostream: the ostream the output to
 * @param list OrderLinkedList object that the user wants to output the data from
 * @return formatted data
 */
template <class Type>
std::ostream& operator<<(std::ostream& out, const OrderedLinkedList<Type>& list)
{
    auto currentNode = list.front;
    for (int i = 0; i < list.count; ++i)
    {
        out << currentNode->data;
        if(currentNode->next)
        {
            out << "->";
        }
        currentNode = currentNode->next;
    }
    return out;
}
#endif
