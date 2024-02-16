#include <fstream>
#include <vector>
#include "load.h"
#include "shipping_item.h"
#include "carton.h"
#include "flat.h"
#include "tube.h"

/**
 * @brief: default constructor that sets all data members to zero;
 */
Load::Load()
{
    count_index_ = 0;
    load_size_ = 0;
    total_weight_ = 0;
    total_volume_ = 0;
}

/**
 * @brief: takes the file path that user gives and reads through checking to see what objects it needs to create.
 * Once created it its stored in the private vector of ShippingItem pointers.
 * Also it stores the size of the vector in load_size_, it also loops through that vector to get to weight and total
 * volume and stores them in the respective private data member.
 * @param filename sting: the path of the file the user wants to load
 */
void Load::FillLoad(std::string filename)
{
    std::ifstream infile(filename);

    if(infile.fail())
    {
        std::cout << filename << " did not load... closing program." << std::endl;
        return;
    }

    Address temp;
    char type;
    double weight, length, height, thickness, side1, side2, side3, circumference;

    while(infile >> type)
    {
        switch(type)
        {
            case 'F':
                infile.ignore();
                std::getline(infile, temp.name);
                std::getline(infile, temp.street_address);
                infile >> temp.city;
                infile >> temp.state;
                infile >> temp.zip;
                infile.ignore();
                infile >> weight;
                infile >> length;
                infile >> height;
                infile >> thickness;
                vector_load_.push_back(new Flat(temp, weight, length, height, thickness));
                load_size_ ++;
                break;

            case 'C':
                infile.ignore();
                std::getline(infile, temp.name);
                std::getline(infile, temp.street_address);
                infile >> temp.city;
                infile >> temp.state;
                infile >> temp.zip;
                infile.ignore();
                infile >> weight;
                infile >> side1;
                infile >> side2;
                infile >> side3;
                vector_load_.push_back(new Carton(temp, weight, side1, side2, side2));
                load_size_ ++;
                break;

            case 'T':
                infile.ignore();
                std::getline(infile, temp.name);
                std::getline(infile, temp.street_address);
                infile >> temp.city;
                infile >> temp.state;
                infile >> temp.zip;
                infile.ignore();
                infile >> weight;
                infile >> length;
                infile >> circumference;
                vector_load_.push_back(new Tube(temp, weight, length, circumference));
                load_size_ ++;
                break;

            default:
                break;
        }

    }
    for(ShippingItem* &package : vector_load_)
    {
        total_volume_ += package->Volume();
        total_weight_ += package->get_weight();
    }
    infile.close();
}

/**
 * @brief: destructor use to loop through the private vector of pointers and deletes and sets them to NULL
 */
Load::~Load()
{
    for(ShippingItem* &package : vector_load_)
    {
        delete package;
        package = NULL;
    }
}

/**
 * @brief: formats the output of which object is currently at the count_index_
 * name
 * street_address
 * city, state
 * package information from the Display method
 * @param out
 */
void Load::DisplayNextDelivery(std::ostream &out) const
{
    out <<
    vector_load_[count_index_]->get_address().name << std::endl <<
    vector_load_[count_index_]->get_address().street_address << std::endl <<
    vector_load_[count_index_]->get_address().city << ", " << vector_load_[count_index_]->get_address().state << " " <<
    vector_load_[count_index_]->get_address().zip << std::endl;
    vector_load_[count_index_]->Display(out);
}

/**
 * @brief: sets the current packaged delivered_ = true and increments the count_index_ by one
 */
void Load::ItemDelivered()
{
    vector_load_[count_index_]->set_delivered(true);
    count_index_ ++;
}

/**
 * @brief: sets the current package delivered_ = false and increments the count_index_ by one
 */
void Load::NotDeliverable()
{
    vector_load_[count_index_]->set_delivered(false);
    count_index_ ++;
}

/**
 * @brief: loops through the vector checking to see delivered_ = true and if it increments the counter by 1
 * @return int: how many packages delivered_ = true
 */
int Load::HowManyDelivered() const
{
    int count = 0;
    for (ShippingItem* package : vector_load_)
    {
        if(package->get_delivered())
        {
            count++;
        }
    }
return count;
}

/**
 * @brief: loops through the vector checking to see delivered_ = false and if it increments the counter by 1
 * @return int: how many packages delivered_ = false
 */
int Load::HowManyNotDelivered() const
{
    int count = 0;
    for(ShippingItem* package : vector_load_)
    {
        if(!package->get_delivered())
        {
            count ++;
        }
    }
    return count;
}