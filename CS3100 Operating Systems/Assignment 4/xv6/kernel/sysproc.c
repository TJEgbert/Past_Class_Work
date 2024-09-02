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

// Adds the passed in value to magic
uint64 sys_incMagic(void){
	int inc;
	argint(0, &inc);
	push_off();
	mycpu()->magic += inc;
	pop_off();
	return 0;
}
// Returns the magic
uint64 sys_getMagic(void){
	return mycpu()->magic;
}

// Prints out the name of the proccess
uint64 sys_getProcName(void){
	printf(myproc()->name);
	return 0;
}

// Changes the name of the process
uint64 sys_modProcName(void)
{
	char newname[40];
	argstr(0, newname, 40);
	push_off();
	safestrcpy(myproc()->name, newname, sizeof newname);
	pop_off();
	return 0;
}

