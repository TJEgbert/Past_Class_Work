/*
 * This program creates a child process that it communicates
 */
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <sys/time.h>
#include <unistd.h>
#include <sys/wait.h>


int main(int argc, char * argv[]) {
	int cp[2];     // integer array for the pipes
	char ch;       // character read from the pipe
	int pid = 0;   // process id of this proccess
	char *temp;
	char *args[3]; // used to pass command line args for execv function
	int numofthreads;
	int threadcount = 0;
	struct timeval starttime, endtime;
	
	gettimeofday(&starttime, NULL);
	printf("Name: Trevor Egbert\n");
	if (argc<2) {  // not enough arguments, need output file name
		printf("Usage: readfile <filename>\n");
        return 1;
    }
    temp = argv[1];
	numofthreads = atoi(temp);
	
	if (pipe(cp) < 0) {
		printf("didn't work, couldn't not establish pipe.\n");
		return -1;
	}
	while(threadcount < numofthreads)
	{
		pid = fork();
		++threadcount;
		if (pid == 0) {
		close(1);       //close stdout
		dup2(cp[1], 1); //move stdout to pipe of cp[1]
		close(0);       //close stdin
		close(cp[0]);   //close pipe in 
		//note: All the arguments in exec have to be strings.
		// with an extra null string to end the args
		args[0] = "minmax";
		args[1] = argv[2];
		args[2] = (char *)0;
		execv("./minmax", args);  	
		}
	}
	
	close(cp[1]); //if you don't close this part of the pipe 
					  // then the while loop (three lines down)
					  // will never return
	while(read(cp[0], &ch, 1) == 1) {
			printf("%c",ch);
	}
		for (int id = 0; id < numofthreads; id++){
			wait(NULL);
		}
 
    gettimeofday(&endtime, NULL);
    double timetaken = (double) (endtime.tv_usec - starttime.tv_usec) / 1000000
					+ (double) (endtime.tv_sec - starttime.tv_sec);
	printf("The total time taken %f\n", timetaken);
	return 0;
}
