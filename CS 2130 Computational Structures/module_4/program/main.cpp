/*
 * Trevor Egbert
 * CS 2130 - 11:16 am
 * Assigment: Program - Functions: Identifying Properties
 * Dr. Hunson
 * Due: 6/12/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * A program that tells you about a function from the order pairs
 * the user inputs.
 */

#include <iostream>
#include <string>
#include <cmath>


int main() {

    // Variables to store user input
    int size = 0;
    std::string pair;

    // Asks and stores the number of pairs the user wants
    std::cout << "How many order pairs?" << std::endl;
    std::cin >> size;
    std::cin.ignore();

    // Sets up arrays to store x and y values
    int x[size];
    int y[size];

    // Used to store x and y values from strings
    std::string temp;

    std::cout << "Please enter in order pairs" << std::endl;

    // Loops through taking inputs from the user
    for (int i = 0; i < size; ++i)
    {
        // Store the input into the string extracts the number into x[i]
        std::getline(std::cin, pair);
        for (int j = 0; j < pair.size(); ++j)
        {
            // Store the next character of '(' into temp
            if(pair[j] == '(')
            {
                temp = pair[j+1];
                x[i] = std::stoi(temp);
            }
            // If there's a = it will take the last character stores it
            // into temp and extracts the number into y[i]
            if(pair[j] == '=')
            {
                temp = pair[pair.size() - 1];
                y[i] = std::stoi(temp);
            }
        }
    }

    std::cout << "Function described by:" << std::endl;
    // Out puts the pairs in format f(x) = y
    for (int i = 0; i < size; ++i)
    {
        std::cout << "f(" << x[i] << ") = " << y[i] << std::endl;
    }

    // Booleans for printing later
    bool valid = true;
    bool one_to_one = true;
    bool onto = true;
    bool bijection = false;

    // Checks the see if there is a valid domain if not it ends the program
    if(std::abs((x[size-1] - x[size-2])) > size)
    {
        std::cout << "This function is not a valid function.";
    }
    else // if the domain is valid
    {
        for (int i = 0; i < size; ++i)
        {
            // Checks for repeating x values
            for (int j = i+1; j < size; ++j)
            {
                if(x[i] == x[j])
                {
                    // if so it sets valid to false
                    valid = false;
                }
                //Checks for repeating y values
                if(y[i] == y[j])
                {
                    // if so sets one to one and onto to false
                    one_to_one = false;
                    onto = false;
                }
            }

        }
        //Checks the size of the domain against the last x value
        if(size != x[size-1])
        {
            // if not equal sets onto to false
             onto = false;
        }
        // Checks to see if one_to_one and onto are true
        if(one_to_one && onto)
        {
            // if so sets bijection to true
            bijection = true;
        }
        // if the function is not valid
        if(!valid)
        {
            std::cout << "This function is not a valid function.";
        }
        else
        {
            // If valid it prints out the corresponding message if the values
            // are true of false
            std::cout << "This function is a valid function." << std::endl;

            if(one_to_one)
            {
                std::cout << "This function is a one-to-one function."
                        << std::endl;
            }
            else
            {
                std::cout << "This function is not a one-to-one function."
                        << std::endl;
            }

            if(onto)
            {
                std::cout << "This function is onto." << std::endl;
            }
            else
            {
                std::cout << "This function is not onto." << std::endl;
            }

            if(bijection)
            {
                std::cout << "This function is bijection." << std::endl;
            }
            else
            {
                std::cout << "This function is not a bijection." << std::endl;
            }

        }
    }

    return 0;
}
