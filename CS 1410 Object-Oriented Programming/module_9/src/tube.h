#ifndef TUBE_H
#define TUBE_H
#include "shipping_item.h"

class Tube : public ShippingItem
{
private:
    double circumference_;

public:
    // static const variable
    static const double kPi;

    //constructor and destructor
    Tube();
    Tube(Address address, double weight, double length, double circumference);
    ~Tube() {}

    // getter
    double get_circumference() const {return circumference_;}

    // setter
    void set_circumference(double circumference);

    // other methods
    double Volume() const;
    double Girth() const {return circumference_;}
    void Display(std::ostream &out) const;

};

#endif