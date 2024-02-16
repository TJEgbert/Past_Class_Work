/**
 * Trevor Egbert
 * 10 - Homework - Using characters to index arrays
 * File: main.cpp
 * A program that counts how many times a letter is used in a string
 */

#include <iostream>
#include <iomanip>


using namespace std;

void outputCount(int counts[])
// function to output character counts
{
    char i; // loop control variable

    cout << "------------- The number of occurrences for each letter: --------------\n";
    for (i = 'A'; i <= 'Z' ; ++i)
    {
        cout << setw(2) << i << " - " << setw(3) << counts[ i-'A'] << "  ";
        if ((i - 64) % 8 == 0)
        {
            cout << endl;
        }
    }
}

void countChars(int counts[], string inStr)
// function to count the number of occurences of alphabetic characters in a string
{
    for (const char &c : inStr) // for all characters in the string
    {
        if (isalpha(c))
        {
            counts[toupper(c)-'A']++;  // increment the count
        }
    }
}


int main(int argc, char *argv[])
{
    string theInput = "";
    int charCount[26] = {0};

    do
    {
        cout << "\nPlease enter a string, press return to stop: ";
        getline(cin, theInput); // input an entire line of text
        countChars(charCount, theInput); // use the function to count characters

    } while(theInput.length() >0); // if the entered string had no characters exit
    cout << endl;
    outputCount(charCount); // output the character count
    cout << endl << endl;


    return 0;
}
