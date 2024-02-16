/**
 * Trevor Egbert
 * CS 2130
 * Program - Number Theory: Identifying Primes and Euclid's GCD
 * Dr. Hunson
 * Due: 7/9/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * This program takes in two integers and does three things
 * First finds if they are are prime of not
 * Second uses Euclid's Algorithm to find the GCD
 * Third it uses formula to find the LCM of the Integers
 */
#include <iostream>


/**
 * @brief Takes in a number and prints out if its prime or not
 * @param num int: the int user wants to check if its prime or not
 */
void isPrime(int num)
{
    bool prime = true;


    // figure out if prime
    for (int i = 2; i*i < num; ++i)
    {
        // If k mod i = 0
        while(num % i == 0)
        {
            // Sets prime to false and breaks from the loop
            prime = false;
            break;
        }
    }

    // Prints out if num is prime or not
    if(prime)
    {
        std::cout << num << " is a prime number." << std::endl;
    }
    else
    {
        std::cout << num << " is not a prime number." << std::endl;
    }

}

/**
 * @brief: Takes in two integers and uses Euclidean Algorithm to find the GCD
 * @param n1 int: one of the integer the user want to find the GCD for
 * @param n2 int: the other integer the user want to find the GCD for
 * @return GCD int: The GDC of the two integers
 */
int eucAlg(int n1, int n2)
{
    // Set up variables used in calculations
    int x = n1;
    int y = n2;
    int r = 0;

    if(y != 0)
    {
        r = x % y;
        x = y;
        y = r;
        // Calls eucAlg on the updated x and y values
        return(eucAlg(x, y));
    }

    // Returns the GDC
    return x;
}

/**
 * @brief Calculates the LCM of the two integers
 * @param n1 int: One of the integer the user wants to find the LCM for
 * @param n2 int: The other integer the user wants to find the LCM for
 * @param gdc int: The GDC of the two numbers used in calculations
 * @return int LCM: returns the LCM of n1 and n2
 */
int lcm(int n1, int n2, int gdc)
{
    // returns (n1 * n2) / gdc = lcm
    return ((n1*n2)/gdc);
}

int main()
{

    int n1 = 0;
    int n2 = 0;
    int gdc = 0;


    std::cout << "This program reads in two integers and determines if they "
                 "are \nprime. It then computes the greatest common "
                 "divisor of the \ntwo integers using Euclid's Algorithm."
                 << std::endl;

    // Ask user to enter two integer and check if they are positive
    std::cout << "Enter the first integer: " << std::endl;
    std::cin >> n1;
    while(n1 < 1)
    {
        std::cout << "Please enter a integer greater than 1" << std::endl;
        std::cin >> n1;
    }
    std::cin.ignore();
    std::cout << "Enter the second integer:  "<< std::endl;
    std::cin >> n2;
    while(n2 < 1)
    {
        std::cout << "Please enter a integer greater than 1" << std::endl;
        std::cin >> n2;
    }

    std::cout << "Results:" << std::endl;

    // Calls is prime on n1 and n2
    isPrime(n1);
    isPrime(n2);

    // Calls eucAlg(n1, n2) and save results in gdc and prints the results
    gdc = eucAlg(n1, n2);
    std::cout << "The gcd(" << n1 << ", " << n2 << ") is "
        << gdc << "." << std::endl;

    // Calls lcm(n1, n2, gdc) and save results and prints the results
    std::cout << "The lcm(" << n1 << ", " << n2 << ") is "
        << lcm(n1, n2, gdc) << "." << std::endl;

    return 0;
}
