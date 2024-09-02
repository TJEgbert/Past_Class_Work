#include "kernel/types.h"
#include "user/user.h"
#include "kernel/fcntl.h"


//main functions
int main(){
	char instr[512];
	
	// creates bob.txt if it doesn't exists
	int openfile = open("bob.txt", O_CREATE | O_RDWR);
	
	// Prints to command line
	printf("Hello my name is Trevor Egbert\n");
		
	// askes for a string and stores it
	printf("Please enter in a string to be saved: ");
	
	// Creates a buffer and store the user input
	gets(instr, 512);
	
	//write to bob.txt
	fprintf(openfile, "%s", instr);
		
	// closes bob.txt
	close(openfile);

	// Prints to command line
	printf("Thanks you for your input. Closing Program\n");
	
	//closes the program
	exit(0);
}
