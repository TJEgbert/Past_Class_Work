/*
 * Trevor Egbert
 * Homework 5
 * File: main.cpp
 * The program does two things
 * First it takes in two ints from the user and add all the value in-between
 * Second it takes in a string from the user and reverses and prints it
 */
#include <iostream>


/*
 * Takes in two int values and adds all the number in-between
 * It does this by recursively calling itself
 */
int sumRange(int val1, int val2)
{
    // If Val1 == Val2
    if(val1 == val2)
    {
        return val1;
    }
    else
    {
        // Switches the numbers of Val1 and Val2 if Val1 is smaller
        if(val1 < val2)
        {
            int tempInt = val1;
            val1 = val2;
            val2 = tempInt;
        }
    }
    // Does recursive all decrementing val1 by 1
    return val1 + sumRange(val1-1, val2);
}

/*
 * Takes in a string and by recursively prints the string backwards
 */
void printRevString(std::string theString, int position)
{
    // If the position is not at the end of the string
    if(theString[position] != '\0')
    {
        // Calls itself with an increment position by 1
        printRevString(theString, position+1);
        // prints the current character at theString[position]
        std::cout << theString[position];
    }

}

int main()
{
    // Variables need for program
    int val1 = 0;
    int val2 = 0;
    std::string rString;

    // Ask user for number and stores them
    std::cout << "Please enter your range of integers (on one or more lines)"
                    << std::endl;
    std::cin >> val1;
    std::cin >> val2;

    // Outputs the sum using sumRange
    std::cout << "The sum of all the integers from " << val1 << " to " << val2
                << " is " << sumRange(val1, val2) << std::endl;


    // Stops the program for ending
    std::cin.ignore();

    // Asks user for string and stores it
    std::cout << "Please enter a string" << std::endl;
    std::getline(std::cin, rString);

    // Output the reversed string using printRevString
    std::cout << "The reverse of your input is:" << std::endl;
    printRevString(rString, 0);


    return 0;
}
