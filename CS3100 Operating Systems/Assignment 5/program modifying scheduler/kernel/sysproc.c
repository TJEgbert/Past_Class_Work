#include "types.h"
#include "riscv.h"
#include "defs.h"
#include "param.h"
#include "memlayout.h"
#include "spinlock.h"
#include "proc.h"

uint64  sys_exit(void) {
	int n;
	argint(0, &n);
	exit(n);
	return 0;  // not reached
}

uint64  sys_getpid(void) {
	return myproc()->pid;
}

uint64  sys_fork(void) {
	return fork();
}

uint64  sys_wait(void) {
	uint64 p;
	argaddr(0, &p);
	return wait(p);
}

uint64  sys_sbrk(void) {
	uint64 addr;
	int n;

	argint(0, &n);
	addr = myproc()->sz;
	if(growproc(n) < 0)
		return -1;
	return addr;
}

uint64  sys_sleep(void) {
	int n;
	uint ticks0;

	argint(0, &n);
	acquire(&tickslock);
	ticks0 = ticks;
	while(ticks - ticks0 < n) {
		if(killed(myproc())) {
			release(&tickslock);
			return -1;
		}
		sleep(&ticks, &tickslock);
	}
	release(&tickslock);
	return 0;
}

uint64  sys_kill(void) {
	int pid;

	argint(0, &pid);
	return kill(pid);
}

// return how many clock tick interrupts have occurred
// since start.
uint64  sys_uptime(void) {
	uint xticks;

	acquire(&tickslock);
	xticks = ticks;
	release(&tickslock);
	return xticks;
}

// Sets the priorty of process by the number passed in
uint64
sys_nice(void)
{
	int incr;
	// grabbing the processes
	int procpri = myproc()->priority;
	// getting the amount that the user want to icnreament
	argint(0, &incr);
	int newpri = procpri + incr;
	// Checks to make sure the new priority is within range
	if(newpri >= 0 && newpri < NUMPRI)
	{
		// Update and verfies that process priority updated correctly
		myproc()->priority = newpri;
		if(myproc()->priority == newpri){
			return 0;
		} 
	}
	printf("Nice failed to update");
	return -1;
}

// Returns the priorty of the process
uint64
sys_getpri(void) 
{
	return myproc()->priority;
}

// Sets the priorty of the process to the passed in value
uint64
sys_setpri(void)
{
	int newpri;
	argint(0, &newpri); // Gets the new value
	// Makes sure it isn't out of range of the priorty ques
	if(newpri >= 0 && newpri < NUMPRI)
	{
		// Sets the passed in value to priority.
		myproc()->priority = newpri;
		return 0;
	}
	
	printf("setpri failed");
	return -1;
}
