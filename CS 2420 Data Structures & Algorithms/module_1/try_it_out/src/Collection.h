#ifndef MODULE_1_COLLECTION_H
#define MODULE_1_COLLECTION_H

#include <iostream>
#include <array>

class Collection {

private:
    int arraySize_;
    int arrayIndex_;
    double *collectionArray_;
public:

    //constructor/ destructor
    Collection();
    Collection(int size);
    ~Collection(){}

    //get methods
    int getSize() {return arrayIndex_;}
    int getCapacity() {return arraySize_;}
    double get(int ndx);
    double getFront();
    double getEnd();

    // other methods and friend operator
    void add(double value);
    void addFront(double value);
    int find(double needle);
    friend std::ostream& operator<<(std::ostream& out, const Collection & c);
};

#endif //MODULE_1_COLLECTION_H
