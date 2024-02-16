# Author: Trevor Egbert
# Date: 7/2/2023
# Description: Parse MIPS instructions based on opcode and print message

.globl main, decode_instruction, process_instruction, print_hex_info			# Do not remove this line

# Data for the program goes here
.data
	process: .asciiz "\nNow processing instruction "
	newLine: .asciiz "\n"
	
	opcode_num: .asciiz "\tThe opcode value is: "

	# number of test cases
	CASES: .word 5
	# array of pointers (addresses) to the instructions
	instructions:	.word 0x01095020, 		# add $t2, $t0, $t1
					.word 0x1220002C,  		# beqz $s1, label
					.word 0x3C011001,		# lw $a0, label($s0)
					.word 0x24020004,		# li $v0, 4
					.word 0x08100002		# j label
	
	inst_0:		.asciiz "\tR-Type Instruction\n"
	inst_other:	.asciiz "\tUnsupported Instruction\n"
	inst_2_3:	.asciiz "\tUnconditional Jump\n"
	inst_4_5:	.asciiz "\tConditional Jump\n"

	# Note: You may use a table for the instruction strings
	inst_types: .word inst_0, inst_other, inst_2_3, inst_2_3, inst_4_5, inst_4_5

# Code goes here
.text

# Register used:
# $s0 opcode
# $s1 Instruction Type
main:
	# Task 1: Loop over the array of instructions 

loop_array:
	
	# 	Set registers and call: print_hex_info for process string
	mul $t0, $t1, 4 		# $t0 = $t1 * 4
	bgt $t0, 16, end_main		# $t0 > 16 jumps to end_main to exit loop
	
	la $a0, process			# $a0 = proccess .asciiz
	lw $a1, instructions($t0)	# $a1 = instruction[$t0]
	jal print_hex_info		# calls print_hex_info

	# 	Task 2: Set registers and call: decode_instruction 
	
	lw $a0, instructions($t0)	# $a0 = instruction[$t0]
	jal decode_instruction		# calls decode_instruction
	move $s0, $v0			# $s0 = $v0
	
	la $a0, opcode_num		# $a0 = opcode_num .asciiz
	move $a1, $s0			# $a1 = $s0
	jal print_hex_info		# calls print_hex_info
	
	
	# 	Set registers and call: print_hex_info for opcode_num string
	
	addi $t1, $t1, 1		# ++$t1 
	j loop_array		# end of loop
		
	
end_main:
	li $v0, 10		# 10 is the exit program syscall
	syscall			# execute call

## end of ca.asm

###############################################################
# Fetch instruction to correct procedure based on opcode for 
# instruction parsing.
#
# $a0 - input, 32-bit instruction to process
# $v0 - output, instruction opcode (bits 31-26) value (required)
# Uses $s0: for input parameter (required)
# Uses $s1: for opcode value (required)
decode_instruction:
	# Save registers to Stack
	subu $sp, $sp, 32 		# frame size = 32, just because...
	sw $ra, 28($sp) 		# preserve the Return Address.
	sw $fp, 24($sp) 		# preserve the Frame Pointer.
	sw $s0, 20($sp) 		# preserve $s0.
	sw $s1, 16($sp) 		# preserve $s1.
	addu $fp, $sp, 32 		# move Frame Pointer to base of frame.
	
	# Now your function begins here
	move $s0, $a0			# $s0 = $a0
	srl $s1, $s0, 26		# $s1 = $s0 >> 26
	
	# Task 3: Set/Values call procedure
	
	move $a0, $s1			# $a0 = $s1
	jal process_instruction		# calls process instruction
	
	# Set return value
	move $v0, $s1			# $v0 = $s1 to return opcode

end_decode_instruction:
	# Restore registers from Stack
	lw $ra, 28($sp) 		# restore the Return Address.
	lw $fp, 24($sp) 		# restore the Frame Pointer.
	lw $s0, 20($sp) 		# restore $s0.
	lw $s1, 16($sp) 		# restore $s1.
	addu $sp, $sp, 32 		# restore the Stack Pointer.
	
	jr $ra

###############################################################
# Process instruction: print instruction type
#
# $a0 - input, 32-bit instruction to process
# Uses $s0: for input parameter (required)
process_instruction:
	# Save registers to Stack
	subu $sp, $sp, 32 		# frame size = 32, just because...
	sw $ra, 28($sp) 		# preserve the Return Address.
	sw $fp, 24($sp) 		# preserve the Frame Pointer.
	sw $s0, 20($sp) 		# preserve $s0.
	addu $fp, $sp, 32 		# move Frame Pointer to base of frame.

	# Now your function begins here
	move $s0, $a0			# $s0 = $a0
	
	beqz $s0, case0			# $s0 == 0 jump to case0
	blt $s0, 2, defcase		# $s0 < 2 jump to defcase
	bgt $s0, 5, defcase		# $s0 > 5 jump to defcase
	ble $s0, 3, case2		# $s0 <= 3 jump to case2 
	ble $s0, 5, case4		# $s0 <= 5 jump to case 4
	
case0:
	lw $a0, inst_types($zero)	# $a0 = inst_type[0]
	li $v0, 4			# $v0 = print string
	syscall				# excutes print string
	j end_process_instruction	# jump to end_process_instruction

case2:
case3:

	li $t0, 8			# $t0 = 8
	nop				# buffer to finish writes to $t0
	lw $a0, inst_types($t0)		# $a0 = inst_type[$t0]
	li $v0, 4			# $v0 = print string
	syscall				# excutes print string
	j end_process_instruction	# jump to end_process_instruction

case4:
case5:

	li $t0, 16			# $t0 = 16
	nop				# buffer to finish writes to $t0
	lw $a0, inst_types($t0)		# $a0 = inst_type[$t0] 
	li $v0, 4			# $v0 = print string
	syscall				# excutes print string
	j end_process_instruction	# jump to end_process_instruction

defcase:
	li $t0, 4			# $t0 = 4
	nop				# buffer to finish writes to $t0
	lw $a0, inst_types($t0)		# $a0 = inst_type[$t0] 
	li $v0, 4			# $v0 = print string
	syscall				# excutes print string
	j end_process_instruction	# jump to end_process_instruction
	
		
end_process_instruction:
	# Restore registers from Stack
	lw $ra, 28($sp) 		# restore the Return Address.
	lw $fp, 24($sp) 		# restore the Frame Pointer.
	lw $s0, 20($sp) 		# restore $s0.
	addu $sp, $sp, 32 		# restore the Stack Pointer.
	
    jr $ra

###############################################################
# Print Message based on opcode type
#
# $a0 - Message to print
# $a1 - Value to print
# Uses $s0: address of string for $a0 (required)
# Uses $s1: value from $a1 (required)
print_hex_info:
	# Save registers to Stack
	subu $sp, $sp, 32 		# frame size = 32, just because...
	sw $ra, 28($sp) 		# preserve the Return Address.
	sw $fp, 24($sp) 		# preserve the Frame Pointer.
	sw $s0, 20($sp) 		# preserve $s0.
	sw $s1, 16($sp) 		# preserve $s1.
	#sw $s2, 12($sp) 		# preserve $s2.
	addu $fp, $sp, 32 		# move Frame Pointer to base of frame.

	# Now your function begins here
	move $s0, $a0
	move $s1, $a1
	
	li $v0, 4				# print message
	move $a0, $s0
	syscall
	
	li $v0, 34				# print address in hex value
	move $a0, $s1
	syscall
	
	li $v0, 4				# print message
	la $a0, newLine
	syscall

end_print_hex_info:
	# Restore registers from Stack
	lw $ra, 28($sp) 		# restore the Return Address.
	lw $fp, 24($sp) 		# restore the Frame Pointer.
	lw $s0, 20($sp) 		# restore $s0.
	lw $s1, 16($sp) 		# restore $s1.
	#lw $s2, 12($sp) 		# restore $s2.
	addu $sp, $sp, 32 		# restore the Stack Pointer.
	
    jr $ra
