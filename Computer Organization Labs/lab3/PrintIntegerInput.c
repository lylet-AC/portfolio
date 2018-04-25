#include <stdio.h>
#include <math.h>

int main() {

    int number;
    int i = 1;
    float num1, num2, num3, num4, num5;

    // printf() displays the formatted output 
    printf("Enter an integer between 1 and 50: ");  
    
    // scanf() reads the formatted input and stores them
    scanf("%d", &number);  
    
    // printf() displays the formatted output
    printf("X, \t sqrt(x), \t 1/x^3, \t log_3(x), \t 1.2^x");
    printf("-- \t -------- \t ------ \t --------- \t -----");



	for(i <= number; i++)
	{
		num1 = i;
		num2 = math.sqrt(i);
		num3 = 1/(math.pow(i,3));
		num4 = (math.log(i))/(math.log(3));
		num5 = math.pow(1.2, i);
		

		printf("%5.3f \t %5.3f \t %5.3f \t %5.3f \t %5.3f", num1, num2, num3, num4, num5);

	}

    return 0;

} //main
