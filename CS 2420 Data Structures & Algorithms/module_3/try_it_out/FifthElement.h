//
// Created by Trevor on 10/10/2022.
//

#ifndef LINKED_LIST_FIFTHELEMENT_H
#define LINKED_LIST_FIFTHELEMENT_H
#include <iostream>
#include "LinkedList.h"

template<typename Type>
class FifthElement : public LinkedList<Type>
{

public:

    Type getFifthElement();
    void insertNewFifthElement(const Type &value);
    void deleteFifthElement();
    void swapFourthAndFifthElement();

};

template<typename Type>
Type FifthElement<Type>::getFifthElement()
{
    if(this->count < 5)
    {
        throw std::length_error("There is no fifth element");
    }

    return LinkedList<Type>::peek(4);
}

template<typename Type>
void FifthElement<Type>::insertNewFifthElement(const Type &value)
{
    int count = 0;
    auto currentNode = this->front;
    auto tempNode = new Node<Type>;
    tempNode->data = value;

    if(this->count == 4)
    {
        this->back->next = tempNode;
        tempNode->next = nullptr;
        this->back = tempNode;
    }
    while(currentNode->next != nullptr)
    {
        ++count;
        currentNode = currentNode->next;

        if(count == 3)
        {
            tempNode->next = currentNode->next;
            currentNode->next = tempNode;
        }
    }
    this->count++;
}

template<typename Type>
void FifthElement<Type>::deleteFifthElement()
{
    this->remove(4);
}

template<typename Type>
void FifthElement<Type>::swapFourthAndFifthElement()
{
    int curNoNum = 0;
    auto currentNode = this->front;
    auto pointerFourth = new Node<Type>;
    auto pointerFifth = new Node<Type>;

    if(this->count < 5)
    {
        throw std::length_error("There is no fifth element");
    }
    else
    {
        while(currentNode->next != nullptr)
        {
            curNoNum++;
            currentNode = currentNode->next;
            if(curNoNum == 2)
            {
                pointerFourth->next = currentNode->next;
                pointerFifth->next = currentNode->next->next;
                currentNode->next->next = currentNode->next->next->next;
                currentNode->next = pointerFifth->next;
                currentNode->next->next = pointerFourth->next;

                break;
            }
        }
    }

}

#endif //LINKED_LIST_FIFTHELEMENT_H
