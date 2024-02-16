/**
 * Trevor Egbert
 * CS 2130 - 1:08 pm
 * Assigment: Program - Sequences and Summations: Find a specific Fibonacci
 * number and verify a summation
 * Dr. Hunson
 * Due: 6/20/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * A program that takes in numbers from the user and calculates
 * the Fibonacci number.  Then takes on another number and
 * sums them through add all of them together and using the formula
 */

#include <iostream>

/**
 * @brief Take in an int and does a recursive call to find Fibonacci number
 * @param n int: the number that the Fibonacci sequence will go to
 * @return long: the Fibonacci number
 */
long fib(int n)
{
    // if n < less than returns n
    if(n < 2)
    {
        return n;
    }
    else
    {
        return fib(n-1) + fib(n-2);
    }
}

/**
 * @brief Takes in an int and add up all the numbers from 1 to that number
 * @param n int: the number the user want to add up to
 * @return long: the total of all the numbers added together
 */
long sum(int n)
{
    long total = 0;

    // loops through the 1 and n adding everything to total
    for (int i = 1; i <= n; ++i)
    {
        total += i;
    }
    return total;
}

/**
 * @brief Takes in a number and use the sum formula to calculate to n
 * @param n int: The number the user wants to sum of
 * @return long: the sum from the sum formula
 */
long sumF(int n)
{
    int numerator  = n*(n+1);
    long total = (numerator /2);

    return total;
}
int main()
{
    // Sets up the variables to use for program
    int n1 = 0;
    int n2 = 0;

    // Asks for number to be used in fib() and stores it
    std::cout << "Please input a number to learn the corresponding "
                 "Fibonacci number:" << std::endl;
    std::cin >> n1;

    // Prints out
    std::cout << "Fibonacci number is: "<< fib(n1);

    // Pause so the next item can be entered
    std::cin.ignore();

    // Ask for a number used in sum() and sumF() and store it
    std::cout << "\nPlease input another number to learn if adding the numbers"
                 " up will get the same results as the sum formula:"
                 << std::endl;
    std::cin >> n2;

    // Checks to make sure the number is greater than one
    while(n2 < 1)
    {
        std::cout << "Please input a number greater the one" << std::endl;
        std::cin >> n2;
    }

    // Calls the sum(2n)
    std::cout << "The sum with counting by adding up all the numbers are: "
        << sum(n2) << std::endl;

    // Calls the sumF(2n)
    std::cout << "The sum with with using the sum formula is: "
        << sum(n2) << std::endl;

    // Let the user know the sum() and sumF() got the same result of not
    if(sum(n2) == sumF(n2))
    {
        std::cout << "The sum of all the numbers is equal to "
                     "for the sum formula" << std::endl;
    }
    else
    {
        std::cout << "The sum of all the numbers does not equal "
                     "sum formula" << std::endl;
    }

    return 0;
}
