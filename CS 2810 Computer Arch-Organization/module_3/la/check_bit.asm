# Author: Trevor Egbert
# Desc: Play with bitwise operations


.globl main	# name of "functions"


.data  # your "data"

.text   # actual instructions

main:

li $t0, 0xB		# 1111 1011
			# 0110 0000 = 0x60
# Pseudocode
# Is bit 5,6 (index noation) on $t0?
andi $t1, $t0, 0x30 	
srl $t2, $t1, 5

li $v0, 1		# print interget
move $a0, $t2
syscall

andi $t1, $t0, 0x60 	
srl $t2, $t1, 5

li $v0, 1		# print interget
move $a0, $t2
syscall

end_main:
	# exit program
	li $v0, 10
	syscall
    
