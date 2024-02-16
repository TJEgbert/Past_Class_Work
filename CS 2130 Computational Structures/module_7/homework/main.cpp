/**
 * Trevor Egbert
 * 07 - Homework - Algorithm to Code
 * File: main.cpp
 * A program that let the user continually choose integers to factorization on
 */
#include <iostream>

int main()
{
    // Setting up variables to use for the loops
    bool exit = false;
    char answer = 'a';
    int num = 0;
    int k = 0;

    while(!exit)
    {
        // Ask the user for an int and stores it in num
        std::cout << "Please enter an integer to determine the "
                     "prime factorization of: " << std::endl;
        std::cin >> num;

        // Checks to see if the num is less than two if so prints error message
        if(num < 2)
        {
            std::cout<< "Error please enter a number greater than 1."
                << std::endl;
        }
        else
        {
            std::cout << "The prime factorization of " << num
                << " is: " << std::endl;

            // Sets k to num and does the factorization of the integer
            k = num;
            for (int i = 2; i*i <= num; ++i)
            {
                // If the remainder from the division is 0
                while(k % i == 0)
                {
                    // It prints the integer and updates k = k/i
                    std::cout << i << ", ";
                    k = (k/i);
                }
            }
            // if k is greater than one it prints out the remainder
            if(k > 1)
            {
                std::cout << k;
            }
        }

        // Checks to see if the user wants to factorization another integer
        std::cout << "\nWould you like to factor another prime? "
                     "(N for no, anything else is yes)" << std::endl;
        std::cin >> answer;
        if(std::tolower(answer) == 'n')
        {
            std::cout << "Have a nice day!" << std::endl;
            exit = true;
        }
    }
}
