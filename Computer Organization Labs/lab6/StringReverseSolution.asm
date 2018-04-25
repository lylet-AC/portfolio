.data
	str:	.asciiz		"MIPS is awesome!"

.text

	la $t0, str			# $t0 holds the string address
	li $t1, 0			# $t1 holds the character count
	
	# PUT A BACKUP OF THE STARTING ADDRESS OF THE STRING INTO $T3
	move $t3, $t0
	
	
   loopTop:				# top of our loop
   	lb $t2, 0($t0)			# load the character at address $t0
   
   	bne $t2, $zero, notEqual	# jump to notEqual if things aren't equal
   	
   	# At this point, the length of our string (16) is stored in
   	# $t1, and $t0 is currently pointing off the end of the string
   	# in memory at address 0x10010010.
   	
   	# STEP BACK ONE CHARACTER IN THE STRING TO GET
   	# BACK TO 0x1001000f
   	subi $t0, $t0, 1
   	
  topReverseLoop:
   	# LOAD THE CHARACTER AT POSITION $T0 BACK INTO $T2
   	lb $t2, 0($t0)
   	
   	# PRINT THE CHARACTER IN $T2 USING THE APPROPRIATE SYSCALL
   	move $a0, $t2
   	li $v0, 11
   	syscall
   	
   	# CHECK TO SEE IF THE ADDRESS OF THE CHARACTER THAT WE JUST PRINTED
   	# IS NOT EQUAL TO THE ADDRESS AT THE START OF THE STRING IN $T3.
   	# IF THEY ARE NOT EQUAL, BRANCH TO reverseNotEqual
   	bne $t3, $t0, reverseNotEqual
 
 	# WE HAVE PRINTED ALL OF THE CHARACTERS NOW, SO EXIT
    	li $v0, 10
   	syscall
   	
   	
  reverseNotEqual:
  	# WE NEED TO BACK UP THE POINTER STORED IN $T0 BY ONE CHARACTER
  	addi $t0, $t0, -1
  	
  	# JUMP TO topReverseLoop
  	j topReverseLoop
  	
   	
  notEqual:
  	addi $t1, $t1, 1		# increment $t1
  	addi $t0, $t0, 1		# move to the next char
  	j loopTop			# jump to the top of the loop
