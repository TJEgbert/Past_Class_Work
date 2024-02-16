#include <iostream>
#include <sstream>
#include "Collection.h"

using namespace std;

void TestCollection();
void TestExceedSize();
void TestAddBeginning();
void TestExtractionOperator();
bool checkCase(std::string name, bool condition);

int main()
{
    TestCollection();
    TestExceedSize();
    TestAddBeginning();
    TestExtractionOperator();
    return 0;
}
void TestCollection(){
    Collection one;
    one.add(2.2);
    one.add(4.5);

    checkCase("Adding 1", one.get(0) == 2.2);
    checkCase("Adding 2", one.get(1) == 4.5);
    checkCase("Check Size", one.getSize()== 2);
}
void TestExceedSize(){
    Collection one;
    for(int i = 0; i < one.getCapacity(); i++){
        one.add(i);
    }

    checkCase("Exceed Size 1", one.get(0) == 0);
    checkCase("Exceed Size 2", one.get(one.getCapacity()-1) == one.getCapacity()-1);


}
void TestAddBeginning(){
    Collection one;

    for(double i = 0; i < 5; i += 1){
        one.add(i);
    }
    one.addFront(2);
    checkCase("Add to Front Check 1", one.get(0) == 2);
    checkCase("Add to Front Check 2", one.get(5) == 4);
    checkCase("Add to Front Check 3", one.getSize() == 6);


}
void TestExtractionOperator(){
    Collection one;
    one.add(1);
    one.add(2);
    stringstream sout;
    sout << one;
    checkCase("Overloaded Extraction Operator", sout.str() == "1 2");
}

bool checkCase(string name, bool condition){
    if(!condition){
            cout << "Failed: " << name << endl;
    }
    else{
            cout << name << ": passed" << endl;
    }
    return condition;
}
