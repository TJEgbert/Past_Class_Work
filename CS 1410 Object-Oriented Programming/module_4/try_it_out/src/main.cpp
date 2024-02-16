/**
 * Try it out: The Carton Class
 * Trevor Egbert
 * 6/12/2022
 * Creates the carton class and use it to read and write reports.
 */

#include <iostream>
#include <array>
#include <fstream>
#include "carton.h"

using namespace std;

int main()
{
  // Create a constant int that will specify the size of the arrays
  // in this program. Set it to 20.

  const int kMaxSize = 20;

  // Write the value of the constant to cout.
  cout << "\nConstant to specify size of array: \n";

  cout << kMaxSize << endl;

  // Create a Carton object using the default constructor.
  Carton carton_1;

  // Use the getters to write the length, width, and height of
  // the Carton to cout.
  cout << "\nFirst Carton information:\n";

  cout << "Length: " <<carton_1.GetLength() << " Width: "<< carton_1.GetWidth() << " Height: " << carton_1.GetLength()
        << endl;

  // Create a Carton object using the non-default constructor.
  Carton carton_2(1, 2, 5);

  // Use the getters to write the length, width, and height of
  // the Carton to cout.
  cout << "\nSecond Carton information:\n";

  cout << "Length: " << carton_2.GetLength() << " Width: " << carton_2.GetWidth() << " Height: " << carton_2.GetHeight()
        << endl;

  // Create an array of Cartons. Use the constant defined earlier for the
  // size of the array.

  array<Carton, kMaxSize> carton_list;

  // Update the first three elements of the array by adding Carton objects
  // created with the non-default constructor.

  Carton carton_3(0, 7, 50);
  Carton carton_4(10, -8, 60);
  Carton carton_5(70, 21, -72);
  carton_list[0] = carton_3;
  carton_list[1] = carton_4;
  carton_list[2] = carton_5;

  // Loop through the first three elements in the array, use the getters
  // to write the length, width, and height of the Cartons.
  cout << "\nDetails of three Cartons in an array:\n";

  for (int i = 0; i < 3; ++i)
  {
      cout << "Carton length: " << carton_list[i].GetLength() << " Width: " << carton_list[i].GetWidth() <<
      " Height: " << carton_list[i].GetHeight() << endl;
  }


  // Use the WriteData method to print the data of the two Cartons you
  // have created to cout.
  cout << "\nData of two Cartons:\n";

  carton_1.WriteData(cout);
  carton_2.WriteData(cout);

  // Use the WriteCarton method to print sentences about the two Cartons you
  // have created to cout.
  cout << "\nReport of two Cartons:\n";

  carton_1.WriteCarton(cout << endl);
  carton_2.WriteCarton(cout << endl);
  cout << endl;

  // Loop through the first three elements in the array and write carton data
  // and information using the WriteData and WriteCarton methods.
  // Notice the WriteData method adds an endl and the WriteCarton does not.
  // Add an endl after calling the WriteCarton method.
  cout << "\nReport and data of three Cartons in an array:\n";

  for (int i = 0; i < 3; ++i)
  {
      carton_list[i].WriteData(cout);
      carton_list[i].WriteCarton(cout);
      cout << endl;
  }

  // Print out the volume of two Cartons you have created to cout.
  cout << "\nVolumes of two Cartons:\n";

  cout << carton_1.Volume() << endl;
  cout << carton_2.Volume() << endl;

  // Loop through the first three elements in the array and print out
  // the volume of the Cartons in the array.
  cout << "\nVolumes of the first three Cartons in the array:\n";

  for (int i = 0; i < 3; ++i)
  {
      cout << carton_list[i].Volume() << endl;
  }

  // Create another array of Cartons. Use the constant defined earlier for the
  // size of the array.

  array<Carton, kMaxSize> carton_out_file;

  // Define and open an ifstream object. Test that the ifstream opens.
  // Then read the data from file named
  // cartons.txt and store them in this array.

  ifstream carton_in_file("../../cartons.txt");

  if (carton_in_file.fail())
  {
      cout << "carton.txt did not load... Shutting down";
  }

  int index = 0;
  float length, width, height;
  while(carton_in_file >> length)
  {
      carton_in_file >> width;
      carton_in_file >> height;
      carton_list[index] = Carton(length, width, height);
      ++ index;

  }

  // Write the Carton data to file named carton_data.txt. First, define and
  // open an ofstream object using that filename. Then loop through the
  // array from Part 7 and use WriteData to write the data for
  // each Carton. Put each Carton on a single line. Do not include blank lines.
  // Include all the valid Cartons in the array and none of the default Cartons.

  ofstream carton_data("../../carton_date.txt");

  for (int i = 0; i < index; ++i)
  {
      carton_list[i].WriteData(carton_data);
  }
  carton_data.close();

  // Write a Carton report to file named carton_report.txt. First, define and
  // open an ofstream object using that filename. Then loop through the
  // array from Part 7 and use WriteCarton to write a sentence for
  // each Carton. Put each Carton on a single line. Include all the valid
  // Cartons in the array and none of the default Cartons.

  ofstream carton_report("../../carton.report.txt");

  for (int j = 0; j < index; ++j)
  {
      carton_list[j].WriteCarton(carton_report);
      carton_report << endl;
  }

  return 0;
}