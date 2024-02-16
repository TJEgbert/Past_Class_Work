/**
 * Challenge: The Template HowMany Function
 * Trevor Egbert
 * 7/3/2022
 * Creates HowMany template function and implements it
 */
#include <iostream>
#include <array>
#include "how_many.h"
#include "carton.h"


using namespace std;

int main()
{
    // Testing HowMany with ints
    array<int, kMaxSize> nums = {7, 5, 21, 52, 1, 7, 5, 7, 8, 10};
    int int_array_size = 10;
    int how_many_sevens;

    how_many_sevens = HowMany(7, nums, int_array_size);
    cout << "There are " << how_many_sevens << " sevens" << endl;

    // Testing HowMany with Strings
    array<string, kMaxSize> string_list = {"Ace", "Jack", "King", "Queen", "Ace", "Ace", "Ace", "Diamonds", "Clubs",
                                    "Spades", "Hearts"};
    int list_size = 11;
    int how_many_aces;
    string ace = "Ace";

    how_many_aces = HowMany(ace, string_list, list_size);
    cout << "There are " << how_many_aces << " aces" << endl;

    // Testing HowMany with Cartons
    array<Carton, kMaxSize> carton_list = {Carton(20, 4.5, 7.2), Carton(7.2, 4.5, 20),
                                           Carton(4.5, 20, 7.2), Carton(10, 14.72, 8.7),
                                           Carton(.75, 4.9, 5), Carton(9, 3.5, 7.2),
                                           Carton(30, 1.5, 3.33), Carton(67.1, 24, 7)};
    int carton_list_size = 8;
    int how_many_cartons;
    Carton box(20, 4.5, 7.2);

    how_many_cartons = HowMany(box, carton_list, carton_list_size);
    cout << "There are " << how_many_cartons << " boxes" << endl;

  return 0;
}