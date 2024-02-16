#ifndef DISTANCE_H_
#define DISTANCE_H_
#include <iostream>

class Distance
{
private:
    int feet_;
    double inches_;

public:
    // Constructors
    Distance(): feet_(0), inches_(0.0) {}
    Distance(int ft, double in) : feet_(ft), inches_(in) {}

    // Setters
    void set_distance(); // get it from user
    void update_distance(int ft, double in);

    // Getters
    int get_feet() const {return feet_;}
    double get_inches() const {return inches_;}

    // Operator overloads
    Distance operator + (Distance d2) const; // add 2 distances'
    Distance operator - (Distance d2) const;
    friend std::ostream &operator << (std::ostream &os, const Distance &d);

    // Other methods
    void show_distance() const;
};

#endif