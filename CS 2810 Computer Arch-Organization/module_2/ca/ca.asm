# Author: Trevor Egbert
# Date: 5/28/2023
# Description: Guessing game user tries to guess the secret number


# Registers used:
	
#	$a0	- String address to print
#	$v0	- Syscall
#	$t0	- Store players guess
#	$t1	- Store secret number
#	$t2	- Stores players tries
#	$t3	- Array location
#	$t4	- Print array counter


.data  # Data used by the program

pick_num: .asciiz "Pick a number from 0 to 10: "
smaller_num: .asciiz "Pick a smaller number\n"
bigger_num: .asciiz "Try a bigger number\n"
correct: .asciiz "Thats.... Correct!\n"
win: .asciiz "You Win!!!"
lose: .asciiz "You Lose! The secret number is 7\n"
guessed: .asciiz "You guessed: "
space: .asciiz " "

secret_num: .word 7

.align 2
guesses: .space 40	# array guesses[5]

.text  # Instructions/code of the actual program

.globl main
main:
	lw $t1, secret_num	# Loads secret_num into $t1
	li $t2, 0		# $t2 = 0
	
gameplay_loop:
	
	beq $t2, 5, game_over	# if(t2 == 5)
	la $a0, pick_num	# loads pick_num into $a0
	li $v0, 4		# print(pick_num)
	syscall			# Runs syscall
	
	li $v0, 5		# loads player input into $v0
	syscall			# Runs syscall
	move $t0, $v0		# $t0 = $v0
	sll $t3,$t2, 2		# $t3 = $t2 * 4
	sw $t0, guesses($t3)	# gueese[$t3] = $t0
	
	add $t2, $t2, 1		# $t2++
	blt $t0, $t1, greater 	# if($t0 < $t1)
	bgt $t0, $t1, smaller	# if($t0 > $t1)
	beq $t0, $t1, win_screen# if($t0 == $t1)
	

game_over:

	la $a0, lose		# loads lose into $a0
	li $v0, 4		# print(lose)
	syscall			# Runs syscall
	
	la $a0, guessed		# loads guessed into $a0
	li $v0, 4		# print(guessed)
	syscall			# Runs syscall
	
	li $t4, 0		# $t4 = 0
	li $t3, 0		# $t3 = 0

print_loop:
	
	lw $t0, guesses($t3)	# $t0 = gueeses[$t3]
	move $a0, $t0		# $a0 = $t0
	li $v0, 1
	syscall			# Runs syscall
	add $t4, $t4, 1		# $t4++
	sll $t3, $t4, 2		# $t3 = $t4 * 4
	la $a0, space		# loads space into $a0
	li $v0, 4		# print(space)
	syscall			# Runs syscall
	bne $t4, 5, print_loop	# $t4 != 5
	
	j exit			# jump to exit
	
greater:	
	la $a0, bigger_num	# loads into $a0
	li $v0, 4		# print(bigger_num)
	syscall			# Runs syscall
	j gameplay_loop
	
smaller:	
	la $a0, smaller_num 	# loads into $a0
	li $v0, 4		# print(smaller_num)
	syscall			# Runs syscall
	j gameplay_loop
	
win_screen:
	la $a0, correct		# loads into $a0
	li $v0, 4		# print(correct)
	syscall			# Runs syscall
	la $a0, win		# loads into $a0
	li $v0, 4		# print(win)
	syscall			# Runs syscall
	j exit
	
exit:
	#exit the program using syscall 10 - exit
	li $v0, 10
	syscall
