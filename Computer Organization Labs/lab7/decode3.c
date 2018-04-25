#include <stdio.h>
#include <math.h>
int main() {
    unsigned input, bitshift, currentbit, i, j, temp;
	unsigned significandarray[22], exponentarray[8];
    printf("\nPlease enter a float value: ");
    scanf("%f", &input);
	
    unsigned sign = input & 0x80000000;
    unsigned exponent = input & 0x7f800000;
    unsigned significand = input & 0x007fffff;
	
    printf("\nYour value in hex: 0x%4x", input);
    printf("\nSign's value in hex: 0x%4x", sign);	
    printf("\nExponent's value in hex: 0x%4x", exponent);
    printf("\nSignificand's value in hex: 0x%4x", significand);
	
///////////////////////////////////////////////////////////////////////////////////////	
	//inputs the binary numbers into the array
 
	for (bitshift = 0; bitshift <= 22; bitshift++) {
		currentbit = significand >> bitshift;
 
		if (currentbit & 1) {
			significandarray[bitshift] = 1;
		}
		else{
			significandarray[bitshift] = 0;
		}
	}
		
	 //swaps array into correct order
 
	j = 21;   // j will Point to last Element
	i = 0;       // i will be pointing to first element
	
	while (i < j) {
		temp = significandarray[i];
		significandarray[i] = significandarray[j];
		significandarray[j] = temp;
		i++;             // increment i
		j--;          // decrement j
	}
	
	
/////////////////////////////////////////////////////////////////////////////////////// 
 
	//inputs the binary numbers into the array
 
	for (bitshift = 0; bitshift <= 7; bitshift++) {
		currentbit = exponent >> bitshift;
 
		if (currentbit & 1) {
		exponentarray[bitshift] = 1;
		}
		else {
		exponentarray[bitshift] = 0;
		}
	}
		
	 //swaps array into correct order
 
	j = 7;   // j will Point to last Element
	i = 0;       // i will be pointing to first element
	
	while (i < j) {
		temp = exponentarray[i];
		exponentarray[i] = exponentarray[j];
		exponentarray[j] = temp;
		i++;             // increment i
		j--;          // decrement j
	}

///////////////////////////////////////////////////////////////////////////////////////

	
	
	//print statements
	printf("\nIn Binary: ");
	
	if (sign&1 == 1) {
		printf("1");
	}
	else
		printf("0");
	
	printf(" ");	
	
	//prints exponent array 
  	for (i = 0; i <= 7; i++) {
  		printf("%d", exponentarray[i]);			
	}
	
	printf(" ");	
	
	//print's significand array
	for (i = 0; i <= 22; i++) {
		printf("%d", significandarray[i]);
	}

		
    printf("\n");
        return 0;
}
