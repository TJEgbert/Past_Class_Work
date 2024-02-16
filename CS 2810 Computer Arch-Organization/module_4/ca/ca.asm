# Author: Trevor Egbert
# Date: 6/25/2023
# Description: Takes a user input stores it in IEEE 754 single-perceion float register.
# Then parses it and extracts the sign exponent significand 
# and prints the truncated integer representation.

# Print_string marco takes in a asciiz string and prints it out
.macro print_str (%string)
	la $a0, %string			# stores the string that passed in $a0
	li $v0, 4			# loads printsString() into $v0
	syscall				# calls printString()
.end_macro

.globl parse_sign, parse_exponent, parse_significand, calc_truncated_uint, main			# Do not remove this line

# Data for the program goes here
.data

prompt: .asciiz "Enter an IEEE 754 floating point number in decimal form: "
sign: .asciiz "The sign is: "
exponent: .asciiz "\nThe exponent is: "
significand: .asciiz "\nThe significand bits as an integer is: "
truncated: .asciiz "\nThe truncated unsigned interger value is: "
signed_truncated: .asciiz "\nThe truncated integer is: "

.text 				# Code goes here

# Registers used:
# $v0 for syscall
# $a0 for string addreses to print
# $a0 to pass in argument in for procdures
# $f1 to store the user input
# $s0 holds the float to pass in
# $s1 the sign of the float
# $s2 the exponent of the float
# $s3 the mantissa of the float
# $s4 truncated version of float
main:
	
	# Step 1: Read a floating point number
	
	print_str(prompt)		# prints prompt
	li $v0, 6			# loads read float syscall into $v0
	syscall				# calls read float
	
	mov.s $f1, $f0			# $f1 = $f0 (user entered float)
	mfc1 $s0, $f1			# $s0 = $f1
	
	# Step 2: setup and call parse_sign

	move $a0, $s0			# $a0 = $s0 (to be used in procdures)
	jal parse_sign			# calls parse_sign($a0)
	move $s1, $v0			# $s1 = $v0(results from parse_sign)
	
	print_str(sign)			# prints sign
	move $a0, $s1			# $a0 = $s1 (to print the character)
	li $v0,11			# loads print character syscall into $v0
	syscall				# calls print character
	
	# Step 3: setup and call parse_exponent
	
	move $a0, $s0			# $a0 = $s0 (to be used in procdures)
	jal parse_exponent		# calls parse_exponent($a0)
	move $s2, $v0			# $s2 = $v0(results from parse_sign)
	
	print_str(exponent)		# prints exponent
	move $a0, $s2			# $a0 = $s2 (to print exponent)
	li $v0, 1			# loads print integer syscall int0 $v0
	syscall				# calls print integer

	# Step 4: setup and call parse_significand
	
	move $a0, $s0			# $a0 = $s0 (to be used in procdures)
	jal parse_significand		# calls parse_significand($a0)
	move $s3, $v0			# $s3 = $v0(results from parse_significand)
	
	print_str(significand)		# prints exponent
	move $a0, $s3			# $a0 = $s3 (to print significand)
	li $v0, 35			# loads print Int In Binrary syscall $v0
	syscall				# calls print Int In Binrary
	
	# Step 5: setup and call calc_truncated_uint
	
	move $a0, $s2			# $a0 = $s2 (to be used in procdures)
	move $a1, $s3			# $a1 = $s3 (to be used in procdures)
	jal calc_truncated_uint		# calls calc_truncated_uint($a0, $a1)
	move $s4, $v0			# $s4 = $v0 (results from calc_truncated_uint)
	
	print_str(truncated)		# prints truncated
	move $a0, $s4			# $a0 = $s4 (to print truncated integer)
	li $v0, 36			# loads print integer as unsigned syscall into $v0
	syscall				# calls print integer as unsigned
	

	# Step 6: If you haven't been printing values along the way
	# Print out the appropriate output here.
	
	print_str(signed_truncated)	# prints signed_truncated
	move $a0, $s1			# $a0 = $s1 (to print the sign)
	li $v0,11			# loads print character syscall into $v0
	syscall				# calls print character
	
	move $a0, $s4			# $a0 = $s4 (to print truncated integer)
	li $v0, 36			# loads print integer as unsigned syscall into $v0
	syscall				# calls print integer as unsigned
	
exit_main:
	li $v0, 10		# 10 is the exit program syscall
	syscall			# execute call
	

###############################################################
# Gets the sign from an IEEE 754 single precision representation
#
# Argument parameters:
# $a0 - IEEE 754 single precision floating point number (required)
# Return Value:
# $v0 - ascii char for sign (+ or -) (required)
# Other Registers used:
# $t0 to store $a0 and used for math
parse_sign:

	move $t0, $a0			# $t0 = $a0
	srl $t0, $t0, 31		# shift the bits to the right 31 bits to get the sign
	
	beqz $t0, if_zero		# if(bit == 0)branch to if_zero
	li $v0, 0x2D			# $v0 = -

end_parse_sign:
	jr $ra				# returns back to main:

if_zero:

	li $v0, 0x2B			# $v0 = +
	j end_parse_sign		# jumps to end_parse_sign

###############################################################
# Gets the exponent from an IEEE 754 single precision representation
#
# Argument parameters:
# $a0 - IEEE 754 single precision floating point number
# Return Value:
# $v0 - signed integer of exponent value with bias removed
# Other Registers used:
# $t0 to store $a0 and used for math
	
parse_exponent:

	move $t0, $a0			# $t0 = $a0
	srl $t0, $t0, 23		# shift bits to the right 23 bits
	andi $t0, $t0, 255		# AND 255 to isolate the exponent
	subi $t0, $t0, 127		# subtracts 127 for remove the bias
	move $v0, $t0			# $v0 = $t0
	
end_parse_exponent:

	jr $ra				# returns back to main:

###############################################################
# Gets the significand from an IEEE 754 single precision representation
#
# Argument parameters:
# $a0 - IEEE 754 single precision floating point number
# Return Value:
# $v0 - unsigned int whose low order 24 bits represent the significand of the IEEE 754 number
# Other Registers used:
# $t0 to store $a0 and used for math

parse_significand:
	
	move $t0, $a0			# $t0 = $a0
	andi $t0, $t0,0xFFFFFF		# AND with 0xFFFFFF to isolate the significand
	ori $t0, $t0, 0x800000		# Inserts a 1 bit 24
	move $v0, $t0			# $v0 = $t0
	
end_parse_significand:
        jr $ra				# returns back to main:


###############################################################
# Calculates the truncated unsigned int representation of an
# IEEE 754 single precision floating point number based on the
# unbiased exponent and the significand
#
# Argument parameters:
# $a0 - singed integer representing unbiased exponent of IEEE 754 single precision floating point number
# $a1 - unsigned int whose low order 24 bits match the significand of the IEEE 754 number
# Return value: 
# $v0 - truncated unsigned integer
# Other Registers used:
# $t0 to store $a0 and used in producer
# $t1 to store $a1 and used in producer
# $t2 number of shifts
# $t3 untruncated intger
# $t4 23 bit holder


calc_truncated_uint:


	move $t0, $a0			# $t0 = $a0
	move $t1, $a1			# $t1 = $a0
	li $t4, 23			# $t4 = 23
	
			
	bgt $t0, 31, greater_than_31	# if($t0 > 31) branch to greater_than_31
	blt $t0, 0, less_than_0 	# if($t0 < 0) branch to less_than_zero
	
	bgt $t0, 23, shift_left		# if($t0 > 23) branch to shift_left
	blt $t0, 23, shift_right	# if($t0 > 23) branch to shift_right
	

end_calc_truncated_uint:
	jr $ra				# returns back to main:

greater_than_31:

	li $v0, 0xffffffff		# $v0 = 0xffffffff
	j end_calc_truncated_uint	# jump to end_calc_truncated_uint
	
less_than_0:
	
	li $v0, 0			# $v0 = 0
	j end_calc_truncated_uint	# jump to end_calc_truncated_uint
	
shift_left:

	sub $t2, $t0, $t4		# $t2 = $t0 - $t4
	sllv $t3, $t1, $t2		# $t3 = $t1 << $t2 bits 
	move $v0, $t3			# $v0 = $t3
	j end_calc_truncated_uint	# jump to end_calc_truncated_uint

shift_right:
	
	sub $t2, $t4, $t0		# $t2 = $t4 - $t0
	srlv $t3, $t1, $t2		# $t3 = $t1 >> $t2 bits
	move $v0, $t3			# $v0 = $t3
	j end_calc_truncated_uint	# jump to end_calc_truncated_uint
	
## end of ca.asm
