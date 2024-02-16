# Author: Trevor Egbert
# Date: 7/23/2023
# Description: Takes in 16 or less strings and figures out the length,
# reverses it, checks if its a palindrome and how many letters
# needs to be deleted to make it so.
# Then it prints everything out to the user

.macro print_str(%string)
	la $a0, %string
	li $v0, 4
	syscall
.end_macro

.globl main			# Do not remove this line

# Data for the program goes here
.data
prompt: .asciiz  "Enter up to 16 strings (max length 31 characters) 1 per line.\nEnter a blank line to finishing inputing strings.\n"
ask_input: .asciiz "Next string: "

orig: .asciiz "\nOrig: "
length: .asciiz "\nLength: "
reverse: .asciiz "\nReverse: "
reverse_length: .asciiz "\nReverse Length: "
kpal: .asciiz "\nK-palindrome: "
#Arrays to store the user inputted strings and the reverse.
strings: .space 512  #16 strings of up to 32 characters each including the null character
reversed: .space 512 #16 strings of up to 32 characters each including the null character
# Create additional arrays here if needed
.align 2
array_int: .space 64

.align 2
reversed_array_int: .space 64

.align 2
palindrome: .space 64
.text
main:

	# Step 1: Read user-inputted strings
	move $s0, $zero			# index for string arrays
	move $s1, $zero			# index of integer arrays
	move $s2, $zero			# input_loop index
	move $s3, $zero                 # string length value
	
	move $s4, $zero
	print_str(prompt)		# Print prompt label
	
input_loop:

	print_str(ask_input)		#  askes for next string

	la $a0, strings($s0)		# loads the address to store the string into
	li $a1, 31			# max size of the string
	li $v0, 8			# get string
	syscall
	
	move $t1, $a0			# $t1 = $t2
	lb $t2, ($t1)			# loads the first letter in the string
	
	beq $t2, 0X0A, end_input_loop	# checks to see if its a new line character if so breaks out of the loop
	
	jal truncate			# calls truncate
	
	# Step 2: Calculate string lengths
	# $a0 still has the address of string array
	jal strlen			# calls strlen
	sw $v0, array_int($s1)		# stores the length of the string into array_int
	
	
	# Step 3: Reverse the strings
	
	# $a0 still has the address of string array
	la $a1, reversed($s0)		# loads the address of reversed array
	jal  reverse_string		# calls reverse_string
	
	# Step 4: Compute 2k k-palindrome value
	
	la $a0, reversed($s0)		# loads reversed address into $a0
	jal strlen			# calls strlen
	sw $v0, reversed_array_int($s1)	# stores the reversed string length
	
	la $a0, strings($s0)		# loads the address of string[$s0]
	la $a1, reversed($s0)		# loads the address of reversed[$s0]
	lw $a2, array_int($s1)		# loads the int at array_int[$s1]
	lw $a3, reversed_array_int($s1)	# loads the int at reversed_array_int[$s1]
	 
	jal k_palindrome		# calls k_palindrome
	sw $v0, palindrome($s1)		# stores the results into palindrome($s1)
	
	# Update all your indexes
	
	bge $s2, 15, end_input_loop
	addi $s0, $s0, 32
	addi $s2, $s2, 1
	addi $s1, $s1, 4
	
	addi $s4, $s4, 1
	
	j input_loop
	
end_input_loop:
	
	# Step 5: Print the results
	
	
	# Reset your indexes to print array information
	
	subi $s4, $s4, 1
	move $s0, $zero
	move $s2, $zero
	
	move $s1, $zero
	
print_loop:

	# loads the respective asciiz string and prints that
	# then it prints out the correlating result from there array
	print_str(orig)
	la $a0, strings($s0)
	li $v0, 4
	syscall
	
	print_str(length)
	lw $a0, array_int($s1)
	li $v0, 1
	syscall
	
	
	print_str(reverse)
	la $a0, reversed($s0)
	li $v0, 4
	syscall
	
	print_str(kpal)
	lw $t0, palindrome($s1)
	div $t0, $t0, 2
	move $a0, $t0
	li $v0, 1
	syscall
	
	# update indexes
	bge $s2, $s4, end_print_loop
	addi $s0, $s0, 32
	addi $s2, $s2, 1
	
	addi $s1, $s1, 4
	
	j print_loop
	
end_print_loop:
	
exit_main:
	li   $v0, 10			# 10 is the exit program syscall
	syscall				# execute call

###############################################################
# Calculates 2k where k is the minimum number of deletions required to
# turn a string into a palindrome.
#
# Argument parameters:
# $a0 - the address of the string
# $a1 - the address of the string in reverse
# $a2 - the length of the string
# $a3 - the length of the string in reverse
# $v0 - 2*k where k is the minimum number of deletions required to convert the
#       string in $a0 into a palindrome.
# $t0 - copy of address of the string
# $t1 - copy of address of reverse string
# $t2 - index for string
# $t3 - index for rev string
# $t4 - comparision for string
# $t5 - comparision for rev string
# $s5 - x
# $s6 - y
k_palindrome:				#(string X, string Y, int m, int n)
	
	
	# Possible Pseudocode.
	# Store registers 
	subi $sp, $sp, 12
	sw $ra, 12($sp)
	sw $s5, 8($sp)
	sw $s6, 4($sp)
	
	move $t0, $a0		# move the address of the org string into $t0
	move $t1, $a1		# move the address of the rev string into $t0
	
	
	# if either string is empty, return the sum of the lengths
	
	beqz $a2, if_zero
	beqz $a3, if_zero

	# ignore last characters of both strings if they are same
	# and recur for remaining characters
	
	move $t2, $a2		# $t2 = $a2 - 1
	move $t3, $a3		# $t3 = $a3 - 1
	
	add $t0, $t0, $t2	# $t0 = address of strings[$t2]
	add $t1, $t1, $t3	# $t1 = address of reversed[$t3]
	
	lbu $t4, ($t0)		# $t4 = strings[$t2]
	lbu $t5, ($t1)		# $t5 = reversed[$t3]
	
	beq $t4, $t5, if_equal	# $t4 = $t5
	
	# ignore last character from the first string and recur
	
	subi $a2, $a2, 1	# $a2 = $a2 - 1
	jal k_palindrome	# call k_palindrome
	move $s5, $v0		# adds the results into $s6
	
	
	# ignore last character from the second string and recur
	
	addi $a2, $a2, 1	# $a2 = a2 + 1
	subi $a3, $a3, 1	# $a3 = $a3 - 1
	jal k_palindrome	# call k_palindrome
	move $s6, $v0		# adds the results into $s5
	
	# return minimum of above two operations plus one
	
	blt $s5, $s6, og_string_less	# if $s5 < $s6
	
	blt $s6, $s5, rev_string_less	# if $s6 < $s5
	
if_zero:
	add $v0, $a2, $a3	# $v0 = $a2 + $a3
	j end_k_palindrome
	
if_equal:
	subi $a2, $a2, 1	# $a2 = $a2 - 1
	subi $a3, $a3, 1	# $a3 = $a3 - 1
	
	jal k_palindrome	# call k_palindrome
	j end_k_palindrome	

og_string_less:
	
	addi $v0, $s6, 1	# $v0 = $s6 + 1
	j end_k_palindrome

rev_string_less:

	addi $v0, $s5, 1	# $v0 = $s5 + 1
	j end_k_palindrome

end_k_palindrome:

	
	# Load registers 
	lw $ra, 12($sp)
	lw $s5, 8($sp)
	lw $s6, 4($sp)
	addi $sp, $sp, 12
	jr $ra
	
###############################################################
# Reverses a null-terminated string and stores the result at the specified location
# Assumes that the string is 31 characters or less and that the result Address
# has enough space for the entire string (including the null character).
# Creates a local array for storing the intermediate result.
#
# Argument parameters:
# $a0 - Address of the string
# $a1 - Address of the result

reverse_string:

	sub $sp, $sp, 36		# makes room in the stack
	sw $ra, 36($sp)			# save the $ra into stack
	move $t0, $a0			# $t0 = address of string
	addi $t1, $sp, 32		# stores the address of the stack
	sb $zero, ($t1)			# gets the first location in stack
rev_loop:

	lbu $t2, ($t0)			# $t2 = strings[$t0]
	beqz $t2, end_reverse_string	# if $t2 = 0
	sub $t1, $t1, 1			# $t1 = $t1 -	1
	sb $t2, ($t1)			# $t2 = bite at $t1
	
incr_loop:
	add $t0, $t0, 1			# $t0++
	j rev_loop
	
end_reverse_string:

	move $a0, $t1			# moved the stored copy into $a0
	# $a1 already has addresses
	jal strcpy			# calls strcpy
	lw $ra, 36($sp)			# loads back the $ra
	addi $t2, $sp, 36		# deallocate memory on the stack
	jr $ra				# return to main 
	
###############################################################
# Calcualtes the length of a null-terminated string
#
# Argument parameters:
# $a0 - Address of the string
# Return Value:
# $v0 - number of characters in the string (do not count the null character)
strlen:
	move $t0, $zero			# $t0 = 0
	move $t1, $a0			# $t1 = $a0

count_loop:

	lbu $t2, ($t1)			# $t2 = bite of current location of $t1
	beq $t2, 0, end_strlen		# $t2 == null character
	addi $t1, $t1, 1		# $t1++
	addi $t0, $t0, 1		# $t0++
	j count_loop

end_strlen:
	move $v0, $t0			# $v0 = $t0
	jr $ra				# return to main 

# Add additional procedures here if needed

###############################################################
# Turncate a string at the '\n' return length
# $a0 - address of string
# Returns
# $v0 - length of string
truncate:
	# allocate room on the stack and save registers
	subi $sp, $sp, 16
	sw $ra, 16($sp)
	sw $s0, 12($sp)
	sw $s1, 8($sp)
	sw $s2, 4($sp)
	sw $s3, 0($sp)
	
	move $t0, $zero			# $t0 = 0
	move $t1, $a0			# $t1 = $a0
	
trun_loop:
	lbu $t2,($t1)			# $t2 = current bite $t1	
	beq $t2, 0XA, end_truncate	# $t2 == 0xA
	beq $t2, 0, end_truncate	# $t2 == null character	
	addi $t0, $t0, 1		# $t0++
	addi $t1, $t1, 1		# $t1++
	j trun_loop

end_truncate:

	sb $zero, ($t1)			
	move $v0, $t0			# $v0 = $t0
	
	# loads registers back and move the stack back
	lw $ra, 16($sp)
	lw $s0, 12($sp)
	lw $s1, 8($sp)
	lw $s2, 4($sp)
	lw $s3, 0($sp)
	addi $sp, $sp, 16
	jr $ra
	

# copy a string from one location to another
# $a0 - address of string to copy
# $a1 - address of reversed
# Returns
# $v0 - length of string
strcpy:
	move $t0, $a0			# $t0 = address of string to copy
	move $t1, $a1			# $t1 = address of reversed
str_cloop:

	lbu $t2,($t0)			# $t2 = current byte $t0
	sb $t2, ($t1)			# $t1 current byte = $t2
	beq $t2, 0, end_strcpy		# $t2 = null character
	addi $t0, $t0, 1		# $t0++
	addi $t1, $t1, 1		# $t1++
	j str_cloop	
	
end_strcpy:
	jr $ra
## end of ca.asm
