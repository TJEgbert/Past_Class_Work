/**
 * Challenge: The Template KeyValue class
 * Trevor Egbert
 * 7/6/2022
 * Creates and implements that KeyValue template class
 */
#include <iostream>
#include "key_value.h"
#include "carton.h"

int main()
{
    // Testing in and string values
    KeyValue<int, std::string, 5> num_string_list;

    // Checking if the vector is empty
    if (num_string_list.Empty())
    {
        std::cout << "Empty" <<std::endl;
    }
    else
    {
        std::cout << "not empty" << std::endl;
    }

    // Adding ints and strings to vector
    num_string_list.Add(10, "blue");
    num_string_list.Add(12, "red");
    num_string_list.Add(5, "blue");
    num_string_list.Add(10, "purple");
    num_string_list.Add(2, "black");
    std::cout << num_string_list;

    // Using the KeyExists to check that value
    std::string find_five;
    if(num_string_list.KeyExists(5))
    {
        find_five = num_string_list.ValueAt(5);
        std::cout << "The value that goes with the key is " << find_five << std::endl;
    }
    else
    {
        std::cout << "The key is not in the vector" << std::endl;
    }

    // Using RemoveAll to remove the 10's and print out what remaining
    int count =num_string_list.RemoveAll(10);
    std::cout << count <<" were deleted from the vector" << std::endl;
    std::cout << num_string_list << std::endl;

    // Creates a new KeyValue Object of type String and Carton
    KeyValue<std::string, Carton, 7> carton_list;

    // Adding to carton_list
    carton_list.Add("Ace", Carton(47.5, 10, 15));
    carton_list.Add("King", Carton(21, 7, 15.5));
    carton_list.Add("Ace", Carton(47.5, 10, 15));
    carton_list.Add("Queen", Carton(3, 10.7, 100));
    carton_list.Add("Ace", Carton(47.5, 10, 15));
    carton_list.Add("Jack", Carton(12.50, 96.2, 71));
    carton_list.Add("Ace", Carton(47.5, 10, 15));

    // Testing to see the string "Jack" is in the vector
    try
    {
         carton_list.ValueAt("Jack");
         std::cout << "Key was found" << std::endl;
    }
    catch (std::out_of_range no_key)
    {
        std::cout << no_key.what() << std::endl;
    }

    // Removes the "Ace" string and prints out how many and what left of the vector
    int ace_remove = carton_list.RemoveAll("Ace");
    std::cout << ace_remove << " were deleted from the vector" << std::endl;
    std::cout << carton_list << std::endl;

  return 0;
}