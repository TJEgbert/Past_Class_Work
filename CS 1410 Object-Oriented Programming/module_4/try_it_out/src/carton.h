#ifndef CARTON_H
#define CARTON_H
#include <iostream>

class Carton
{

private:
    float length_;
    float width_;
    float height_;

public:

    // constructors
    Carton() { length_ = 1.0, width_ = 1.0, height_ = 1.0;}
    Carton(float length, float width, float height);

    // Destructor
    ~Carton() {};

    // Getter
    float GetLength() const {return length_;}
    float GetWidth() const {return width_;}
    float GetHeight() const {return height_;}

    // Setters
    void SetLength(float length);
    void SetWidth(float width);
    void SetHeight(float height);

    // Other methods
    void WriteData(std::ostream &out) const;
    void WriteCarton(std::ostream &out) const;
    float Volume() const;

};



#endif