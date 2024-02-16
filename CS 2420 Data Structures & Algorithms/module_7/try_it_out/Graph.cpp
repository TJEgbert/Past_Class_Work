#include "Graph.h"
#include <fstream>
#include <stdexcept>
#include <queue>


/**
 * @brief Constructor for the Graph class.  Reads in a txt file and creates an adjacency list for it
 * @param file txt. the file the user wants to create a graph from
 */
Graph::Graph(std::string file)
{
    std::ifstream input;
    input.open(file);

    if(!input)
    {
        throw std::invalid_argument("Could not read file");
    }

    input >> numNodes;
    adjList = new std::list<Pair>[numNodes];

    for (int i = 0; i < numNodes; ++i)
    {
        int value;

        input >> value;
        while(value > -1)
        {
            adjList[i].push_back(Pair(value, false));
            input >> value;
        }
    }
}

/**
 * @brief: Does Breath-First Traversal of the graph object and outputs the information through the passed ostream.
 */
void Graph::printBFT(std::ostream & out)
{
    // Creates a queue called discovered push the starting pair in and sets it to true
    std::queue<Pair> discovered;
    discovered.push(adjList->front());
    adjList->front().discovered = true;

    // while the queue is not empty
    while(!discovered.empty())
    {
        // gets the value of the current node then pops it and prints it
        auto curr = discovered.front().node;
        discovered.pop();
        out << curr << " ";

        // iterate through the current list item
        for(auto listIt = adjList[curr].begin(); listIt != adjList[curr].end(); listIt++)
        {
            // if the listIt discovered is false it sets it to true and adds it the queue
            if(!listIt->discovered)
            {
                listIt->discovered = true;
                discovered.push(*listIt);
            }

        }
    }

}

/**
 * @brief iterates through the list object formatting it and out putting to the ostream passed in
 */
void Graph::printAdjList(std::ostream& out)
{
    for (int i = 0; i < numNodes; ++i)
    {
        for(auto listIt = adjList[i].begin(); listIt != adjList[i].end(); listIt++)
        {
            std::cout << listIt->node;
            if(listIt == adjList[i].begin())
            {
                out << ":";
            }
            else
            {
                out << " ";
            }
        }
        out << std::endl;
    }
}