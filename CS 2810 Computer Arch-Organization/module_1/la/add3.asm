# Author: Trevor Egbert
# Desc: Add three numbers from memory and print the results
# Date: 5/20/2023


.data  # your "data"
out: .asciiz "The Result is: "
result: .word 0 		# results
nums: .word -7, 20, -5		# number to add

.text   # actual instructions
.globl main
main:
	#rprint th initial string
	li $v0, 4
	la $a0, out
	syscall
	
	# load three numbers into registers
	la $t0, nums		# t0 = nums
	lw $t1, 0($t0)		# t1 = nums[0]
	lw $t2, 4($t0)		# t2 = nums[1]
	lw $t3, 8($t0)		# t3 = nums[1]
	
	# Add them up
	add $a0, $t1, $t2	# $a0 = $t1 + $t2
	add $a0, $a0, $t3	# $a0 = $a0 + $t3
	
	# Save the results
	sw $a0, result
	
	# Print the results
	li $v0, 1
	syscall
exit:
    	# exit program
    	li $v0, 10
    	syscall
    