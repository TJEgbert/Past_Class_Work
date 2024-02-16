/**
 * Try-it-out: Template MyMin Function
 * Trevor Egbert
 * 7/2/2022
 * Creates the MyMin template function and implements it
 */
#include <iostream>
#include <string>
#include <min.h>
#include <carton.h>

using namespace std;

int main() {
  // use the MyMin function with integers

  int int_1 = 32, int_2 = 21;
  int int_min;

  int_min = MyMin(int_2, int_1);
  cout << "The smallest int is: " << int_min <<endl;

  // use the MyMin function with doubles

  double vol_1 = 75.41, vol_2 = 16.541;
  double vol_min;

  vol_min = MyMin(vol_1, vol_2);
  cout << "The smallest double is: " << vol_min << endl;

  // use the MyMin function with Cartons

  Carton box_1(32.1, 12, 14.7), box_2(20, 7.4, 5);
  Carton min_box;

  min_box = MyMin(box_1, box_2);
  cout << "The smallest Carton is: ";
  min_box.WriteCarton(cout);

  return 0;
}