.data  #data declaration

prompt: .asciiz "\nPlease Enter an Integer: "
end: .asciiz "Your answer is "

.text #instructions

li $v0, 4  #set syscall to 4 to output a string
la $a0, prompt #load adress of string to output into $a0 (prompt)
syscall

li $v0, 5 #set syscall to 5 to read an integer read integer is stored in $v0
syscall
move $t1, $v0  #move read in contents to $t1

################################################################# First num read

li $v0, 4  #set syscall to 4 to output a string
la $a0, prompt #load adress of string to output into $a0 (prompt)
syscall

li $v0, 5 #set syscall to 5 to read an integer
syscall
move $t2, $v0  #move read in contents to $t2

mult $t1, $t2 #multiply $t1 and $t2.  
mflo $t0 #The result is placed into $t0

################################################################ Second num read and multiplied

li $v0, 4 #set syscall to 4 to output a string
la $a0, end #loads adress of ending prompt
syscall

move $a0, $t0 #moves result of multiplication to $ao where it can be used to be printed
li $v0, 1  #loads 1 into $v0 so it outputs the resulting number 
syscall

li $v0, 10 #10 is exit code used by syscall
syscall

################################################################ outputs product and exits



