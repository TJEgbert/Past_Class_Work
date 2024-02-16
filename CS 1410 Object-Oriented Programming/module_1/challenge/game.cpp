#include <iostream>
#include <ctime>
#include <cstdlib>
#include "game.h"
using namespace std;


/**
 * @brief Display the Rock, Paper, Scissors game menu
 *
 */
void GameMenu()
{
    cout << "--------------------------------------" << endl;
    cout << "-- Lets play Rock, Paper, Scissors! --" << endl;
    cout << "--------------------------------------" << endl;
    cout << "Press 1 for Rock, 2 for Paper, 3 for Scissors:" << endl;

}

/**
 * @brief Generate a random number between 1 and 3
 *
 * @return int: random number
 */
int AiChoice()
{
    //gets a random number between 1 and 3
    srand (time(NULL));  // sed random seed
    int ai = rand() % 3 + 1;
    // Display random computer choice
    cout << "The computer selects: " << ai << endl;\
    return ai;  // return value

}
/**
 * @breaf Logic for Rock, Paper, Scissors game
 *
 * @param player: player 1 choice
 * @param computer: player two choice
 */
void RockPaperScissors(int player, int computer)
{
    // If player choices 1
    if (player == 1)
    {
        // Switch statement checks against what the computer choose and prints winning/ losing/ tying message
        switch (computer)
        {
            case 1:
                cout << "Rock meets Rock its a tie!" << endl;
                break;
            case 2:
                cout << "Rock is covered by Paper the computer wins!" << endl;
                break;
            case 3:
                cout << "Rock crushes Scissors you win!" << endl;
                break;

        }
    }
    // Else if player choices 2
    else if (player == 2)
    {
        // Switch statement checks against what the computer chooses and prints winning/ losing/ tying message
        switch (computer)
        {
            case 1:
                cout << "Paper covers Rock you win!" << endl;
                break;
            case 2:
                cout << "Paper meets Paper its a tie!" << endl;
                break;
            case 3:
                cout << "Paper is cut by Scissors the computer wins!" << endl;
                break;
        }
    }
    // Else if player choices 3
    else if (player == 3)
        // Switch statement checks against what the computer chooses and prints winning/ losing/ tying message
        switch (computer)
        {
            case 1:
                cout << "Scissors are crushed by Rock computer wins!" << endl;
                break;
            case 2:
                cout << "Scissors cuts Paper you win!" << endl;
                break;
            case 3:
                cout << "Scissors meet Scissors its a tie!" << endl;
                break;
        }
    else
    {
        cout << "You didn't select 1, 2, or 3" << endl;
    }
}