#Make computer guess my number

.data
	
	str1: .asciiz "\nPlease think of an integer between 1 and 50 hit enter when ready."
	str2: .asciiz "\nThe computer guesses: "
	str3: .asciiz "\nWas the guess high or low or just right? (1=high | 2=low | 3=correct): "
	str4: .asciiz "\nYour number was: "
	str5: .asciiz "\nThe computer took this many tries to guess: "
	
.text
	
	#$t0 is the minimum guess
	#$t1 is the maximum guess
	#$t2 is the user input for the number
	#guess value is $t3 (set to default the guess at 25 ((max+min)/2)
	#tries counter is $t4
	li $t0, 50
	li $t1, 0
	li $t3, 25
	
	#prompts the user to think of a guess
	la $a0, str1
	li $v0, 4
	syscall
	
	#asks for meaningless input
	li $v0, 8
	syscall
	
######## print guess, ask user if the guess was correct. ##########

TOP:

	#incrememnt tries counter
	addi $t4, $t4, 1
			
	# "the computer guesses: __"
	la $a0, str2
	li $v0, 4
	syscall
	
	#prints number as well
	move $a0, $t3
	li $v0, 1
	syscall
	
	# "was it high/low/correct"
	la $a0, str3
	li $v0, 4
	syscall
	
	#takes in user input ### 1=guess to high ### 2=guess to low ### 3=correct
	li $v0, 5
	syscall
	#saves user input in $t2
	move $t2, $v0
	
	#if user data is 1 branch to tooHIGH:
	beq $t2, 1, tooHIGH
	
	#if user data is 2 branch to tooLOW:
	beq $t2, 2, tooLOW
	
	#if user data is 3 exit the loop
	beq $t2, 3, EXIT	
	
j TOP

	#$t0 is the minimum guess
	#$t1 is the maximum guess
	#$t2 is the user input for the number
	#guess value is $t3 (set to default the guess at 25 ((max+min)/2)
	#our tries counter is $t4

tooHIGH:

	#set min = lastguess ($t3), then make lastguess = ((max+min)/2)
	move $t0, $t3 #min = lastguess
	add $t6, $t0, $t1 #$t6 = min+max
	div $t3, $t6, 2 #guess = min((max+min)/2)

	#jump back to TOP since we completed our re-evaluation of the guess
	j TOP

tooLOW:

	#set max = lastguess ($t3), then make lastguess = ((max+min)/2)
	move $t1, $t3 #min = lastguess
	add $t6, $t0, $t1 #$t6 = min+max
	div $t3, $t6, 2 #guess = min((max+min)/2)

	#jump back to TOP since we completed our re-evaluation of the guess
	j TOP
	
EXIT:
			
	# "your number was: "
	la $a0, str4
	li $v0, 4
	syscall
	
	#prints number as well
	move $a0, $t3
	li $v0, 1
	syscall
	
				
	# "the number of guesses was: "
	la $a0, str5
	li $v0, 4
	syscall
	
	#prints number as well
	move $a0, $t4
	li $v0, 1
	syscall
	
	#exits the program
	li $v0, 10
	syscall	
