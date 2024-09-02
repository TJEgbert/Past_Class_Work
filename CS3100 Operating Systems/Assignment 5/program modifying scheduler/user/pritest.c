// pritest
//Calls child pritest with number and (optional) child number
// It requires the number to count to and an optional number of children 
// as arguments
#include "kernel/types.h"
#include "user/user.h"
#include "kernel/param.h"

int main(int argc, char* argv[]){
	int i;             // Loop control variable
	int numchild = 2;  // Number of children to create
	char *args[5];
	int pid;           // Process id returned from fork
	char childnum[10]; // String used as an arg for exec

	
	if (argc < 2){
		printf("Usage: pritest number_to_count_to [number_of_children]\n");
		return 0; // return zero if printing usage
	} else {
		args[1] = argv[1];  // just pass the number to count to as arg
		if (argc >= 3) { // if there are going to be more than two children
			numchild = atoi(argv[2]);
			}
	}
	args[0] = "prichi";  // first arg is the name of the program
	args[2] = childnum;   // this is an optional child number argument
                          // if you don't want to use it, make this the same 
                          // as args[3], it contains a pointer to a string
	args[3] = (char *) 0; // says this is the end of the command line
	//Now we create the child procs and exec them
	for (i=0; i<numchild; i++){
		pid = fork();
		// Updates the priority of child process between 0 and 4
		setpri(i% NUMPRI);
		if(i == 0){
			nice(3);
		}
	
		if (pid == 0){    // a pid of zero indicates you are in the child
					// Sets the process priorty so the child can inherit			
			strcpy(childnum, itoa(i)); // get the child num
			exec("prichi", args);
		}
	}
	// After we fork all the children, wait for them so they don't become
	//  ZOMBIES!!!
	for (i=0; i<numchild; i++) {
		wait(0);
	}
	return 0;
}
