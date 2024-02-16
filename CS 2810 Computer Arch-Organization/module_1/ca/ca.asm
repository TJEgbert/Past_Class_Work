# Author: Trevor Egbert
# Date: 5/21/2023
# Description: A program that adds two numbers together

# Registers used:
#	$v0		- syscall parameter and return value
#	$a0		- syscall paremeter: the string to print
#   $t0 	- used to hold the first number.
#   $t1 	- used to hold the second number.
#   $t2 	- used to hold the sum of $t0 and $t1.
#   $t3		- used to hold the sum of $t2 and 20

# Data for the program goes here
.data

	name: .asciiz "Trevor Egbert\n"
	hw: .asciiz "Program Assigment #1\n"
	info: .asciiz "A program that adds two numbers\n"

	question1: .asciiz "Please enter a number:\n"
	sum: .asciiz "\nThe sum is: "
	
	sum2: .asciiz "\nThe new sum after adding 20 is: "
# Code goes here
.text
main:

	# Task 1	
	la $a0, name		# load address of name string into $a0
	li $v0, 4		# 4 = print_string() syscall
	syscall			# excute call
	
	la $a0, hw		# load address of hw string into $a0
	li $v0, 4		# 4 = print_string() syscall
	syscall			# excute call

	la $a0, info		# load addres of info string into $a0
	li $v0, 4		# 4 = print_string() syscall
	syscall			# excute call
	
	# Task 2
	la $a0, question1 	# load the address of q1 string into $a0
	li $v0, 4		# 4 = print_string() syscall
	syscall			#excute call
	
	li $v0, 5		# load syscall read_int() into $v0
	syscall			# excute call
	move $t0, $v0		# move the number read into $t0
	
	li $v0, 4		# 4 = print_string() syscall
	syscall			#excute call
	
	li $v0, 5 		# load syscall read_int() into $v0
	syscall			# excute call
	move $t1, $v0		# move the number read into $t1
	
	add $t2, $t0, $t1	# $t2 = $t0 + $t1
	la $a0, sum		# load the address of sum string into $a0
	li $v0, 4		# 4 = print_string() syscall
	syscall			# excute call
	
	move $a0, $t2		# move the number to print into $a0
	li $v0, 1		# load the syscall print_int() $v0
	syscall			# excute call
	
	# Task 3
	addi $t3, $t2, 20	# $t3 = $t2 + 20
	la $a0, sum2		# loads the address of sum2 string into
	li $v0, 4		# 4 = print_string() syscall 
	syscall			# excute call
	
	move $a0, $t3		# move the number to print into $a0
	li $v0, 1		# loads the syscall print_int() $v0
	syscall			# excute call
	
	li $v0, 10		# 10 is the exit program syscall
	syscall			# execute call

## end of ca.asm
