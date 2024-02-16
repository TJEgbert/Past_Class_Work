/**
 * Trevor Egbert
 * CS 2130
 * Program - Discrete Probability: Working with large and small populations
 * Dr. Hunson
 * Due: 7/18/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * Figures out probability of a couple of scenarios
 */
#include <iostream>
#include <cmath>

/**
 * @brief Takes in long long passed in and performs permutation on them
 * @param n long long: the amount of objects that can be pulled from in a
 * particular order
 * @param x long long: the amount of objects to be pulled
 * @return long long: The number of ways those objects can be pulled
 */
long long permutations(long long n, long long x)
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
 * @brief Takes in long long passed in and performs combinations on them
 * @param long long: the amount of objects that can be pulled from ignoring the
 * order
 * @param long long: the amount of objects to be pulled
 * @return long long: The number of ways those objects can be pulled
 */
long long combinations(long long n, long long x)
{
    // Sets variable to be used
    long long answer = 1;
    long long denominator = 1;

    // The number of time terms we go through backwards for n
    long long iterator = x;

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

/**
 * @brief It calculates the binomial distribution of the given variables
 * @param N long long: The number of independent trails
 * @param K long long: The number of success from the independent
 * @param P double: the probability of success in each trail
 * @return double: the binomial distribution of the given variables
 */
double Binomial(long long N, long long K, double P)
{
    // C(N, K) * P^K * (1 -P)^(N - k)
    return combinations(N, K) * pow(P, K) * pow((1 - P), (N - K));
}

int main() {


    // Test Value
    std::cout << "Test value binomial(20, 2, 0.08): " <<
                Binomial(20, 2, 0.08) << std::endl;

    std::cout << std::endl;

    // Question 1
    std::cout << "60 cars at a dealer, 3 dead batteries.  If we check 10, what"
                 " is\nthe probability no more than 1 will have a dead battery?"
                 << std::endl;

    // Question 1 answer
    std::cout << "Probability is: " << (Binomial(10, 1, 0.05)
                + Binomial(10, 0, 0.05))  << std::endl;

    std::cout << std::endl;

    // Question 2
    std::cout << "Auto recall: 8% have defect.  If we test 20, what is "
                 "probability\nthat at most 2 will have the defect"
                 << std::endl;

    // Question 2 answer
    std::cout << "Probability is: " << (Binomial(20, 2, 0.08) +
                Binomial(20, 1, 0.08) + Binomial(20, 0, 0.08)) << std::endl;

    return 0;
}
