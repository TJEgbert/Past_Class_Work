#include <string>
#include <fstream>
#include <vector>
#include "carton.h"

/**
 * @brief Loads a file of ints into an array of size specified in file and then writes the total, average, and how many
 * ints are the array to an outfile.
 * @param input_file string: The name of the file that the user wants to load
 * @param output_file string: The name of the file the user wants to output to
 */
void WriteStats(std::string input_file, std::string output_file) {
  // define and open output file
  std::ofstream out_file(output_file);

  // define and open input file
  std::ifstream in_file(input_file);

  if (in_file.fail())
  {
      out_file << "Unable to open file. Shutting down...";
      return;
  }

  // read how many
  int size;
  in_file >> size;

  // dynamically allocate an array that big
  int* int_array = NULL;
  int_array = new int[size];

  // fill the array from the input file
    for (int i = 0; i < size; ++i)
    {
        in_file >> int_array[i];
    }

  // close the input file
  in_file.close();

  // compute total and average
  int total = 0, count = 0;
  float average;
  for (int i = 0; i < size; ++i)
  {
      total += int_array[i];
      count ++;
  }
  average = static_cast<float>(total)/ count;

  // output count, total, and average to output file
  out_file << count << std::endl;
  out_file << total << std::endl;
  out_file << average << std::endl;

  // delete the dynamically allocated array
  delete [] int_array;

  // close the output file
  out_file.close();

}

/**
 * @brief Loads a file of Carton data and formats it using the method WriteCarton from the Carton class
 * @param input_file string: The name of the file that the user wants to read from
 * @param output_file string: The name of the file that user wants to output to
 */
void WriteCartons(std::string input_file, std::string output_file) {
  // define and open output file
  std::ofstream out_file(output_file);

  // define and open input file
  std::ifstream in_file(input_file);

  if(in_file.fail())
  {
      out_file << "Unable to open file. Shutting down...";
      return;
  }

  // declare a vector of Carton pointers
  std::vector<Carton*> carton_vector;

  // loop through file, read Carton data, create new Carton objects, and
  // store pointers in vector

  double length, width, height;
  while(in_file >> length)
  {
      in_file >> width;
      in_file >> height;
      carton_vector.push_back(new Carton(length, width, height));
  }

  // close the input file
  in_file.close();

  // loop through vector and write cartons to output file
  for (auto & i : carton_vector)
  {
      i->WriteCarton(out_file);
  }
  // loop through vector, delete memory for each pointer, and set pointer
  // equal to NULL
  for(Carton* &value : carton_vector)
  {
      delete value;
      value = NULL;
  }

  // close the output file
  out_file.close();
}
