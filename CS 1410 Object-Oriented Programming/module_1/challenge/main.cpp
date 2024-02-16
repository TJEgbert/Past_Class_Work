/*
 * Challenge: Rock, Paper, Scissors
 * Trevor Egbert
 * 5-14-2022
 * A single player rock, paper, scissors against a computer opponent
 */

#include <iostream>
#include "game.h"
using namespace std;

int main()
{
    // Set the char variable for the y/n while loop/
    char ch= 'Y';
    int games = 0;
    // Task 1.2 start of game loop, the loop will run until ch != 'Y' or 'y'
    while (ch == 'Y' || ch =='y')
    {
        int choice;
        // Task 1: Call Menu Function
        GameMenu();
        cin >> choice;// capture inout

        // Part 2: Get AI choice
        int ai = AiChoice();

        // Part 3: Call game logic
        RockPaperScissors(choice, ai);

        // Repeat process
        cout << "Would you like to play again? Y/N" << endl;
        // No validation on input is required at this point.  We will assume the user
        // Uses only Y/y for true, anything else is false
        cin >> ch;
        games++;
        if (games >= 3)
        {
            cout << "You played " << games << ". Thank you for playing." << endl;
            break;
        }
    }
    return 0;
}