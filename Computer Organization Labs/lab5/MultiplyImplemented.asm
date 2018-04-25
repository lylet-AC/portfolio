	.data 

Multi1: .asciiz "\nThe First multiplier is 10"
Multi2: .asciiz "\nThe Second multiplier is 3"

End: .asciiz "\nThe final product is: "
	
	.text

#output top two text items and place the numbers into $t1 and $t2
li $v0, 4
la $a0, Multi1
syscall
la $a0, Multi2
syscall

li $t1, 10
li $t2, 3

Loop:
	bge $t5, 32, Exit #if $t5 = 32, we exit and multiplication is done
	andi $t0, $t1, 0x1 #return rightmost bit of $t1 and puts it in $t0

	beqz $t0, MULTIZERO #if the rightmost bit is 0, go to MULTIZERO
	beq $t0, 1, MULTIONE # if the rightmost bit is 1, go to MULTIONE

	addi $t5, $t5, 1 #increments $t5 
	j Loop #jump to top of loop

Exit:
	li $v0, 4 #prints the product
	la $a0, End
	syscall

	li $v0, 10 #exits the program
	syscall
	
MULTIZERO: #shift $t1 (multiplicand) left and $t2 (multiplier) right
	sll $t1, $t1, 1
	srl $t2, $t2, 1
	j Loop

MULTIONE: #add multiplicand to product and place in product register ($t3)
	add $t1, $t3, $t3
	sll $t1, $t1, 1 #shift $t1 (multiplicand) left and $t2 (multiplier) right
	srl $t2, $t2, 1
	j Loop