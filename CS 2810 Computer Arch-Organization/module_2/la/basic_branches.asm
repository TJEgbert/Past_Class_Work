# Author: Trevor Egbert
# Desc: This program asks for a list on intergers from the user and verfies
#	that the integers are in ascending order
# Date:5/27/2023

# Used Registers
#	$a0	- String address to print
#	$v0	- Syscall and return value
#	$t0	- Store the user inputted value

.data  # your "data"

welcome_txt: .asciiz "Welcome to the sorted list verfier\n"
promt_txt: .asciiz "Enter a number(negative value to finish):"
favorite_txt: .asciiz "Thats my favorite number\n"
plain_txt: .asciiz "Thats a plain old number\n"
negative_txt: .asciiz "That is a negative number\n"

fav_num: .word 21

.align 2
items: .space 40

.text   # actual instructions
.globl main
main:

	la $a0, welcome_txt	# print("Welcome...")
	li $v0, 4
	syscall
	
	la $a0, promt_txt	# print("Enter a...")
	li $v0, 4
	syscall
	
	li $v0, 5		# read int
	syscall
	move $t0, $v0
	sw $t0, items		# Store user input into items
	
	lw $t1, fav_num		# Load fav_num into $t1
	bne $t0, $t1, elseif	# if t$0 == fav_num
	la $a0, favorite_txt	#	print That's my...
	li $v0, 4
	syscall
	j endif
elseif:	bgez $t0, else		# else if $t0 < 0:
	la $a0, negative_txt	#	print That is a negative number
	li $v0, 4
	syscall
	j endif
else:
	la $a0, plain_txt	# else:
	li, $v0, 4		# 	print That is just a plain old number
	syscall
	
endif:	#... more code
	
	
	

exit:
	# exit program
	li $v0, 10
	syscall
    
