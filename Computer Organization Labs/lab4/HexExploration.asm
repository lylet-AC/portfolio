.data
	hello:		.asciiz		"Hello world!\n"
	number1:	.word		42
	number2:	.half		21
	number3:	.half		1701
	number4:	.byte		73
	number5:	.half		-1
	number6:	.byte		127
	number7:	.word		65535
	
	#######################
	#  ADDRESS   #  DATA  #
	#######################
	# 0x10010010 #  48    #
	# 0x10010011 #  65    #
	# 0x10010012 #  6c    #
	# 0x10010013 #  6c    #
	# 0x10010014 #  6f    #
	# 0x10010015 #  20    #
	# 0x10010016 #  77    #
	# 0x10010017 #  6f    #
	# 0x10010018 #  72    #
	# 0x10010019 #  6c    #
	# 0x1001001a #  64    #
	# 0x1001001b #  21    #
	# 0x1001001c #  0a    #
	# 0x1001001d #  00    #
	# 0x1001001e #  00    #
	# 0x1001001f #  00    #
	# 0x10010020 #  2a    #
	# 0x10010021 #  00    #
	# 0x10010022 #  00    #
	# 0x10010023 #  00    #
	# 0x10010024 #  15    #
	# 0x10010025 #  00    #
	# 0x10010026 #  a6    #
	# 0x10010027 #  06    #
	#######################


.text

	la $a0, hello
	li $v0, 4
	syscall
	
	li $v0, 10
	syscall
