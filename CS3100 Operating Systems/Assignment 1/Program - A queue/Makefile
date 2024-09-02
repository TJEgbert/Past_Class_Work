# This is a Makefile for program 1
# each section lists the "target" to be made, the dependencies and
# on the next line, indented by a tab, the command to make the target
#

prog01: prog01.o queue.o
	gcc -std=c18 -o prog01 prog01.o queue.o
	
prog01.o: prog01.c queue.h
	gcc -std=c18 -c prog01.c
	
queue.o: queue.c queue.h
	gcc -std=c18 -c queue.c

clean:
	rm *.o prog01
