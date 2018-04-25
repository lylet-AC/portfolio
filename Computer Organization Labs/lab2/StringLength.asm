.data
	
	str: .asciiz	"MIPS is awesome!"
	str2: .asciiz    "The string length is: "

	length: .word 0

.text

	la $t0, str				#$t0 holds the string address
	li $t1, 0				#$t1 holds the character count
	
	loopTop:					#top of our loop
	
		lb $t2, 0($t0)			#load the character at $t0 (loaded as bytes interpreted in hexidecimal or ascii)
	
		bne $t2, $zero, notEqual	#jump to notEqual if things arent Equal
		
		#found our end of string
		
		la $a0, str2			#loads str2 into $a0
		
		li $v0, 4			#sets $v0 to 4 which reads a string from $a0
		syscall
		
		li $v0, 1			#setting sycall 1
		move $a0, $t1			#copying the string length
		syscall 			#issuing syscall
		
		sw $t1, length
		
		li $v0, 10			#setting syscall to 10
		syscall				#issuing the system call
		
		
			
	notEqual:
		
		addi $t1, $t1, 1		#increment $t1
		addi $t0, $t0, 1		#move to the next character
		
		j loopTop			#jumps to loopTop
		
	
	
