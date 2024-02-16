/*
 * Trevor Egbert
 * Homework 4
 * File: main.cpp
 * A script that with two functions...
 * First: Takes a list of the number the user wants to sort and prints them
 * Second: Takes a word or phrase the user wants to no the letter count for
 * and prints them
 */
#include <iostream>
#include <string>
#include <algorithm>


int main()
{
    int size;  // int to store the amount of numbers the user want to count

    std::cout << "How many numbers would you like sorted?" << std::endl;
    std::cin >> size;

    int numArray[size]; // Creates an array of size for the numbers
    int temp;
    std::cout << "Please enter the numbers to sort." << std::endl;

    // Loops through the size of the array inputting numbers
    for (int i = 0; i < size; ++i)
    {
        std::cin >> temp;
        numArray[i]= temp;
    }

    // Uses bubble sort to but the number in orders
    bool didSwap;
    for (int i = 0; i < (size-1); ++i)
    {
        didSwap = false;
        for (int j = 0; j < (size-i-1); ++j)
        {
            if(numArray[j] > numArray[j+1])
            {
                temp = numArray[j];
                numArray[j] = numArray[j+1];
                numArray[j+1] = temp;
                didSwap = true;
            }
        }
        if(!didSwap)
        {
            break;
        }
    }

    // Prints the order numbers out to the user
    for (int i = 0; i < size; ++i)
    {
        std::cout << numArray[i] << " ";
    }

    std::cout << std::endl;

    // sets up the array to keep track of the count of the letters
    int letterCount[26];

    //sets all element in the array to zero
    for (int i = 0; i < 26; ++i)
    {
        letterCount[i] = 0;
    }

    // Sets up an array of the alphabet
    std::string alphabet[26] = {"A", "B", "C","D","E","F","G","H","I",
                                "J","K","L","M","N","O","P","Q",
                                "R","S","T","U","V","W","X","Y","Z"};

    std::string inputString; // Store the user input

    std::cout << "Please input a word or phrase you would like to know the "
                 "letters for" << std::endl;
    std::getline(std::cin,inputString);

    // Counts the amount of each letter in word or phrase
    for (int i = 0; i < inputString.size(); ++i)
    {
        if(std::isalpha(inputString[i]))
        {
            letterCount[toupper(inputString[i])- 'A']++;
        }
    }

    // Prints out the alphabet
    for (int i = 0; i < 26; ++i)
    {
        std::cout << alphabet[i] << " ";
    }
    std::cout << std::endl;

    // Prints out how many of each letter is used in work or phrase
    for (int i = 0; i < 26; ++i)
    {
        std::cout << letterCount[i] << " ";
    }

    return 0;
}
