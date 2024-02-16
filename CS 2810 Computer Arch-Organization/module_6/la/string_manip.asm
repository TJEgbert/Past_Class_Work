# Author: Trevor Egbert
# Desc:
# Date:


.data  # your "data"

prompt: .asciiz "Please enter a string: "
output_reversed: .asciiz "\nReversed: "
result: .space 64
rev_result: .space 64

.text   # actual instructions
.globl main
main:

	# Call get_input
	la $a0, prompt
	la $a1, result
	li $a2, 64
	jal get_input
	# print truncated string
	move $s0, $v0
	la $a0, result
	li $v0, 4
	syscall
	# print length
	move $a0, $s0
	li $v0, 1
	syscall
	la $a0, result
	la $a1, rev_result
	jal numbers_reversed
	# priunt nubmer reversed string
	la $a0, rev_result
	li $v0, 4
	syscall
	la $a0, output_reversed
	li $v0, 4
	syscall
	la $a0, result
	jal print_reversed
	
exit:
	# exit the program
	li $v0, 10
	syscall
    
# get_input procedure
# $a0 - address of prompt to print
# $a1 - address to store string
# $a2 - max string length
# Returns
# $v0 - length of string
get_input:
	subi $sp, $sp, 4
	sw $ra, 0($sp)
	li $v0, 4
	syscall
	move $a0, $a1
	move $a1, $a2
	li $v0, 8
	syscall
	# $a0 already has address
	jal strtrunc
	
end_get_input:
	lw $ra, 0($sp)
	add $sp, $sp, 4
	jr $ra
	
# turncate a string at the '\n' return length
# $a0 - address of string
# Returns
# $v0 - length of string
strtrunc:
	move $t0, $zero
	move $t1, $a0
str_loop:
	lbu $t2,($t1)
	beq $t2, 0XA, end_strtrunc
	beq $t2, 0, end_strtrunc
	addi $t0, $t0, 1
	addi $t1, $t1, 1
	j str_loop	
	
end_strtrunc:
	sb $zero, ($t1)
	move $v0, $t0
	jr $ra
	
# Reverse the numbers in a string and strip out all other characters
# $a0 - string to reverse
# $a1 - location to write the result
numbers_reversed:
	sub $sp, $sp, 68
	sw $ra, 64($sp)
	move $t0, $a0
	addi $t1, $sp, 63
	sb $zero, ($t1)
num_loop:
	lbu $t2, ($t0)
	beqz $t2, end_numbers_reversed
	blt $t2, 0x30, incr
	bgt $t2, 0x39, incr
	sub $t1, $t1, 1
	sb $t2, ($t1)
incr:
	add $t0, $t0, 1
	j num_loop
	
end_numbers_reversed:
	move $a0, $t1
	# $a1 already has addresses
	jal strcopy
	lw $ra, 64($sp)
	jr $ra
	
# copy a string from one location to another
# $a0 - address orig string
# $a1 - address of new location
# Returns
# $v0 - length of string
strcopy:
	move $t0, $a0
	move $t1, $a1
str_cloop:
	lbu $t2,($t0)
	sb $t2, ($t1)
	beq $t2, 0, end_strcopy
	addi $t0, $t0, 1
	addi $t1, $t1, 1
	j str_cloop	
	
end_strcopy:
	jr $ra

# Print a string in reverse recusively
# $a0 - address of the string to print
print_reversed:
	subi $sp, $sp, 8
	sw $ra, 4($sp)
	sw $s0, ($sp)
	move $s0, $a0
	lbu $t0, ($s0)
	beqz $t0, end_print_reversed
	addi $a0, $s0, 1
	jal print_reversed
	lbu $a0, ($s0)
	li $v0, 11
	syscall
	
end_print_reversed:
	lw $ra, 4($sp)
	lw, $s0, ($sp)
	addi $sp, $sp, 8
	jr $ra
	
	
	
	