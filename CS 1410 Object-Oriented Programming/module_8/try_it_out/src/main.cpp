/**
 * Try-It_Out: Allocating Dynamic Memory
 * Trevor Egbert
 * 7/23/2022
 * Loads files of ints and give data about the numbers in an outfile.
 * Loads a file of Carton data and formats it in an outfile.
 */
#include <fstream>
#include <iostream>
#include <string>
#include "using_pointers.h"

using namespace std;

int main()
{
    string int_input("../../integers.txt");
    string stats("../../stats.txt");

    WriteStats(int_input, stats);

    string carton_input("../../cartons.txt");
    string carton_out("../../cartons_out.txt");

    WriteCartons(carton_input, carton_out);
    return 0;
}