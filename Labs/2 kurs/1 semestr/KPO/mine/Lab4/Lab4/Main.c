

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>
int main(void) {
	char inputstr[10];
	char outputstr[20] = ' ';
	bool changer = false;
	
	fgets(inputstr, 10, stdin);
	for (int i = 0; i < 10; i++) {
		if (inputstr[i] != '_') {
			int j = 0;
			while ( outputstr[j] != ' ') {
				if (inputstr[i] == outputstr[j]) {
					outputstr[j + 1] +=  1;
					changer = true;
				}
				j++;
			}
			if (changer = false) {
				outputstr[j] = inputstr[i];
				outputstr[j + 1] = 1;
			}
		}
	}
	printf("%s\n", outputstr);
	return 0;
}
