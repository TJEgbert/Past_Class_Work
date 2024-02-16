#include "Graph.h"

int main()
{

    Graph g1("../resources/graph.txt");
    Graph g2("../resources/graph2.txt");

    g1.printBFT(std::cout);
    std::cout << std::endl;
    g1.printAdjList(std::cout);
    std::cout << std::endl;

    g2.printBFT(std::cout);
    std::cout << std::endl;
    g2.printAdjList(std::cout);
    return 1;
}



