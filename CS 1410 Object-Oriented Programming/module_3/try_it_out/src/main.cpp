/**
 * Try it out Waldo and Earthquakes
 * Trevor Egbert
 * 5/31/22
 * Imports and Fixes Waldo story from and to a txt. Imports and formats an earthquake report from a txt file to a txt
 * file
 */
#include <iostream>
#include <string>
#include <iomanip>
#include "utilities.h"

using namespace std;

int main()
{
    // sets a variable read for a ifstream
    ifstream read;

    // opends file story.text to the read ifstream
    read.open("../../story.txt");

    // checks to see if the file was read
    if (read.fail())
    {
        cout << "story.txt wasn't read" << endl;
        return 1;
    }

    // checks that story.txt is open
    cout << "story.txt was read" << endl;

    // variable to store the string from the text file
    string story;

    // getting the line form text
    getline(read, story);

    // runs FixStory functions and stores it back in story
    story = FixStory(story);
    // closes story.txt file
    read.close();

    // creates ofstream called update_story and saves into the txt file updated story
    ofstream updated_story("../../updated_story.txt");
    updated_story << story;
    updated_story.close();

    // creates the if streams earthquakes and loads in earthquakes.txt
    ifstream earthquakes("../../earthquakes.txt");
    // checks to see if the earthquakes.txt was read
    if (earthquakes.fail())
    {
        cout << "Earthquakes.txt wasn't read" << endl;
        return 1;
    }
    // Lets you know the file was opened
    cout << "\nEarthquakes.txt file was read" << endl;

    // Setting variables to use for function WriteReportLine
    float magnitude;
    string type;
    string location;
    float latitude;
    float longitude;
    float depth;
    string time;
    // creates the ofstream report to store the information in earthquake_report.txt
    ofstream report("../../earthquake_report.txt");

    // This sets up the head for the earthquakes_report.txt
    report<< left <<setw(10) << "Magnitude"
   <<setw(40) << "Location"
   << setw(12) << "Latitude"
   << setw(12) << "Longitude"
   << setw( 6) << "Depth"
    <<"Time\n";
    // a loop the goes through earthquakes.txt and formats the information and puts in the ofstream reports
    while (earthquakes >> magnitude)
    {
        earthquakes.ignore();
        getline(earthquakes, type);
        getline(earthquakes, location);
        earthquakes >> latitude;
        earthquakes >> longitude;
        earthquakes >> depth;
        earthquakes.ignore();
        getline(earthquakes, time);
        WriteReportLine(magnitude, type, location, latitude, longitude, depth, time, report);

    }
    // closes the files
    earthquakes.close();
    report.close();

  return 0;
}


// FIXME: Write a void setter function that sets new values for the private
//        search and value tables. Name the function: SetTables
//        The function receives as parameters tables from which to load the
//        search and value tables.
