#include <stdio.h>
#include <math.h>

int main() {
	int max, i;
	printf("Enter an integer between 1 and 50:");
	scanf("%d",&max);

	printf("\t x\t  1/x^3  \t sqrt(x)  \tlog_3(x)\t     1.2^x\n");
	printf("\t -\t  -----  \t -------  \t--------\t     -----\n");
	for (i = 1; i <= max; i++) {
        	printf("\t%2d \t %1.5f \t %1.5f \t %1.5f \t %10.5f\n", i, pow(i,-3), sqrt(i), log(i)/log(3), pow(1.2,i));
	} //for

	return 0;
} //main
