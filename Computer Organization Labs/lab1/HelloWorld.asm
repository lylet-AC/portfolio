.data
hello:   .ascii     "Hello world!\n" #declares a asciiz variable with the label of hello.
.text
la $a0, hello #loads data from the 'hello' label into this variable
li $v0, 4 #inserts a 4 into the $v0 variable, which is used by syscall to do something, in this case it outputs a string
syscall
li $v0, 10 #inserts a 10, syscall sees this and exits the program.
syscall
