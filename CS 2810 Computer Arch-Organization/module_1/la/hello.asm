# Author: Trevor Egbert
# My first program: Hello world


.data  # your "data"
hello: .asciiz "Hello Waldo" #sting hello = "Hello Waldo"

.text   # actual instructions

main:
    # print string
    li $v0, 4
    la $a0, hello
    syscall

    # exit program
    li $v0, 10
    syscall
    