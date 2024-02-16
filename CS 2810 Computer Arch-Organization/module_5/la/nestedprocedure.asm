# Author: Trevor Egbert
# Desc: Learn about nested procedures
# Date:7/1/2023


.data  # your "data"

hello: .asciiz "Inside Hello Procedure\n"
hola: .asciiz "Inside Hola Procedure\n"
name: .asciiz "Hi Pedro\n"
done: .asciiz "Have a nice day"

.text   # actual instructions

	la $a0, name
	jal hello_proc
	
	li $v0, 4
	la $a0, done
	syscall

exit:
	# exit program
	li $v0, 10
	syscall
    

##################################################################################
# Print Hello string + name string

# $a0 - input, name string
# Uses $s0: for input prarameter (required

hello_proc:
	# save registers to stack
	subu $sp, $sp, 32	# frame size = 32 (begin allocation)
	sw $ra, 28($sp)		# preserve the return address (required)
	sw $fp, 24($sp)		# preserve the frame pointer (required)
	sw $s0, 20($sp)		# preserve $s0 (if needed)
	#sw $s0, 16($sp)		# preserve $s0 (if needed)
	addu $fp, $sp, 32	# move frame pointer to base frame (end allocation)
	
	
	# Set return value your function start here
	move $s0, $a0
	
	li $v0, 4	# print(hello)
	la $a0, hello
	syscall
	
	li $v0, 4	# print(name)
	move $a0, $s0
	syscall
	
	# call hola procedure
	move $a0, $s0	# copy address of input paremetter
	jal hola_proc
	
end_hello_proc:
	# restore registers from stack
	lw $ra, 28($sp)		# restore the return address (required)
	lw $fp, 24($sp)		# restore the frame pointer (required)
	lw $s0, 20($sp)		# restore $s0 (if needed)
	#sw $s0, 16($sp)		# preserve $s0 (if needed)
	addu $sp, $sp, 32	# move frame pointer to base frame (end allocation)
	# return from procedure
	jr $ra
	
##################################################################################
# Print Hola string + name string

# $a0 - input, name string
# Uses $s0: for input prarameter (required

hola_proc:
	# save registers to stack
	subu $sp, $sp, 32	# frame size = 32 (begin allocation)
	sw $ra, 28($sp)		# preserve the return address (required)
	sw $fp, 24($sp)		# preserve the frame pointer (required)
	sw $s0, 20($sp)		# preserve $s0 (if needed)
	#sw $s0, 16($sp)		# preserve $s0 (if needed)
	addu $fp, $sp, 32	# move frame pointer to base frame (end allocation)
	# Set return value
	move $s0, $a0
	
	li $v0, 4	# print(hello)
	la $a0, hola
	syscall
	
	li $v0, 4	# print(name)
	move $a0, $s0
	syscall
	
end_hola_proc:
	# restore registers from stack
	lw $ra, 28($sp)		# restore the return address (required)
	lw $fp, 24($sp)		# restore the frame pointer (required)
	lw $s0, 20($sp)		# restore $s0 (if needed)
	#sw $s0, 16($sp)		# preserve $s0 (if needed)
	addu $sp, $sp, 32	# move frame pointer to base frame (end allocation)
	jr $ra
	
	
	