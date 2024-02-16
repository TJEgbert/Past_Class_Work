#ifndef GRAPH_H
#define GRAPH_H
#include <stack>
#include <list>
#include <stack>
#include <vector>
#include <iostream>
#include <queue>

using std::endl;
using std::cout;
using std::ostream;
using std::stack;
using std::vector;

template <typename T>
class Graph;

template <typename T>
ostream& operator << (ostream & out, Graph<T> g);

template <typename T>
class Graph{
private:
    //Declare any variables needed for your graph

    int numOfVert_;
    int maxNumOfVert_;
    std::list<T>* adjList;



public:
    Graph();
    Graph(int);
    void addVertex(T vertex);
    void addEdge(T source, T target);
    vector<T> getPath(T, T);
    int findVertexPos(T item);
    int getNumVertices();
    friend ostream& operator << <>(ostream & out, Graph<T> g);
};



/*********************************************
* Constructs an empty graph with a max number of verticies of 100
* Sets numOfVer_ = 0
* sets up the array of lists to maxNumOfVert_
*********************************************/
template<typename T>
Graph<T>::Graph()
{
    numOfVert_ = 0;
    maxNumOfVert_ = 100;

    adjList = new std::list<T>[maxNumOfVert_];
}


/*********************************************
* Constructs an empty graph with a given max number of verticies
* Sets numOfVer_ = 0
* sets up the array of lists to maxNumOfVert_
*********************************************/
template<typename T>
Graph<T>::Graph(int maxVerticies)
{

    numOfVert_ = 0;
    maxNumOfVert_ = maxVerticies;
    adjList = new std::list<T>[maxNumOfVert_];
}




/*********************************************
* Adds a Vertex to the GraphIf number of verticies is less than the
* Max Possible number of verticies.
*********************************************/
template <typename T>
void Graph<T>::addVertex(T vertex)
{
    if(numOfVert_ < maxNumOfVert_)
    {
        adjList[numOfVert_].push_back(vertex);
        numOfVert_++;
    }
}

/*********************************************
* Returns the current number of vertices
*
*********************************************/
template<typename T>
int Graph<T>::getNumVertices()
{

    return numOfVert_;
}



/*********************************************
* Returns the position in the verticies list where the given vertex is located, -1 if not found.
*
*********************************************/
template <typename T>
int Graph<T>::findVertexPos(T item){


    for (int i = 0; i < getNumVertices(); ++i)
    {
        if(*adjList[i].begin() == item)
        {
            return i;
        }
    }
    return -1; //return negative one
}//End findVertexPos

/*********************************************
* Adds an edge going in the direction of source going to target
* Adds the target into the list of the source
*********************************************/
template <typename T>
void Graph<T>::addEdge(T source, T target)
{
    int location = findVertexPos(source);
    adjList[location].push_back(target);
}


/*********************************************
* Returns a display of the graph in the format
* vertex: edge edge
Your display will look something like the following
    9: 8 5
    2: 7 0
    1: 4 0
    7: 6 2
    5: 6 8 9 4
    4: 5 1
    8: 6 5 9
    3: 6 0
    6: 7 8 5 3
    0: 1 2 3
*********************************************/
template <typename T>
ostream& operator << (ostream & out, Graph<T> g)
{
    // Loops through the array
    for (int i = 0; i < g.numOfVert_; ++i)
    {
        // Iterates through the list
        for(auto listIt = g.adjList[i].begin(); listIt != g.adjList[i].end(); listIt++)
        {
            // if it's the first thing in the list prints it out followed by ": "
            if(listIt == g.adjList[i].begin())
            {
                out << *listIt << ": ";
            }
            else
            {
                // prints the listIt and then a space
                out << *listIt << " ";
            }

        }
        out << endl;
    }
    return out;
}




/*
  getPath will return the shortest path from source to dest.
  You may use any traversal/search algorithm you want including
  breadth first, depth first, dijkstra's algorithm, or any
  other graph algorithm.
  You will return a vector with the solution.  The source will be in position 1
  the destination is in the last position of the solution, and each node in between
  are the verticies it will travel to get to the destination.  There will not be any
  other verticies in the list.

  Given the test graph:

[0]-----------[2]
|  \            \
|   \            \
[1]  [3]----[6]---[7]
|          /  \
|         /    \
|        /      \
|     [5]--------[8]
|    /   \       /
|   /     \     /
|  /       \   /
[4]         [9]

getPath(0, 5) should return
0 -> 1 -> 4 -> 5   or   0 -> 3 -> 6 -> 5

  Hint: As you find the solution store it in a stack, pop all the items of the stack
  into a vector so it will be in the correct order.

*/
template <typename T>
vector<T> Graph<T>::getPath(T source, T dest)
{
    // Sets up the vector and stack used for the answer
    vector<T> solution;
    std::stack<T> answer;
    vector<T> check_answer;

    // Sets up the victor and queue used in the breadth first
    vector<int> discovered;
    std::queue<T> queue;

    // booleans used if item is located in one of the vectors
    bool found = false;
    bool check_found = false;

    // the amount that needs to be removed from discovered before the back tracking start
    int remove_count = 0;

    // A queue used to store backTrack vertices
    std::queue<T> backTrack;

    // adds the source to queue and discovered
    queue.push(source);
    discovered.push_back(findVertexPos(source));

    // As long as queue is not empty
    while(!queue.empty())
    {
        // Gets the next Vertex position and then pops it out of the queue
        auto next= findVertexPos(queue.front());
        queue.pop();

        // Loops through the list of adjList[next]
        for(auto listIt = adjList[next].begin(); listIt != adjList[next].end(); listIt++)
        {
            // Loops through the discovered vector
            for (int i = 0; i < discovered.size(); ++i)
            {
                // checks to see if the current iterator has been discovered
                if(findVertexPos(*listIt) == discovered[i])
                {
                    // if so sets found to true
                    found = true;
                }
            }

            // found == true
            if(found)
            {
                // sets found to false and add one to remove_count
                found = false;
                remove_count++;
            }
            else
            {
                // if found == false
                // adds the current iterator to queue and discovered
                queue.push(*listIt);
                discovered.push_back(findVertexPos(*listIt));

                // adds one to remove_count
                remove_count++;
            }

            // if the current iterator is equal to dest
            if(*listIt == dest)
            {
                // add the current list.begin to backTrack
                backTrack.push(*adjList[next].begin());

                // adds the current iterator to answer
                answer.push(*listIt);
                check_answer.push_back(*listIt);

                // adds the current list.begin to answer and check_answer
                answer.push(*adjList[next].begin());
                check_answer.push_back(*adjList[next].begin());

                // removes the amount from the remove_count from the discovered
                for (int i = 0; i < remove_count; ++i)
                {
                    discovered.pop_back();
                }

                // while backTack is not empty
                while(!backTrack.empty())
                {
                    // gets vertex from the backTrack.front
                    int back = findVertexPos(backTrack.front());

                    // iterators through the current vertex list
                    for(auto backList = adjList[back].begin(); backList != adjList[back].end(); backList++)
                    {
                        // if backList is not equal to the front
                        if(backList != adjList[back].begin())
                        {
                            // loops through the discovered
                            for (int i = discovered.size(); i > 0; --i)
                            {
                                // checks to see if current vertex is in discovered
                                if(findVertexPos(*backList) == discovered[i])
                                {
                                    // if so it removes one from discovered
                                    discovered.pop_back();
                                    // removes it from backTrack
                                    backTrack.pop();

                                    // adds the current iterator to backTrack
                                    backTrack.push(*backList);

                                    // loops through the check_answer vector
                                    for (int j = 0; j < check_answer.size(); ++j)
                                    {
                                        // if found sets check_found = true
                                        if(*backList == check_answer[j])
                                        {
                                            check_found = true;
                                        }
                                    }

                                    // if check_found == false
                                    if(!check_found)
                                    {
                                        // adds the current iterator to answer and check_answer
                                        answer.push(*backList);
                                        check_answer.push_back(*backList);

                                        // sets check_found = false
                                        check_found = false;
                                    }
                                    // sets found = true and breaks from the loop
                                    found = true;
                                    break;
                                }
                            }

                            // checks if backList equal to the source
                            if(*backList == source)
                            {
                                // pushes the current iterator onto answer stack
                                answer.push(*backList);

                                // removes whatever is left form backTack and queue
                                while(!backTrack.empty())
                                {
                                    backTrack.pop();
                                }
                                while(!queue.empty())
                                {
                                    queue.pop();
                                }
                                // breaks from the loop
                                break;
                            }
                            // if found = true
                            if(found)
                            {
                                //found = false and breaks from the loop
                                found = false;
                                break;
                            }
                        }

                    } // end of the second for loop for the list
                } // end of backtracking while loop

            }// end of the start of the backtracking

        }// the end of the first for loop of the list

        // updates remove count to zero

        remove_count = 0;
    } // end of the fist while loop

    // While answer is not empty
    while(!answer.empty())
    {
        // adds the top of the answer to solution vector and pops answer
        solution.push_back(answer.top());
        answer.pop();
    }

    // returns solution vector
    return solution;
}

#endif
