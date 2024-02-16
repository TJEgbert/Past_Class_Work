/*
 * Trevor Egbert
 * CS 2130 - 8:45 am
 * Assigment: Program - Manipulating Bits: Sets and Set Operations
 * Dr. Hunson
 * Due: 6/6/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * This program takes in two set and some set operation on them
 */

#include <iostream>

/*
 * Takes in a set and prints them out in the format {0,1,2}
 */
void printSet(int set)
{
    int size = 0;
    // Loops through the int to get the number of bits is set to 1
    for (int i = 0; i < 10; ++i)
    {
        if((set >> i & 1) == 1)
        {
            size++;
        }

    }

    int j = 0;
    std::cout << "{";
    // Loops through the int
    for (int i = 0; i < 10; ++i)
    {
        // Checks to see if the bit is set to 1
        if((set >> i & 1) == 1)
        {
            // Makes sure the "," gets put in the right places
            if(j > 0)
            {

                std::cout << "," << i;
                j++;
            }
            else
            {
                std::cout << i;
                j++;
            }
        }
    }
    std::cout << "}" << std::endl;

}

/*
 * Loops through the int to check if any bit is set to zero
 * if so it set the same bit in tempSet.
 * Then it calls printSet on tempSet
 */
void complement(int set)
{
    std::cout << "The complement of the set is" << std::endl;
    int tempSet = 0;
    for (int i = 0; i < 10; ++i)
    {
        if((set >> i & 1) == 0)
        {
            tempSet |= (1 << i);
        }
    }
    printSet(tempSet);
}

/*
 * Does an OR operation on setA and setB and saves it in tempSet
 * Then it calls printSet on tempSet
 */
void setUnion(int setA, int setB)
{
    int tempSet = (setA | setB);

    std::cout << "Union of A and B is" << std::endl;
    printSet(tempSet);

}

/*
 * Does an AND operation on setA and setB and saves it in tempSet
 * Then it calls printSet on tempSet
 */
void intersection(int setA, int setB)
{
    int tempSet = (setA & setB);
    std::cout << "The intersection of A and B is" << std::endl;
    printSet(tempSet);
}

/*
 * Checks to see if setA bit is set to 1 and if setB bit is set to 0
 * If so it sets the same bit to 1 in tempSet
 * Then it calls printSet on tempSet
 */
void difference(int setA, int setB)
{
    int tempSet = 0;
    for (int i = 0; i < 10; ++i)
    {
        if((setA >> i & 1) == 1 && (setB >> i & 1) == 0)
        {
            tempSet |= (1 << i);
        }
    }
    std::cout << "The difference of A and B is" << std::endl;
    printSet(tempSet);
}

/*
 * Checks to see if either setA or setB contains a bit set to 1
 * while the other is set to 0
 * If so that bit is set to 1 in the tempSet
 * Then it calls printSet on tempSet
 */
void symmetricDifference(int setA, int setB)
{
    int tempSet = 0;
    for (int i = 0; i < 10; ++i)
    {
        if(((setA >> i & 1) == 1 && (setB >> i & 1) == 0)
            || ((setA >> i & 1) == 0 && (setB >> i & 1) == 1))
        {
            tempSet |= (1 << i);
        }
    }

    std::cout << "The symmetric difference of A and B is" << std::endl;
    printSet(tempSet);
}


int main() {

    // Setting up variables to use to set and set size
    int setA = 0;
    int setB = 0;

    int setASize = 0;
    int setBSize = 0;

    std::cout << "Please enter in values from 0 to 9 of two sets and the program "
                 "will display several \nresults from some set "
                 "operation on those set."<< std::endl;

    // Ask the user for the size of set A
    std::cout << "A set can contain 0 to 10 elements how many elements "
                 "for set A" << std::endl;

    std::cin >> setASize;

    // Checks to see if the value is within 0 and 10 if not prompts user
    // to enter in a new value
    while(setASize > 10 || setASize < 0)
    {
        std::cout << "Please enter size between 0 to 10"<< std::endl;
        std::cin >> setASize;
    }

    int value;
    int i = 0;

    // Asks the user to enter numbers for the set
    while(i < setASize)
    {
        std::cout << "Please enter element " << i+1 << std::endl;
        std::cin >> value;

        // Checks to see if the value is between 0 and 10
        if(value < 10 && value >= 0)
        {
            // If so it sets that bit to 1
            setA |= (1 << value);
            i++;

        }
        else
        {
            // If not asks users to please enter a new number.
            std::cout << "Please enter a value between 0 and 9" << std::endl;
        }
    }

    // Ask the user for the size of set B
    std::cout << "A set can contain 0 to 10 elements how many elements "
                 "for set B" << std::endl;

    std::cin >> setBSize;

    // Checks to see if the value is within 0 and 10 if not prompts user
    // to enter in a new value
    while(setASize > 10 || setASize < 0)
    {
        std::cout << "Please enter size between 0 to 10"<< std::endl;
        std::cin >> setBSize;
    }

    i = 0;

    // Asks the user to enter numbers for the set
    while(i < setBSize)
    {
        std::cout << "Please enter element " << i+1 << std::endl;
        std::cin >> value;
        // Checks to see if the value is between 0 and 10
        if(value < 10 && value >= 0)
        {

            // If so it sets that bit to 1
            setB |= (1 << value);
            i++;

        }
        else
        {
            // If not asks users to please enter a new number.
            std::cout << "Please enter a value between 0 and 9" << std::endl;
        }
    }

    // Prints out set A and its complement
    std::cout << "Set A" << std::endl;
    printSet(setA);
    complement(setA);
    std::cout << std::endl;

    // Prints out set A and its complement
    std::cout << "Set B" << std::endl;
    printSet(setB);
    complement(setB);
    std::cout << std::endl;

    // Uses the functions to do set operations
    setUnion(setA, setB);
    std::cout << std::endl;

    intersection(setA, setB);
    std::cout << std::endl;

    difference(setA, setB);
    std::cout << std::endl;

    symmetricDifference(setA, setB);

    return 0;
}
