#Goal: make user guess computer's number
.data
	
	str1: .asciiz "\nThe computer has guessed a number between 0-50.  Take a Guess: "
	str2: .asciiz "\nYou're guess was too low, guess again: "
	str3: .asciiz "\nYou're guess was too high, guess again: "
	str4: .asciiz "\nYou guessed correct! It took you "
	str4.1: .asciiz " tries!"
	
	newline: .asciiz "\n"
	
.text

	#$t0 is the number in which the random number was stored
	#$t1 is the number in which well input the user's guess
	#$t2 is the number of guesses the person has made
	
	li $v0, 42 #this is syscall for a random number
	li $a1, 50 #this is the upper bound for the random int
	syscall    # puts random number between 0-50 in $a0
	
	move $t0, $a0 #move $a0 contents to $t0
	
	#prompt user for initial input:
	la $a0, str1
	li $v0, 4
	syscall

top:		
	
	#takes in user input
	li $v0, 5
	syscall
	
	#set $t1 equal to user input
	move $t1, $v0
	
	#incrememnts user guess counter
	addi $t2, $t2, 1

		#$t0 is the number in which the random number was stored
		#$t1 is the number in which well input the user's guess
		#$t2 is the number of guesses the person has made
	
	#if user input is equal 
	beq $t1, $t0, printEXIT
	
	#if user input is greater branch to greaterloop
	bgt $t1, $t0, greaterloop
	
	#if user input is lower branch to lowerloop
	blt $t1, $t0, lowerloop
	
greaterloop:

	#prompt user for input, because the guess was too low:
	la $a0, str3 #tells user the guess was too low
	li $v0, 4
	syscall
	
	j top #jumps to top where the user will pass new input into the system and go through the branch instructions again

lowerloop:

	#prompt user for input, because the guess was too high
	la $a0, str2 #tells user the guess was too high
	li $v0, 4
	syscall
	
	j top #jumps to top where the use will pass new input into the system and go through the branch instructions again
	
printEXIT:

	#prints ending statement 4
	la $a0, str4
	li $v0, 4
	syscall
	
	#prints guess counter
	move $a0, $t2
	li $v0, 1
	syscall
	
	#prints ending statement 4.1
	la $a0, str4.1
	li $v0, 4
	syscall
	
	#exits the program
	li $v0, 10
	syscall
	