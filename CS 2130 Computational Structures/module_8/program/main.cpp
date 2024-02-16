/**
 * Trevor Egbert
 * CS 2130
 * Program - Counting: Permutations and Combinations
 * Dr. Hunson
 * Due: 7/11/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * Figures out problems using permutations and combinations.
 */
#include <iostream>

/**
 * @brief Takes in integers passed in and performs permutation on them
 * @param n int: the amount of objects that can be pulled from in a
 * particular order
 * @param x int: the amount of objects to be pulled
 * @return long long: The number of ways those objects can be pulled
 */
long long permutations(int n, int x)
{
    // Sets up the answer variable
    long long answer = 1;

    // while x > 0
    while(x > 0)
    {
        // time the answer by n term and store it back in answer
        answer *= n;

        // decrements n and x by one
        --n;
        --x;
    }

    return answer;
}

/**
 * @brief Takes in integers passed in and performs combinations on them
 * @param n int: the amount of objects that can be pulled from ignoring the order
 * @param x int: the amount of objects to be pulled
 * @return long long: The number of ways those objects can be pulled
 */
long long combinations(int n, int x)
{
    // Sets variable to be used
    long long answer = 1;
    long long denominator = 1;

    // The number of time terms we go through backwards for n
    int iterator = x;

    // iterate > 0
    while(iterator > 0)
    {
        // time the answer by n term and store it back in answer
        answer *= n;
        // decrements n and iterator by one
        --n;
        --iterator;
    }

    // Loops through times the denominator by i
    for (int i = 1; i <= x; ++i)
    {
            denominator *= i;
    }

    // answer / denominator
    return (answer/denominator);
}

int main() {


    std::cout << "Check for correctness of functions:" << std::endl;

    std::cout << "permutation:   P(35, 12) = " << permutations(35, 12)
        << "  (should be 399703747322880000)" << std::endl;
    std::cout << "combinations:  C(12, 11) = " << combinations(23, 11)
        << "  (should be 1352078)"<< std::endl;

    std::cout << std::endl;

    // Question one

    // Part A
    std::cout << "Ways of selecting doctors for the first batch: "
        << combinations(12, 4) << std::endl;

    // Part B
    std::cout << "Ways of selecting nurses for the first batch: "
        << combinations(36, 12) << std::endl;

    // Part C
    std::cout << "Ways to administer the first dose: " <<
        (combinations(36, 12) * combinations(12, 4))<< std::endl;

    std::cout << std::endl;

    // Part D
    std::cout << "Ways of selecting doctors for the second batch: "
        << combinations(8, 4) << std::endl;

    std::cout << "Ways of selecting nurses for the second batch "
        << combinations(24, 12) << std::endl;

    // Part E
    std::cout << "Ways to administer the second dose: "
        << (combinations(8, 4)  * combinations(24, 12))<< std::endl;

    std::cout << std::endl;

    std::cout << "Total number of ways to administer all doses " << std::endl;
    std::cout << "Ways to administer the first does *  "
                 "Ways to administer the second dose" << std::endl;

    std::cout << std::endl;

    //Question 2
    // Part A
    std::cout << "The number of ways to distribute 4 bonuses to 23 people "
                 "if different is: " << permutations(23, 4) << std::endl;

    // Part B
    std::cout << "If the bonuses are the same, there are: "
        << combinations(23, 4) << std::endl;
    return 0;
}
