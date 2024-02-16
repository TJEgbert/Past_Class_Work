# Author: Trevor Egbert
# Desc: Basic calculator of sharing costs

.macro print_str (%string)
	la $a0, %string
	li $v0, 4
	syscall
.end_macro

.data  # your "data"

prompt_cost: .asciiz "Enter total cost: "
prompt_people: .asciiz "Enter the number of people: "
output: .asciiz "Each individual owes: "

.text   # actual instructions
# Registers used:
# $v0 for syscall
# $a0 for string addreses to print
# $f1 for the total cost
# $f2 for the number of people
# $f3 for the cost_per_person

.globl main
main:
	
	print_str(prompt_cost)
	li $v0, 6
	syscall
	mov.s $f1, $f0
	
	print_str(prompt_people)
	li $v0, 6
	syscall
	mov.s $f2, $f0
	
	# Calculate cost per person
	# cost/people
	div.s $f3, $f1, $f2
	print_str(output)
	mov.s $f12, $f3
	li $v0, 2
	syscall

exit:
	# exit program
	li $v0, 10
	syscall
    