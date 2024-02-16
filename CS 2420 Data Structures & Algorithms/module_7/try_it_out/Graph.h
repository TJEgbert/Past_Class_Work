#ifndef TRY_IT_OUT_GRAPH_H
#define TRY_IT_OUT_GRAPH_H

#include <list>
#include <string>
#include <iostream>

struct Pair{

     int node;
     bool discovered;
     Pair(int n, bool d)
     {
         node = n;
         discovered = d;
     }
};

class Graph
{
public:

    Graph(std::string file);
    void printBFT(std::ostream& out);

    void printAdjList(std::ostream& out);
private:
    std::list<Pair>* adjList;
    int numNodes;
};


#endif //TRY_IT_OUT_GRAPH_H
