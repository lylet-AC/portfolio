#include <stdio.h>
#include <math.h>

int main() {

    int number;
    int i;
    float num1, num2, num3, num4, num5;

    // printf() displays the formatted output 
    printf("Enter an integer between 1 and 50: ");  
    
    // scanf() reads the formatted input and stores them
    scanf("%d", &number);  
    
    // printf() displays the formatted output
    printf("\nX\tsqrt(x)\t1/x^3\tlog3(x)\t1.2^x");
    printf("\n-\t-------\t-----\t-------\t-----");



	for(i=0; i <= number; i = i+1)
	{
		num1 = i;
		num2 = sqrt(i);
		num3 = 1/(pow(i,3));
		num4 = (log(i))/(log(3));
		num5 = pow(1.2, i);
		

		printf("\n%2.0f\t%2.4f\t%5.3f\t%2.4f\t%5.2f", num1, num2, num3, num4, num5);

	}
	printf("\n");

    return 0;

} //main
