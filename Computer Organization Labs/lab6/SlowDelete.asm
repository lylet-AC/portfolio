.data
	str:	.asciiz		"MIPS is awesome!"

.text
	la $t0, str			# $t0 holds the string address
	la $t5, str			#$t5 holds the beginning string address
	li $t1, 0			# $t1 holds the character count
	li $t6, 0			#times iterated throughout the loops

loopTop:  #Use this loop to find the pointer at the end of the string	
	lb $t2, 0($t0)			# load the character at address $t0
   
   	bne $t2, $zero, notEqual	# jump to notEqual when the $t2 pointer isn't equal to 0 which would signify the end of the string
   	
deleteEnd:  #use this loop to overwrite the last char in the string with a space

	#OVERWRITE LAST CHAR WITH SPACE
	sb $t0, 32 #set's the value of the byte at address $t0 to 32 (value of space in ascii)

	subi $t0, $t0, 1 #use this to step back a char in the string from the end
	
	#print string:
   	la $a0, str #moves contents of $t0 to $a0 for system to print
   	li $v0, 4 #sets syscall to 4 to print a string
   	syscall
	
	bne $t6, $t1, Exit #if $t6 is equal to $t1, we know that we have deleted all the chars since $t6 keeps track of the amount of chars deleted and $t1 keeps track of total chars
	addi $t6, $t6, 1 #increment $t6 to keep track of delete iterations
	j deleteFront

deleteFront:  #use this loop to overwrite the first char in the string with a space

 	#OVERWRITE LAST CHAR WITH SPACE
	sb  $t5, 32 #set's the value of the byte at address $t0 to 32 (value of space in ascii)   	
   	   	   	
   	addi $t5, $t5, 1 #use this to move a char forward from the front of the string
   	
   	#print string:
   	la $a0, str #moves contents of $t0 to $a0 for system to print
   	li $v0, 4 #sets syscall to 4 to print a string
   	syscall
   	
   	bne $t6, $t1, Exit #if $t6 is equal to $t1, we know that we have deleted all the chars since $t6 keeps track of the amount of chars deleted and $t1 keeps track of total chars
	addi $t6, $t6, 1 #increment $t6 to keep track of delete iterations
	
	j deleteEnd
   	
notEqual: #Use this loop to find the pointer at the end of the string
   	addi $t1, $t1, 1		# increment $t1
  	addi $t0, $t0, 1		# move to the next char
  	j loopTop			# jump to the top of the loop
  	
Exit:

	li $v0, 10 #load syscall value for exit
	syscall
	