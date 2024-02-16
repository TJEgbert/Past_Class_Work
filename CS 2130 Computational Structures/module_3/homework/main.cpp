// Trevor Egbert
// Homework 3
// File: main.cpp
// A script that will print out the bit representation of a number
#include <iostream>

// Take in an int and loops through checking if the bit
// is a 0 or 1 and print out accordingly
void printBinary(int theValue)
{
    for (int i = 31; i >=0 ; --i)
    {
        if((theValue >> i & 1) > 0) //checking if the bit is 1 at i
        {
            std::cout << "1 ";
        }
        else // if the bit is 0 at i
        {
            std::cout << "0 ";
        }
    }
    std::cout << std::endl;
}

int main() {

    int number; // an int to hold the user input

    std::cout << "Enter an integer to see "
                 "what its bit representation is:" << std::endl;

    std::cin >> number; // user input saved in number

    printBinary(number);

    return 0;
}
