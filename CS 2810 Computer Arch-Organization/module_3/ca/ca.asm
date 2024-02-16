# Author: Trevor Egbert
# Date: 6/18/2023
# Description: Takes in string of binary and print
# decimal form of the number

.globl binary_to_dec, main			# Do not remove this line

# Data for the program goes here
.data

prompt: .asciiz "Enter a binary number: "
results: .asciiz "Equivalent decimal number is: "

bin_num: .space 16

# Code goes here
.text
main:
	la $a0, prompt 		# loads prompt into $a0
	li $v0, 4		# gets printstring() load $v0
	syscall			# calls printstring()
	
	li $v0, 8		# loads getstring()
	la $a0, bin_num		# bin_num = getstring($a0)
	li $a1, 16		# letting the system know the max size of string
	syscall			# calls getstring()
	
	la $a0, bin_num		# loads the string in bin_num into $a0
	jal binary_to_dec	# calls function binary_to_dec()
	
	move $t0, $v0		# $t0 = $v0
	
	la $a0, results 	# loads prompt into $a0
	li $v0, 4		# gets printstring() load $v0
	syscall	
	
	move $a0, $t0		# $a0 = $t0
	li $v0, 1		# loads printint() into $v0
	syscall			# calls printint()
	
end_main:
	li $v0, 10		# 10 is the exit program syscall
	syscall			# execute call

## end of ca.asm

###############################################################
# Convert ascii string of binary digits to integer
#
# $a0 - input, pointer to null-terminated string of 1's and 0's (requried)
# $v0 - output, integer form of binary string (required)
# $t0 - ascii value of the char pointed to (optional)
# $t1 - integer value (0 or 1) of the char pointed to (optional)
# $t4 - accumlator holds the decimal value of the string

binary_to_dec:
	li $t4, 0		# $t4 = 0
	
loop:

	lb $t0,($a0)		# $t0 = bin_num[0]
	beq $t0, 0, end_binary_to_dec	# Checks to see if $t0 = the number 0 
	beq $t0, 0xa, end_binary_to_dec	# Checks to see if $t0 = 0xa (newline) 
	
	sll $t4, $t4, 1		# Shifts $t4 over 1 
	subi $t0, $t0, 0x30	# $t0 = $t0 - 0x30(0)
	
	or $t4, $t4, $t0	# $t4 = $t4 or $t0
	addi $a0, $a0, 1	# increment bin_num to the next character
	j loop			# jumps back to the top of the loop
	
	
	
end_binary_to_dec:
	move $v0, $t4		# $v0 = $t4
        jr $ra			# ends function binary_to_dec()
