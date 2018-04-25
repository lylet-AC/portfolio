#Goal: make user guess computer's number
.data
	
	str1: .asciiz "\nThe computer has created a number between 0-50.  Take a Guess: "
	str2: .asciiz "\nYou're guess was too low, guess again: "
	str3: .asciiz "\nYou're guess was too high, guess again: "
	str4: .asciiz "\nYou guessed correct! It took you "
	str4.1: .asciiz " tries!"
	str5:  .asciiz "Would you like to play again? (1=yes|2=no)"
	
	newline: .asciiz "\n"

.text

TOP:
	jal welcome_Messages
	jal get_Input

	#if user input is equal 
	beq $t1, $t0, play_again			
	#if user input is greater branch to greaterloop
	bgt $t1, $t0, greaterloop
	#if user input is lesser branch to lowerloop
	blt $t1, $t0, lowerloop
	
greaterloop:	
	jal greaterloop_PROC
lowerloop:	
	jal lowerloop_PROC
play_again:
	jal play_again_PROC
	
	#if user input is equal to 1, play again.  Else: exit
	beq $t1, 1, TOP
	#exits the program
	li $v0, 10
	syscall  
	
welcome_Messages:
	# prologue
	subi $sp, $sp, 12
	sw $ra, 0($sp)
	sw $v0, 4($sp)
	sw $a0, 8($sp)
	
	# procedure body
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
    	
    	# epilogue
    	lw $a0, 8($sp)
    	lw $v0, 4($sp)
    	lw $ra, 0($sp)
    	addi $sp, $sp, 12
    	
    	# return
    	jr $ra
    	
get_Input:
	# prologue
	subi $sp, $sp, 24
	sw $ra, 0($sp)
	sw $v0, 4($sp)
	sw $a0, 8($sp)
	sw $t0, 12($sp)
	sw $t1, 16($sp)
	sw $t2, 20($sp)
	
	# procedure body
	#takes in user input
	li $v0, 5
	syscall
	#set $t1 equal to user input
	move $t1, $v0
	#incrememnts user guess counter
	addi $t2, $t2, 1
	
    	# epilogue
    	lw $t0, 12($sp)
	lw $t1, 16($sp)
	lw $t2, 20($sp)
    	lw $a0, 8($sp)
    	lw $v0, 4($sp)
    	lw $ra, 0($sp)
    	addi $sp, $sp, 24
    	
    	# return
    	jr $ra
	
greaterloop_PROC:
	# prologue
	subi $sp, $sp, 12
	sw $ra, 0($sp)
	sw $v0, 4($sp)
	sw $a0, 8($sp)
	
	#procedure body
	#prompt user for input, because the guess was too high
	la $a0, str2 #tells user the guess was too high
	li $v0, 4
	syscall
	jal get_Input #jumps to top where the use will pass new input into the system and go through the branch instructions again	
	
    	# epilogue
    	lw $a0, 8($sp)
    	lw $v0, 4($sp)
    	lw $ra, 0($sp)
    	addi $sp, $sp, 12
    	
    	# return
    	jr $ra
    	
lowerloop_PROC:
	# prologue
	subi $sp, $sp, 12
	sw $ra, 0($sp)
	sw $v0, 4($sp)
	sw $a0, 8($sp)

	#procedure body
	#prompt user for input, because the guess was too low:
	la $a0, str3 #tells user the guess was too low
	li $v0, 4
	syscall
	jal get_Input #jumps to top where the user will pass new input into the system and go through the branch instructions again	
	
    	# epilogue
    	lw $a0, 8($sp)
    	lw $v0, 4($sp)
    	lw $ra, 0($sp)
    	addi $sp, $sp, 12
    	
    	# return
    	jr $ra
    	
play_Again_PROC:
	# prologue
	subi $sp, $sp, 16
	sw $ra, 0($sp)
	sw $v0, 4($sp)
	sw $a0, 8($sp)
	sw $t1, 12($sp)
	
	# procedure body
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
	
	#asks if the user would like to play again
	la $a0, str5
	li $v0, 4
	syscall
	
	#takes in user input
	li $v0, 5
	syscall
	#set $t1 equal to user input
	move $t1, $v0	
	
	# epilogue
	lw $t1, 12($sp)
    	lw $a0, 8($sp)
    	lw $v0, 4($sp)
    	lw $ra, 0($sp)
    	addi $sp, $sp, 16
    	
    	# return
    	jr $ra
  	