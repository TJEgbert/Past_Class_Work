/**
 * Challenge Directories
 * Trevor Egbert
 * 6/4/2022
 * Imports txt files and formats the information and exports it to a new txt file
 */

#include <iostream>
#include <string>
#include <iomanip>
#include "directories.h"
using namespace std;

int main()
{
    // opens file wild_runners.txt and sets as an ifstream
    ifstream wild_runners("../../wild_runners.txt");

    // checks to make sure that the file opens correctly if not close program if not
    if (wild_runners.fail())
    {
        cout << "wild_runners.txt was not read... closing program" << endl;
        return 1;
    }
    cout << "wild_runners.txt was read\n";

    // Variables to store the information from the ifstream
    string phone;
    string name;
    string email;
    string title;

    // creates the ofstream wild_runners_directory to save the reformatted data to it
    ofstream wild_runners_directory("../../wild_runners_directory.txt");
    // gets the first line in the txt for the title
    getline(wild_runners, title);

    // exports the title and formats it for the wild_runners_directory.
    wild_runners_directory << setw(31) << title << endl;

    // the while loop, loops through the rest of the txt.  Fixing and reformatting the data.
    while (wild_runners >> phone)
    {
        phone = FixPhoneNumber(phone);
        wild_runners.ignore();
        getline(wild_runners, name);
        name = FixName(name);
        getline(wild_runners, email);
        email = FixEmail(email);
        WriteFormatted(phone, name, email, wild_runners_directory);
    }
    // close both files
    wild_runners.close();
    wild_runners_directory.close();

    // sets up the ifstream dnd and reads the data from the dungeon.txt
    ifstream dnd ("../../dungeons.txt");

    //  Checks to see if dungeon.txt loads and if not closes the program if not
    if (dnd.fail())
    {
        cout << "dungeon.txt was not read.... closing program" << endl;
    }
    cout << "dungeon.txt was loaded\n";

    // sets up the ofstream dungeon_directory
    ofstream dungeon_directory("../../dungeons_directory.txt");
    // gets the first line of the dungeon.txt
    getline(dnd, title);

    // formats the first line for dungeon_directory
    dungeon_directory << setw(28) << title << endl;

    // the while loop, loops through the rest of the file correcting and reformatting the data
    while (dnd >> phone)
    {
        phone = FixPhoneNumber(phone);
        dnd.ignore();
        getline(dnd, name);
        name = FixName(name);
        getline(dnd, email);
        email = FixEmail(email);
        WriteFormatted(phone, name, email, dungeon_directory);
    }
    // close both files
    dnd.close();
    dungeon_directory.close();

    return 0;
}