/**
 * Trevor Egbert
 * CS 2130
 * Program - Finite State Machines: Cryptoquotes
 * Dr. Hunson
 * Due: 8/4/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * Takes in a key from the user and let them enter in in strings to encrypt for
 * cryptoquotes and decrypts them
 */
#include <iostream>

/**
 * @brief Takes an array of chars and prints them out
 * @param array: The array to be printed
 */
void printCharArray(char array[])
{
    for (int i = 0; i < 26; ++i)
    {
        std::cout << array[i] << " ";
    }
    std::cout << std::endl;
}

int main() {

    // Sets up variables to be used in the program
    bool active = true; // Used to keep the script looping
    std::string str = "";
    char alphabet[26] = {'A', 'B', 'C', 'D', 'E','F', 'G', 'H', 'I', 'J',
                         'K', 'L', 'M', 'N', 'O', 'P','Q', 'R', 'S', 'T', 'U',
                         'V', 'W', 'X', 'Y', 'Z'};

    char key[26];

    while(active)
    {
        std::cout << "Please choose from the fowling options: " << std::endl;
        std::cout << "      1 - Enter a key" << std::endl;
        std::cout << "      2 - Display a key" << std::endl;
        std::cout << "      3 - Encode a quot" << std::endl;
        std::cout << "      4 - Decode a Cryptoquote" << std::endl;
        std::cout << "      5 - Exit program" << std::endl;
        std::cout << "      Choice? ";

        // Sets up variables to use in the loop
        int choice = 0;
        std::string choice_char;
        int key_index = 0;
        char temp;
        bool unique26 = false;

        // Saves the users choice in choice
        std::cin >> choice_char;
        // Checks to make sure its number
        while(!std::isdigit(choice_char[0]))
        {
            std::cout << "Please enter one of the numbers for the available "
                         "options"<< std::endl;
            std::cin >> choice_char;
        }
        // choice = the int version of the string number
        choice = std::stoi(choice_char);
        std::cin.ignore();

        // Depending on that the user entered for choice
        switch(choice)
        {
            case 1: // if 1
                while(!unique26)
                {
                    // asks for a string of 26 unique characters
                    std::cout << "Please enter the key.\nCharacters will read until"
                                 " 26 unique characters are entered."
                                 "\nFor example:" << std::endl;
                    std::cout << "mmnnb65247bvvcxzlkjhgfdsapoiuy6trewq" << std::endl;
                    std::cout << "would be accepted as the key: MNBVCXZLKJHGFDSAPOIUYTREWQ" << std::endl;
                    std::cout << "Please enter a string of characters:" << std::endl;

                    // Stores user string in str
                    std::getline(std::cin, str);

                    // For all the chars in str
                    for (char i : str)
                    {
                        // stores str[i] an uppercase
                        temp = toupper(i);

                        // temp >= ascii value of A and <= ascii value of Z
                        if(temp >= 'A' && temp <= 'Z')
                        {
                            // loops through key[]
                            for (int j = 0; j <= key_index; ++j)
                            {
                                // checks if temp is already in key[]
                                if(key[j] == temp)
                                {
                                    break;
                                }
                                // if j == key_index
                                if(j == key_index)
                                {
                                    // Adds temp to the end of the key[]
                                    key[key_index] = temp;
                                    key_index++;
                                    break;
                                }
                            }
                        }
                    }
                    // if there are a total of 26 unique characters
                    if(key_index == 26)
                    {
                        // Breaks out of the loop
                        unique26 = true;
                    }
                }

                break;

            case 2: // if 2

                // Uses print array to print the two arrays
                std::cout << "They key value is:" << std::endl;
                printCharArray(alphabet);
                printCharArray(key);

                break;

            case 3: // if 3
                std::cout << "Please enter the string to create the Cryptoquote from as one line of text." << std::endl;
                // Stores the string the user want to encrypt
                std::getline(std::cin, str);

                std::cout << "The resulting string is:" << std::endl;

                // Loops through all the characters in str
                for (char i : str)
                {
                    // temp = str[i] in uppercase
                    temp = toupper(i);

                    // Checks if temps a letter
                    if(temp >= 'A' && temp <= 'Z')
                    {
                        // loops through alphabet looking for the letter
                        for (int j = 0; j < 26; ++j)
                        {
                            // Once found
                            if(temp == alphabet[j])
                            {
                                // key_index = the index of the letter
                                key_index = j;
                            }
                        }
                        // prints out the encrypted letter
                        std::cout << key[key_index];
                    }
                    else
                    {
                        // prints out anything that's not a letter
                        std::cout << i;
                    }
                }

                std::cout << std::endl;

                break;

            case 4: // if 4
                std::cout << "Please enter the Cryptoquote string to decode as one line of text:" << std::endl;
                // Stores the string the user want to decrypt
                std::getline(std::cin, str);

                std::cout << "The resulting string is:" << std::endl;

                // Loops through all the characters in str
                for (char i : str)
                {
                    //temp = str[i] in uppercase
                    temp = toupper(i);

                    // Checks if temps a letter
                    if(temp >= 'A' && temp <= 'Z')
                    {
                        // loops through key looking for the letter
                        for (int j = 0; j < 26; ++j)
                        {
                            // Once found
                            if(temp == key[j])
                            {
                                // key_index = the index of the letter
                                key_index = j;
                            }
                        }
                        // prints out the decrypted letter
                        std::cout << alphabet[key_index];
                    }
                    else
                    {
                        // prints out anything that's not a letter
                        std::cout << i;
                    }
                }

                std::cout << std::endl;

                break;

            case 5: // if 5
                // Active = false to end the loop and end the program
                active = false;
                std::cout << "Hope you solved your Cryptoquote!";
                break;

            default: // if not one of those

                std::cout << "Please pick a number between 1 and 5\n";
                break;
        }
    }

    return 0;
}
