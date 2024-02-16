# Author: Trevor Egbert
# Desc:
# Date:


.data  # your "data"

.text   # actual instructions
.globl main
main:


exit:
	# exit program
	li $v0, 10
	syscall
    