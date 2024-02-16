/**
 * Try-it-out: The Template MinInArray Function
 * Trevor Egbert
 * 7/2/2022
 * Creates MinInArray template function and implements it
 */
#include <array>
#include <iostream>
#include "carton.h"
#include "min_array.h"

using namespace std;

int main() {
  // use the MinInArray function with integers
  array<int, kMaxSize> counts = {9, 12, 53, 45, 56, 43, 92, 77,
                                 8, 14, 41, 73, 59, 22, 33, 83};
  int count_size = 16;

  int min_count;
  min_count = MinInArray(counts, count_size);
  cout << "The smallest count is: " << min_count << endl;

  // use the MinInArray function with doubles
  array<double, kMaxSize> volumes = {91.7,  83,   84.6, 103.7, 77.2,
                                     81.8,  92.4, 49.3, 43.93, 54.53,
                                     71.34, 54,   62.3, 76.23};
  int volume_size = 14;

  double min_volume;
  min_volume = MinInArray(volumes, volume_size);
  cout << "The smallest volume is: " << min_volume << endl;


  // use the MinInArray function with Cartons
  array<Carton, kMaxSize> presents = {
      Carton(8.1, 7, 15.8),    Carton(9, 14, 13.8),   Carton(7, 8.3, 12.82),
      Carton(15.2, 6.9, 12.7), Carton(5.9, 6.3, 9.2), Carton(8.2, 7.92, 6.58)};
  int present_size = 6;

  Carton min_present;
  min_present = MinInArray(presents, present_size);
  cout << "The smallest present is: ";
  min_present.WriteCarton(cout);

  return 0;
}