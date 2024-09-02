//child process for testing the round robin scheduler
#include "kernel/types.h"
#include "user/user.h"

int main(int argc, char* argv[]) {
	// NOTE:  argc is the number of separate strings on the command line
	// argv is an array of the strings from the command line
	int count = 0;    //The variable we use to count
	int i;            //Loop control varible
	int childid = 0;  // Used to store the child number OR the process id
	int chipri = 0;
	
	
	if(argc < 2){  // There is no number to count to, print an error 
		printf("Usage: forkchi num_to_count_to [child_number]\n");
		return -1;    // return non-zero for error
	}else if(argc > 2){ // the optional child number is provided
		childid = atoi(argv[2]); // convert the string to int	
	} else {
		childid = getpid();  // getptid() if no child number provided
	}
	count = atoi(argv[1]);   // get the number to count to as an integer
	
	for (i = 1; i <= count; i++){
		chipri = getpri();
		printf("Child: %d\tCount: %d\tPriority: %d\n ", childid, i, chipri);
	}
	return 0;  // return value on success
}
