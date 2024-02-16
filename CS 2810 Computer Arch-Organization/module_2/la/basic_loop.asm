# Author: Trevor Egbert
# Desc: This program asks for a list on intergers from the user and verfies
#	that the integers are in ascending order
# Date:5/27/2023

# Used Registers
#	$a0	- String address to print
#	$v0	- Syscall and return value
#	$t0	- Store the user inputted value
#	$t1	- Loop counter
#	$t2	- Loop endpoint

.data  # your "data"

welcome_txt: .asciiz "Welcome to the sorted list verfier\n"
promt_txt: .asciiz "Enter a number(negative value to finish):"

.align 2
items: .space 40

.text   # actual instructions
.globl main
main:

	la $a0, welcome_txt	# print("Welcome...")
	li $v0, 4
	syscall
	
	
	li $t1, 0
	li $t2, 10
	# do
loop:	la $a0, promt_txt	# print("Enter a...")
	li $v0, 4
	syscall
	
	li $v0, 5		# read int
	syscall
	move $t0, $v0
	sw $t0, items		# Store user input into items
	add $t1, $t1, 1		# i++
	# while $t0 < $t2
	blt $t1, $t2, loop
	
exit:
	# exit program
	li $v0, 10
	syscall
    
