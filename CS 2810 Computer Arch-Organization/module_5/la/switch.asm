# Author: Trevor Egbert
# Desc: Print out the properties of a one digit number.
#	Example of a switch block
# Date: 7/1/2023

# Pseudocode:
#
#	print(prompt)
#	n = readInt()
#
#	switch (n) {
#	case 0:
#		print("n is zero\n")
#		break
#	case 4:
#		print("n is even\n")
#		break
# 	case 1:
# 	case 9:
#		print("n is square\n")
#		break
#	case 2:
#		print("n is even\n")
#	case 3:
#	case 5:
#	case 7:
#		print("n is prime\n")
#		break
#	case 6:
#	case 8:
#		print("n is even\n")
#		break
#	default:
#		print("out of range\n")
#	}
# Registers: n => $t0

.data  # your "data"

prompt: .asciiz"Enter a one digit number: "
zero: .asciiz"n is zero\n"
even: .asciiz"n is even\n"
square: .asciiz"n is square\n"
prime: .asciiz"n is prime\n"
bad: .asciiz"out fo range\n"

# switch block jump table
#   n or index 0*4   1*4    2*4   3*4  
switch: .word case0, case1, case2, case3, case4, case5, case6, case7, case8, case9

.text   # actual instructions
.globl main
main:
	li $v0, 4	# print(prompt
	la $a0, prompt
	syscall
	
	li $v0, 5	# n = readInt
	syscall
	move $t0, $v0

	# switch(n)
	li $v0, 4		# set for future calls
	
	blt $t0, 0, default	# if(n < 0, goto default)
	bgt $t0, 9, default	# if(n < 0, goto default)
	
	mul $t1, $t0, 4		# temp = n *4
	lw $t1, switch($t1)	# temp = swithc(temp)
	jr $t1			# jump to address in temp
case0:
	la $a0, zero
	syscall
	j exit
case4:
	la $a0, even
	syscall
	j exit
case1:
case9:
	la $a0, square
	syscall
	j exit

case2:
	la $a0, even
	syscall
	j exit
case3:
case5:
case7:
	la $a0, prime
	syscall
	j exit

case6:
case8:
	la $a0, even
	syscall
	j exit

default:
	la $a0, bad
	syscall

exit:
	# exit program
	li $v0, 10
	syscall
    
