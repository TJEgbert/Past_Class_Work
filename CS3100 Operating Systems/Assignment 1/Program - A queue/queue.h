/* file: queue.h
 * CS 3100 - Operating Systems - Summer 2021
 * This file defines the types, structures and constants used in 
 * implementing a queue.
 */
 
#include <stdbool.h>

/* A typedef declares an alias for a type.
 */

typedef struct person {     // the type is "struct person"  not person
	char name[40];          // C uses character arrays for strings
	int age;
} person;                   // This is the creation of an alias, "person"

typedef struct node {       // a node in our linked list
	person value;           // a person in the linked list
	struct node *next;      // A pointer to the next node
} node;                     // alias "node" for "struct node"

typedef struct queue {
	node *head;             // a pointer to the head of the queue
	node *tail;             // a pointer to the tail of the queue
} queue;                    // alias "queue"  for "struct queue

// Function templates for the operations on our queue

// createq is a function that creates a new queue using malloc
// if the queue is not created a value of NULL is returned
queue *createq(void);       // There are no parameters to create queue


// enqueue is a function that adds an element to the queue, it requires
// a pointer to the queue and a person type as parameters, it returns a
// bool type (true on success and false on failure)
bool enqueue(queue *, person);


// dequeue is a function that removes a node from a given queue and 
// returns the record stored there.
person dequeue(queue *);    // if queue is NULL or empty, return blank person


// isemptyq returns true if the queue is NULL or empty, false if there 
// are nodes in the queue
bool isemptyqueue(queue *); // parameter is a pointer to the queue


// empytyq is a function that removes all nodes in the queue
// since this is a heap we need to manage it, return false if queue is NULL
bool emptyq(queue *);       // return true if queue is emptied


// freeq is a function that will free the memory for the queue if the 
// queue is empty.  It returns false if queue is not empty, true if freed
bool freeq(queue *);      // parameter is a pointer to the queue

