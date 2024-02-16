/**
 * Final Project
 * Trevor Egbert
 * 7/30/22
 * Creates package related class from the abstract class shipping_item and a class used for loading those packages with
 * other functions and methods of load class.
 */
#include <iostream>
#include <string>
#include "shipping_item.h"
#include "carton.h"
#include "flat.h"
#include "tube.h"
#include "load.h"

using std::cout;
using std::endl;

int main() { 


    cout << "Part 2.2: Use the Carton Class in Main.cpp\n";

    // Create a Carton object using the new constructor.
    // When using this constructor, use try/catch blocks to handle
    // the exceptions.

    // creates two address structs and load them with data
    Address test_address;
    test_address.name = "Richter Belmont";
    test_address.state = "UT";
    test_address.city = "Layton";
    test_address.street_address = "123 West 789 North";
    test_address.zip = "84401";

    Address test_address2;
    test_address2.name = "Trevor Belmont";
    test_address2.state = "UT";
    test_address2.city = "Roy";
    test_address2.street_address = "666 West 666 North";
    test_address2.zip = "84401";

    // try catch for creating carton object
    try
    {
        Carton box1(test_address, 50, 10.7, 10, 20.5);
        cout << "box1 info: " << box1.get_height() << " " << box1.get_width() << " " << box1.get_length() <<  " " <<
             box1.get_delivered() << " " << box1.get_weight() << endl;
        cout << box1.get_address().name << endl;
    }
    catch(std::out_of_range &why)
    {
        cout << why.what() << endl;
    }

    // creates the box2 of the Carton class
    Carton box2(test_address, 50, 10.7, 20, 20.5);

    // Use the Carton object to call the getter and setter methods.
    // Print out the results to see that the methods are doing what is expected.
    // When calling the setters, use try/catch blocks to handle the exceptions.

    // uses the getters of the Carton class
    cout << "box2 info: " << box2.get_height() << " " << box2.get_width() << " " << box2.get_length() <<  " " <<
    box2.get_delivered() << " " << box2.get_weight() << endl;

    // uses the setters of the Carton class
    box2.set_address(test_address2);
    box2.set_length(21);
    box2.set_height(12);
    box2.set_width(18);
    box2.set_delivered(true);

    // uses the getters
    cout << "box2 info: " << box2.get_height() << " " << box2.get_width() << " " << box2.get_length() <<  " " <<
    box2.get_delivered() << " " << box2.get_weight() << endl;

    // use the Carton object to call the Display method to print to cout.
    box2.Display(cout);

    cout << "\nPart 3.3: Use the Flat Class in Main.cpp\n";

    // Create Flat objects using the default and non-default constructors.
    // When using the non-constructor, use try/catch blocks to handle the
    // exceptions.

    // creates to Flat objects one using catch/try
    Flat flat1;

    try
    {
        Flat flat2(test_address2, 5, 12, 12, .7);
    }
    catch(std::out_of_range &why)
    {
        cout << why.what() << endl;
    }


    // Use the Flat objects to call the getter and setter methods.
    // Print out the results to see how these getters and setters are working.
    // When calling the setters, use try/catch blocks to handle the exceptions.

    // creates flat2 and gets the information about it
    try
    {
        Flat flat2(test_address2, 5, 12, 12, .7);
        cout << "flat2 info: height " << flat2.get_height() << " thickness " << flat2.get_thickness() << " weight "
        << flat2.get_weight() << " delivered " << flat2.get_delivered() << " length " << flat2.get_length() << endl;

        cout << "flat2 address: " << endl;
        cout << flat2.get_address().name << endl;
        cout << flat2.get_address().street_address << endl;
        cout << flat2.get_address().city << endl;
        cout << flat2.get_address().state << endl;
        cout << flat2.get_address().zip << endl;
    }
    catch(std::out_of_range &why)
    {
        cout << why.what() << endl;
    }

    // uses the setters to set flat1
    try
    {
        flat1.set_thickness(.45);
        flat1.set_height(12);
        flat1.set_length(10);
        flat1.set_weight(50);
        flat1.Display(cout);
    }
    catch(std::out_of_range &why)
    {
        cout << why.what() << endl;
    }


    // Use the Flat objects to call the Volume and Display methods.
    // Print out the results to cout.

    // creates the flat to object and use the display methods
      try
      {
          Flat flat2(test_address2, 5, 12, 12, .7);
          flat2.Display(cout);
          cout << "flat2 volume is " << flat2.Volume() << endl;
      }
      catch(std::out_of_range &why)
      {
          cout << why.what() << endl;
      }


      cout << "\nPart 4.3: Use the Tube Class in Main.cpp\n";

    // 1. Create Tube objects using the default and non-default constructors.
    // When using the non-constructor, use try/catch blocks to handle the
    // exceptions.

    // creates two Tube objects one with try/catch
    Tube tube1;
    try
    {
        Tube tube2(test_address2, 30, 36, 4);
    }
    catch(std:: out_of_range &why)
    {
        cout << why.what() << endl;
    }


    // Use the Tube objects to call the getter and setter methods.
    // Print out the results to see how these getters and setters are working.
    // When calling the setters, use try/catch blocks to handle the exceptions.

    // use the setters and getters of Tube class
    try
    {
        tube1.set_circumference(10);
        tube1.set_length(27.5);
        tube1.set_weight(37.4);
        tube1.set_address(test_address);
        tube1.set_delivered(true);

        cout << "tube1 info circumference: " << tube1.get_circumference() << " length: " << tube1.get_length() <<
              " weight: " << tube1.get_weight() << " delivered: " << tube1.get_delivered() << endl;


        cout << "flat1 address: " << endl;
        cout << tube1.get_address().name << endl;
        cout << tube1.get_address().street_address << endl;
        cout << tube1.get_address().city << endl;
        cout << tube1.get_address().state << endl;
        cout << tube1.get_address().zip << endl;
    }
    catch(std::out_of_range &why)
    {
        cout << why.what() << endl;
    }

    // Use the Tube objects to call the Volume, Girth and Display methods.
    // Print out the results to cout.

    // creates tube2 and display its information with the Volume Girth and Display methods
    try
    {
        Tube tube2(test_address2, 30, 36, 4);

        cout << "tube2 volume: "<< tube2.Volume() << " tube2 girth: " << tube2.Girth() << endl;
        tube2.Display(cout);
    }
    catch(std:: out_of_range &why)
    {
        cout << why.what() << endl;
    }


      cout << "\nPart 5.3: Use the Load Class in Main.cpp\n";

    // 1. Create a Load object.

    // strings of the file path
    std::string infile("../../load_small.txt");
    std::string infile2("../../load_1.txt");

    // creates two objects of the load class
    Load load1;
    Load load2;

    // uses the FillLoad to load load1
    load1.FillLoad(infile);

    // 2. Use the Load object to call the getter methods.
    // Print out the results to see how these getters are working.
    // Do this right after the Load object is created, and after it
    // is filled from the file.

    // display load1 information with the getters
    cout << "number of packages: " << load1.get_count() << endl;
    cout << "volume of packages: " << load1.get_total_volume() << endl;
    cout << "weight of packages: " << load1.get_total_weight() << endl;


    //3. use the Load object to call the FillLoad method.
    // Then call the DisplayNextDelivery, ItemDelivered, NotDeliverable,
    // HowManyDelivered, and HowManyNotDelivered methods multiple times
    // to see how these work when making deliveries.
    cout << endl;

    // se FillLoad for load2 and infile 2
    load2.FillLoad(infile2);

    // uses the methods of the Load class
    cout << "load2 number of packages: " << load2.get_count() << endl;
    cout << "load2 number of packages delivered: " << load2.HowManyDelivered() << endl;
    load2.DisplayNextDelivery(cout);
    load2.ItemDelivered();
    load2.DisplayNextDelivery(cout);
    load2.ItemDelivered();
    load2.DisplayNextDelivery(cout);
    cout << "load2 number of packages delivered " << load2.HowManyDelivered() << endl;
    load2.NotDeliverable();
    load2.NotDeliverable();
    load2.NotDeliverable();
    cout << "load2 number of packages weren't delivered: "<< load2.HowManyNotDelivered() << endl;

    return 0;
}