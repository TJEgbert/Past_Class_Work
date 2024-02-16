#ifndef ORDEREDLINKEDLIST_H
#define ORDEREDLINKEDLIST_H
#include <iostream>

class Hashtable
{
private:
    int hash(int v) const;
    double loadFactor_;
    int size_;
    int capacity_;
    int* hTable_;


public:

    // Constructor and destructor
	Hashtable();
	Hashtable(int);
	Hashtable(int, double);
	Hashtable(const Hashtable& other);
	Hashtable& operator=(const Hashtable& other);
	~Hashtable();

    // Functions
    int size() const;
    int capacity() const;
    double getLoadFactorThreshold() const;
    bool empty() const;
	void insert(const int);
    void remove(int);
    bool contains(int) const;
    int indexOf(int) const;
    void clear();
    static bool isPrime(int n);
    static int nextPrime(int n);
    void fillTable();

    // Static const variables
    static const int c1;
    static const int c2;
};
#endif
