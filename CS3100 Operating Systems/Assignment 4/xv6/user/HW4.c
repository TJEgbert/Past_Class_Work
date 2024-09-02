#include "kernel/types.h"
#include "user/user.h"
#include "kernel/fcntl.h"

int main(int argc, char *argv[]){
    int magic; // variable to store the magic number

    magic = getMagic();
    printf("current magic number is the following: %d\n",magic);

    incMagic(3);  // increment the magic number by 3

    magic = getMagic();
    printf("current magic number is the following: %d\n",magic);

    // now check the system calls for process name
    printf("current process name:");

    getProcName();  // getProcName should print the name to the screen

    printf("\n");  // still need a new line

    modProcName("newName");  // now change the proc name to newName

    printf("The process name is now: ");
    getProcName();
    printf("\n");

    magic = getMagic();
    printf("current magic number is the following: %d\n",magic);

    // Now change the magic number back to what is was by incrementing
    // by -3
    incMagic(-3);

    magic = getMagic();
    printf("current magic number is the following: %d\n",magic);

    return(0);
}
// Most of the time, I got results like this:.
// $ HW4
// current magic number is the following: 0
// current magic number is the following: 3
// current process name:HW4
// The process name is now: newName
// current magic number is the following: 3
// current magic number is the following: 0

// Then on occasion I would run into results like...
// current magic number is the following: 0
// current magic number is the following: 3
// current process name:HW4
// The process name is now: newName
// current magic number is the following: 0
// current magic number is the following: -3

// The only way we can run into a -3 is magic.
// had to be set back to 0. They are the are the only place we
// ran that code is in main.c. So at some point
// main.c gets run again. It gets run any time.
// start() is called. It looks like it deals
// with memory registers.

// So my thought is to what happens sometimes, HW4.c
// does not run completely on the CPU core and gets
// switched to a different one. This is leading to new
// registers and causes magic to get reset in the process.
 
