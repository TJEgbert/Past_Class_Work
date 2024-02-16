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
# $t0 for the int number of people
# $t1 for the int cost per person

.globl main
main:
	
	print_str(prompt_cost)
	li $v0, 6			# Read float cost
	syscall
	mov.s $f1, $f0
	
	print_str(prompt_people)
	li $v0, 5			# Read int people
	syscall
	move $t0, $v0
	
	mtc1 $t0, $f2			# Convert in to float
	cvt.s.w $f2, $f2
	
	# Calculate cost per person
	# cost/people
	div.s $f3, $f1, $f2
	ceil.w.s $f3, $f3		# Round cost per person 
	mfc1 $t1, $f3			# Move to Intger
	print_str(output)
	move $a0, $t1
	li $v0, 1
	syscall

exit:
	# exit program
	li $v0, 10
	syscall
    