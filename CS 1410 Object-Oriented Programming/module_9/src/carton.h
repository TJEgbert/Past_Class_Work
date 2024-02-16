#ifndef CARTON_H
#define CARTON_H

#include <iostream>
#include "shipping_item.h"

// class Carton : public ShippingItem {
class Carton : public ShippingItem {
private:
  // remove this member, now in ShippingItem
  double width_;
  double height_;

public:
  // static
  static const double kMinLength;
  static const double kMinWidth;
  static const double kMinHeight;


  // constructors and destructor
  Carton();
  Carton(double side1, double side2, double side3);
  // Add new constructor
  Carton(Address address, double weight, double side1, double side2, double side3);

  ~Carton() {}

  // getters
  // remove this member, now in ShippingItem
  double get_width() const { return width_; }
  double get_height() const { return height_; }

  // setters
  void set_length(double length);
  void set_width(double width);
  void set_height(double height);
  void set_measurements(double side1, double side2, double side3);

  // other methods
  double Volume() const;
  double Girth() const;
  double LengthPlusGirth() const;
  bool SizedToShip() const;
  void WriteData(std::ostream& out) const;
  void WriteCarton(std::ostream& out) const;
  friend std::ostream& operator<<(std::ostream& out, const Carton& carton);
  void Display(std::ostream &out) const;
};

#endif