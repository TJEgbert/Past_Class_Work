/* file: prog1.c
 * This is the main driver porgram to test the functionality of the 
 * queue implemented as a linked list.  
 * 
 * Structure of the program:
 * 1. Declare needed variables 
 *    array of queue pointers, initialized to NULL
 *    a variable of type person to hold return values and to send as a parameter
 * 2. Test isemptyq with NULL queue
 * 3. Test dequeue with NULL queue and empty queue
 * 4. Test freeq with NULL queue and empty queuue
 * 5. Test createq, put pointers in array
 * 6. Add three elements to first queue and dequeue only first element
 * 7. Check for isemptyq for first queue
 * 8. Add two elements to second queue 
 * 9. Add two elements to third queue
 * 10. Check call to freeq for non-empty queue
 * 11. Use a loop to dequeue the two elements of queue 1, print values, free 1
 * 12. Empty and free queues 2 & 3
*/

#include <stdio.h>
#include <string.h>
#include "queue.h"


int main(int argc, char *argv[]) {
	
	// 1. Declare needed variables
	queue *theqs[3] = { NULL };
	person a = {"Albus Dumbledore", 77},
		   b = {"Harry Potter", 11},
		   c = {"Ronald Weasley", 11},
		   d = {"James Tiberius Kirk", 35},
		   e = {"Spock", 33},
		   f = {"John Sheridan", 37},
		   g = {"Delen", 39},
		   retval, cmp;
	char formattedout[30];
	int i; // used for formatted output
	int fcounter = 0;  // used to count failed tests.
		   
	// 2. Test isemptyq with NULL queue
	printf("%-23s","Test 001: isemptyqueue");
	printf("%-35s", "with NULL pointer ");
	if (!isemptyqueue(theqs[0])) {
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// 3a. Test enqueue with NULL queue and empty queue
	printf("\n%-23s","Test 002: enqueue");
	printf("%-35s", "with NULL pointer.  ");
	if (enqueue(theqs[0],a)) {
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// 3b. Test dequeue with NULL queue and empty queue
	printf("\n%-23s","Test 002: dequeue");
	printf("%-35s", "with NULL pointer.  ");
	retval = dequeue(theqs[0]);
	if (strlen(retval.name) > 0 || retval.age != 0) {
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// Now create the first queue for the next test of dequeue
	printf("\n%-23s","Test 003: createq");
	printf("%-35s", "create new queue");
	if ((theqs[0] = createq()) == NULL ) {
		printf("FAILED - returned NULL pointer\n");
		fcounter++;
	} else { 
		printf("--- passed\n");
	}
	// Now dequeue with an empty queue
	printf("\n%-23s","Test 004: dequeue");
	printf("%-35s", "empty queue returns empty struct");
	retval = dequeue(theqs[0]);
	if (strlen(retval.name) > 0 || retval.age != 0) {
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// 4. Test freeq with NULL queue and empty queuue
	printf("\n%-23s","Test 005: freeq");
	printf("%-35s", "with NULL pointer.  ");
	if (freeq(theqs[1])) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}
	
	printf("\n%-23s","Test 006: freeq");
	printf("%-35s", "with empty queue.  ");
	if (freeq(theqs[0])) { // remember theqs[0] was created, now free it
		printf("--- passed\n");
	} else {
		printf("FAILED  \n");
		fcounter++;
	}
	
	// 5. Test createq, put pointers in array
	for (int i=0; i < 3; i++) {
		sprintf(formattedout, "\nTest 00%d: createq", 7+i);
		printf("\n%-24s", formattedout); //"Test 007: createq");
		sprintf(formattedout, "create queue - %d", i);
		printf("%-35s", formattedout);
		if ((theqs[i] = createq()) == NULL) {
			printf("FAILED\n");
		fcounter++;
		} else {
			printf("--- passed\n");
		}
	}
	
	//6. Add three elements to first queue and dequeue only first element
	printf("\n%-23s","Test 010: enqueue");
	printf("Add %-20s - queue 0 ", a.name);
	if (enqueue(theqs[0], a)) {
		printf("--- passed \n");
	} else {
		printf("FAILED \n");
		fcounter++;
	}
	printf("\n%-23s","Test 011: enqueue");
	printf("Add %-20s - queue 0 ", b.name);
	if (enqueue(theqs[0], b)) {
		printf("--- passed \n");
	} else {
		printf("FAILED \n");
		fcounter++;
	}
	printf("\n%-23s","Test 012: enqueue");
	printf("Add %-20s - queue 0 ", c.name);
	if (enqueue(theqs[0], c)) {
		printf("--- passed \n");
	} else {
		printf("FAILED \n");
		fcounter++;
	}
	
	// Now dequeuing the first name
	printf("\n%-23s","Test 013: dequeue");
	sprintf(formattedout, "dequeue %20s   ", a.name);
	printf("%-35s", formattedout);
	retval = dequeue(theqs[0]);
	if (strncmp(retval.name, a.name, strlen(a.name)) != 0) {
		printf(" FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// 7. Check for isemptyqueue for first queue
	printf("\n%-23s","Test 014: isemptyqueue");
	printf("%-35s", "with non-empty queue");
	if (isemptyqueue(theqs[0])) {
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	// 8. Add two elements to second queue
	printf("\n%-23s","Test 015: enqueue");
	printf("Add %-20s - queue 1 ", d.name);
	if (enqueue(theqs[1], d)) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}
	printf("\n%-23s","Test 016: enqueue");
	printf("Add %-20s - queue 1 ", e.name);
	if (enqueue(theqs[1], e)) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}
	
	// 9. Add two elements to third queue
	printf("\n%-23s","Test 017: enqueue");
	printf("Add %-20s - queue 2 ", f.name);
	if (enqueue(theqs[2], f)) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}
	printf("\n%-23s","Test 018: enqueue");
	printf("Add %-20s - queue 2 ", g.name);
	if (enqueue(theqs[2], g)) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}
	
	//10. Check call to freeq for non-empty queue
	printf("\n%-23s","Test 019: freeq");
	printf("%-35s", "with non-empty queue");
	if (freeq(theqs[0])) { 
		printf("FAILED\n");
		fcounter++;
	} else {
		printf("--- passed\n");
	}
	
	//11. Use a loop to dequeue the two elements of queue 0, print values, free it
	i = 1;
	while(!isemptyqueue(theqs[0])) {
		sprintf(formattedout, "Test 0%d: dequeue", 21-i);
		printf("\n%-23s",formattedout); //"Test 018: dequeue");
		if (i) {
			cmp = b;
			i--; // next time through the loop do the else part
		} else {
			cmp = c;			
		}
		sprintf(formattedout, "dequeue %s", cmp.name);
		printf("%-35s", formattedout);
		retval = dequeue(theqs[0]);
		if (!strncmp(retval.name, cmp.name, strlen(cmp.name))) {
			printf("--- passed\n");
		} else {
			printf("FAILED\n");
		fcounter++;
		}
	}
	
	printf("\n%-23s","Test 022:: freeq");
	sprintf(formattedout, "queue %d, an empty queue", 0);
	printf("%-35s", formattedout);
	if (freeq(theqs[0])) {
		printf("--- passed\n");
	} else {
		printf("FAILED\n");
		fcounter++;
	}

	
	// 12. Empty and free queues 2 & 3
	for (int i = 1; i < 3; i++) { // empty the two remaining queues
		sprintf(formattedout, "Test 0%d: emptyq",22+i);
		printf("\n%-23s",formattedout);  //"Test 020: emptyq");
		sprintf(formattedout, "queue %d", i);
		printf("%-35s", formattedout);
		if (emptyq(theqs[i])) {
			printf("--- passed\n");
		} else {
			printf("FAILED\n");
		fcounter++;
		}
		printf("\n%-23s","Test 024: freeq");
		//sprintf(formattedout, "queue %d", i);
		printf("%-35s", formattedout);

		if (freeq(theqs[i])) {
			printf("--- passed\n");
		} else {
			printf("FAILED  queue\n");
			fcounter++;
		}
	}

	printf("\n************** Testing complete. *******************\n");
	printf("Total number of tests failed: %d\n\n", fcounter);
}
