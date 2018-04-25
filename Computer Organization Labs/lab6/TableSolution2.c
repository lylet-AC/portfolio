#include <stdio.h>
#include <math.h>
#include <string.h>

int main() {
	int max, i, j, k;
	int scan;
	int list[4];
	char LOG[25], ROOT[25], CUBE[25], EXPO[25];
	
	strcpy(LOG,  "log_3(x)");  //option 1
	strcpy(ROOT, "sqrt(x) ");  //option 2
	strcpy(CUBE, "1/x^3   ");    //option 3
	strcpy(EXPO, "1.2^x   ");    //option 4
	
	printf("Option 1:  %s\nOption 2:  %s\nOption 3:  %s\nOption 4:  %s\n", LOG, ROOT, CUBE, EXPO);
	
	for (j = 0; j < 4; j++) {
		printf("Which should be in column %d? \t", (j+1));
			scanf("%d", &scan);
			list[j] = scan;
	}
	
	for (i = 0; i < 4; i++){
		printf("Array number %d is: %d\n", i, list[i]);
	}
	
	printf("Enter an integer between 1 and 50:\n");
	scanf("%d",&max);

	//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		printf("\t x");
	
		// list 1
			if (list[0] == 1) {
				printf("\t%s\t", LOG);
			}
			if (list[0] == 2) {
				printf("\t%s\t", ROOT);
			}
			if (list[0] == 3) {
				printf("\t%s\t", CUBE);
			}
			if (list[0] == 4) {
				printf("\t%s\t", EXPO);
			}
		//list 2
			if (list[1] == 1) {
				printf("\t%s\t", LOG);
			}
			if (list[1] == 2) {
				printf("\t%s\t", ROOT);
			}
			if (list[1] == 3) {
				printf("\t%s\t", CUBE);
			}
			if (list[1] == 4) {
				printf("\t%s\t", EXPO);
			}		
		//list 3
			if (list[2] == 1) {
				printf("\t%s\t", LOG);
			}
			if (list[2] == 2) {
				printf("\t%s\t", ROOT);
			}
			if (list[2] == 3) {
				printf("\t%s\t", CUBE);
			}
			if (list[2] == 4) {
				printf("\t%s\t", EXPO);
			}
		//list 4
			if (list[3] == 1) {
				printf("\t%s \t\n", LOG);
			}
			if (list[3] == 2) {
				printf("\t%s \t\n", ROOT);
			}
			if (list[3] ==3) {
				printf("\t%s \t\n", CUBE);
			}
			if (list[3] == 4) {
				printf("\t%s \t\n", EXPO);
			}
	
	//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		printf("\t -");
	
			if (list[0] == 1) {
				printf("\t--------\t");
			}
			if (list[0] == 2) {
				printf("\t------- \t");
			}
			if (list[0] == 3) {
				printf("\t-----   \t");
			}
			if (list[0] == 4) {
				printf("\t-----   \t");
			}
		//list 2
			if (list[1] == 1) {
				printf("\t--------\t");
			}
			if (list[1] == 2) {
				printf("\t------- \t");
			}
			if (list[1] == 3) {
				printf("\t-----   \t");
			}
			if (list[1] == 4) {
				printf("\t-----   \t");
			}		
		//list 3
			if (list[2] == 1) {
				printf("\t--------\t");
			}
			if (list[2] == 2) {
				printf("\t------- \t");
			}
			if (list[2] == 3) {
				printf("\t-----   \t");
			}
			if (list[2] == 4) {
				printf("\t-----   \t");
			}
		//list 4
			if (list[3] == 1) {
				printf("\t--------\t\n");
			}
			if (list[3] == 2) {
				printf("\t------- \t\n");
			}
			if (list[3] ==3) {
				printf("\t-----   \t\n");
			}
			if (list[3] == 4) {
				printf("\t-----   \t\n");
			}
	
	for (k = 1; k <= max; k++) {
		
		printf("\t %d ", k);
		//list 1
		if (list[0] == 1) {
			printf("\t%1.6f\t",  log(k)/log(3));
		}
		if (list[0] == 2) {
			printf("\t%1.7f\t",  sqrt(k));
		}
		if (list[0] == 3) {
			printf("\t%1.7f\t",  pow(k,-3));
		}
		if (list[0] == 4) {
			printf("\t%6.2f\t", pow(1.2,k));
		}
		//list2
		if (list[1] == 1) {
			printf("\t%1.6f\t",  log(k)/log(3));
		}
		if (list[1] == 2) {
			printf("\t%1.7f\t",  sqrt(k));
		}
		if (list[1] == 3) {
			printf("\t%1.7f\t",  pow(k,-3));
		}
		if (list[1] == 4) {
			printf("\t%6.2f\t", pow(1.2,k));
		}
		//list 3
		if (list[2] == 1) {
			printf("\t%1.6f\t",  log(k)/log(3));
		}
		if (list[2] == 2) {
			printf("\t%1.7f\t",  sqrt(k));
		}
		if (list[2] == 3) {
			printf("\t%1.7f\t",  pow(k,-3));
		}
		if (list[2] == 4) {
			printf("\t%6.2f\t", pow(1.2,k));
		}
		//list 4
		if (list[3] == 1) {
			printf("\t%1.6f\t\n",  log(k)/log(3));
		}
		if (list[3] == 2) {
			printf("\t%1.7f\t\n",  sqrt(k));
		}
		if (list[3] == 3) {
			printf("\t%1.7f\t\n",  pow(k,-3));
		}
		if (list[3] == 4) {
			printf("\t%6.2f\t\n", pow(1.2,k));
		}
	}
	
	

	return 0;
} //main
