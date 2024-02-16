# Author: Trevor Egbert
# Desc: Load a value from memory and store it back in memory
# Date: 5/20/2023


.data  # your "data"
num1: .word 24
dest1: .word 0 # a place to store the number

.text   # actual instructions
.globl main
main:
	# load number from memory
	lw $t0,num1 # $t0 = num1
	# print $t0
	move $a0, $t0
	li $v0, 1
	syscall
	#store valye in memory
	sw $t0, dest1 # dest1 = $t0

exit:
    # exit program
    li $v0, 10
    syscall
    