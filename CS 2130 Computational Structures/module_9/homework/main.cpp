/**
 * Trevor Egbert
 * 09 - Homework - Recursion vs. Iteration
 * File: main.cpp
 * A program the calculates the Fibonacci number to see the difference in
 * time between recursive function and iterative function.
 */
#include <iostream>

/**
 * @brief Calculate the Fibonacci number of N using recursion
 * @param n int: The number the user go to for the Fibonacci number
 * @return int: the Fibonacci number
 */
int fibo(int n)
{
    if(n < 2)
    {
        return n;
    }

    // Calls itself twice fibo(n-1) and fibo(n-2) and adds them together
    return (fibo(n-1) + fibo(n-2));

}

/**
 * @brief Calculate the Fibonacci number of N using iteration
 * @param n int: The number the user go to for the Fibonacci number
 * @return int: the Fibonacci number
 */
int iterfib(int n)
{
    int fib = 0;
    int n2 = 0;
    int n1 = 1;
    if(n < 2)
    {
        return n;
    }
    // Loops through adding the numbers together for the Fibonacci number
    for (int i = 2; i <= n ; ++i)
    {
        fib = n1 + n2;
        n2 = n1;
        n1 = fib;
    }
    return fib;
}

int main() {

    // Variables used ein the program
    int num = 0;

    // Asks for an int and store it in num
    std::cout << "Please enter a value to determine the Fibonacci "
                 "sequence element for: " << std::endl;
    std::cin >> num;

    // Calls fibo(num) and prints the results
    std::cout << "The recursively determined result is: " << fibo(num)
        << std::endl;

    // Calls iterfib(num) and prints the results
    std::cout << "The iterative value is: " << iterfib(num) << std::endl;

    return 0;
}
