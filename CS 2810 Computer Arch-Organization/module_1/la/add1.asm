# Author: Trevor Egbert
# Desc: Adding some numbers and using registers
# Date: 5/20/2023


.data  # your "data"

.text   # actual instructions
.globl main
main:
	# 32 bits addresses
	# 32 registers = 2^5
	# Addition: z = x + y where x = 4 y = 7
	# $t0 = x, $t1 = y, $t2 = z
	li $t0, 4 # $t0 = 4
	li $t1, 7 # t1 = 7
	add $t2, $t0, $t1
	#print integer
	li $v0, 1
	move $a0, $t2  # $a0 = $t2
	syscall
	
exit:
    	# exit program
    	li $v0, 10
    	syscall
    