.data

	str1:	.asciiz 	"\nPlease enter any number: "
	str2:	.asciiz		"\nYou've entered: "
	str3:	.asciiz		"\nThe sign is (1=negative, 0=positive: "
	str4:	.asciiz		"\nThe exponent is: 2^"
	str5:	.asciiz		"\nThe Significand is: "
	str6:	.asciiz		"\nYour value in hex is: "
	str7:	.asciiz		"\nYour value in binary is: "
	
.text
	# Prompt the user for input
	li $v0, 4
	la $a0, str1
	syscall
	
	# Getting input from user
	li $v0, 5
	syscall
	
	# Move input to $t4
	move $t4, $v0
	
	# Determine the value of the first bit in the user's input and store it in $t0
	andi $t0, $t4, 0x80000000;
	#Since this will return the sign as - 00000000 00000000000000000000000, we need to need to shift the bit 31 bits to the right 
	srl $t0, $t0, 31;
	
	#Determine the value of the next 8 bits in the user's input and store it in $t1
	andi $t1, $t4, 0x7f800000;
	
	#Since this will return the sign as 0 -------- 00000000000000000000000, we need to need to shift the bit 23 bits to the right
	srl $t1, $t1, 23;
	
	#Determine the value of the last 23 bits in the user's input and store it in $t2
	andi $t2, $t4, 0x7f800000;
	#Since this will return the sign as _ 00000000 -----------------------, we need to do not need to shift the bits
	
	#prints the values
	#print's what the user has entered
	li $v0, 4
	la $a0, str2
	syscall
	
	li $v0, 2 #to print a float
	move, $a0, $t4
	syscall
	
	#print's the sign
	li $v0, 4
	la $a0, str3
	syscall
	
	li $v0, 1 #to print an int
	move, $a0, $t0
	syscall
	
	#print's the exponent
	li $v0, 4
	la $a0, str4
	syscall
	
	li $v0, 1 #to print an int
	move, $a0, $t1
	syscall
	
	#print's the significand
	li $v0, 4
	la $a0, str5
	syscall
	
	li $v0, 1 #to print an int
	move, $a0, $t2
	syscall
	
	#print's the value in hex
	li $v0, 4 
	la $a0, str6
	syscall
	
	li $v0, 34 #to print a hex value
	move, $a0, $t4
	syscall
	
	#print's the value in binary
	li $v0, 4 
	la $a0, str7
	syscall
	
	li $v0, 35 #to print a binary value
	move, $a0, $t4
	syscall
	
    	#Exits the program
	li $v0, 10
	syscall